﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShipGame.GameForms;
using ShipGame.GameObjects;
using ShipGame.GameObjects.BaseClass;
using ShipGame.GameUtilities;
using ShipGame.WinFormGraphicDevice;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Color = Microsoft.Xna.Framework.Color;

namespace ShipGame.GameDisplay
{
	public class XnaGame : GraphicsDeviceControl
	{
		#region Fields

		private ContentManager _content;

		private SpriteBatch _spriteBatch;

		private Stopwatch _gameUpdateStopWatch;

		private Stopwatch _globalGameStopWatch;

		private IList<IGameObject> _gameObjects;

		private KeyboardState _keyboardCurrentState;

		private MouseState _mouseCurrentState;

		private GameUtilities.GameUtilities _gameUtility;

		private TimeSpan _lastBulletCreationTime;
		
		#endregion Fields

		#region Properties

		public SpriteBatch SpriteBatch
		{
			get
			{
				return _spriteBatch;
			}
			set
			{
				_spriteBatch = value;
			}
		}

		public ContentManager Content
		{
			get
			{
				return _content;
			}
			set
			{
				_content = value;
			}
		}

		public KeyboardState KeyboardCurrentState
		{
			get
			{
				return _keyboardCurrentState;
			}
			set
			{
				_keyboardCurrentState = value;
			}
		}

		public MouseState MouseCurrentState
		{
			get
			{
				return _mouseCurrentState;
			}
			set
			{
				_mouseCurrentState = value;
			}
		}

		public IList<IGameObject> GameObjects
		{
			get
			{
				return _gameObjects;
			}
			set
			{
				_gameObjects = value;
			}
		}

		public GameUtilities.GameUtilities GameUtility
		{
			get
			{
				return _gameUtility;
			}
			set
			{
				_gameUtility = value;
			}
		}

		public Stopwatch GameUpdateStopWatch
		{
			get
			{
				return _gameUpdateStopWatch;
			}
			set
			{
				_gameUpdateStopWatch = value;
			}
		}

		public Stopwatch GlobalGameStopWatch
		{
			get
			{
				return _globalGameStopWatch;
			}
			set
			{
				_globalGameStopWatch = value;
			}
		}

		public TimeSpan LastBulletCreationTime
		{
			get
			{
				return _lastBulletCreationTime;
			}
			set
			{
				_lastBulletCreationTime = value;
			}
		}
		
		#endregion Properties

		#region Constructors

		public XnaGame()
		{
			//hook the idle event to constantly redraw the animation
			Application.Idle += delegate { Invalidate(); };
		}

		#endregion Constructors

		#region Overrides

		/// <summary>
		/// Initializes several objects that are necessary for the game (controls, ships, timers, etc.)
		/// </summary>
		protected override void Initialize()
		{
			#region Initialize Game Essentials

			GameObjects = new List<IGameObject>();

			GameUtility = new GameUtilities.GameUtilities();

			Content = new ContentManager(Services, GameConfig.ContentManagerName);

			SpriteBatch = new SpriteBatch(GraphicsDevice);

			GameUpdateStopWatch = Stopwatch.StartNew();

			GlobalGameStopWatch = Stopwatch.StartNew();

			LastBulletCreationTime = TimeSpan.Zero;

			#endregion Initialize Game Essentials

			Background background = new Background(this);
			GameObjects.Add(background);
			
			Ship ship = new Ship(this);
			GameObjects.Add(ship);

			GameControl gameControls = new GameControl(this);
			GameObjects.Add(gameControls);

			GameStatUpdater gameStatUpdaters = new GameStatUpdater(this);
			GameObjects.Add(gameStatUpdaters);

			for (int i = 0; i < 25; i++)
			{
				GameObjects.Add(new Asteroid(this)); 
			}

			//loop through game object initialize methods
			foreach (GameObjectBase gameObject in GameObjects)
			{
				gameObject.Initialize();
			}
		}

		/// <summary>
		/// Where the game is redrawn and updated (update is timer based)
		/// </summary>
		protected override void Draw()
		{
			//background color
			GraphicsDevice.Clear(Color.Black);

			int elapsedTimeFromLastGameUpdate = GameUpdateStopWatch.Elapsed.Milliseconds;

			//update game objects
			if (elapsedTimeFromLastGameUpdate > GameConfig.GameUpdateTime)
			{
				UpdateGameObjects();

				GameUpdateStopWatch.Restart();
			}
			
			SpriteBatch.Begin();

			//loop through game objects and draw them based on DisplayOrder
			GameObjects
				.Where(v => v.IsVisible)
				.OrderBy(i => i.DisplayOrder)
				.ToList()
				.ForEach(j => j.Draw());
		
			SpriteBatch.End();

		}

		#endregion Overrides

		#region Methods

		/// <summary>
		/// Method that updates game objects, called from Draw method based on timer interval.
		/// </summary>
		private void UpdateGameObjects()
		{
			KeyboardCurrentState = Keyboard.GetState();

			MouseCurrentState = Mouse.GetState();
			
			//loop through game object update methods
			GameObjects
				.OrderBy(i => i.DisplayOrder)
				.ToList()
				.ForEach(j => j.Update());

			BulletCreation();

			RemoveDeletedObjects();
		}

		#endregion Methods

		#region Helper Methods

		/// <summary>
		/// Checks mouse state and instantiates a new Bullet and adds it to the game objects list
		/// </summary>
		private void BulletCreation()
		{
			if (MouseCurrentState.LeftButton == ButtonState.Pressed)
			{
				TimeSpan time = GlobalGameStopWatch.Elapsed;

				if (time - LastBulletCreationTime > TimeSpan.FromSeconds(GameConfig.BulletReloadSpeed))
				{
					Bullet bullet = new Bullet(this);

					Ship ship = GameObjects.OfType<Ship>().First();

					bullet.PositionVector = GameUtilities.GameUtilities.GetVectorFromPoint(ship.Bounds.Center) - new Vector2(2.5f, 2.5f);

					Vector2 mousePosition = new Vector2(MouseCurrentState.X, MouseCurrentState.Y);

					Vector2 shipAngleVector = mousePosition - GameUtilities.GameUtilities.GetVectorFromPoint(ship.Bounds.Center);

					shipAngleVector.Normalize();

					bullet.VelocityVector = shipAngleVector * GameConfig.BulletSpeed;

					GameObjects.Add(bullet);

					bullet.Initialize();

					LastBulletCreationTime = GlobalGameStopWatch.Elapsed;
				}
			} 
		}

		/// <summary>
		/// Removes objects from the game object list when they are marked for deletion
		/// </summary>
		private void RemoveDeletedObjects()
		{
			List<GameObjectBase> markedForDeletion = GameObjects.OfType<GameObjectBase>().Where(i => i.IsMarkedForDeletion).ToList();

			foreach (GameObjectBase gameObject in markedForDeletion)
			{
				GameObjects.Remove(gameObject);
			}
		}

		#endregion Helper Methods
	}
}