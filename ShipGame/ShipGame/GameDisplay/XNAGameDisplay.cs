using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ShipGame.GameObjects;
using ShipGame.GameObjects.BaseClass;
using ShipGame.WinFormGraphicDevice;

namespace ShipGame.GameDisplay
{
	public class XNAGameDisplay : GraphicsDeviceControl
	{
		#region Fields

		private ContentManager _contentManager;

		private SpriteBatch _spriteBatch;

		private Stopwatch _stopwatch;

		private GameTime _gameTime;

		private IList<GameObjectBase> _gameObjects;

		//test
		private ContentManager contentManager;

		private Texture2D tesTexture2D;
		private Texture2D shipTexture2D;
		private Rectangle rectangle;

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
		
		#endregion Properties

		#region Constructors

		public XNAGameDisplay()
		{
			
		}

		#endregion Constructors

		#region Overrides

		protected override void Initialize()
		{
			_contentManager = new ContentManager(Services, "Content");

			_spriteBatch = new SpriteBatch(GraphicsDevice);

			//test
			contentManager = new ContentManager(Services);

			rectangle = new Rectangle(50,50,50,50);

			shipTexture2D = contentManager.Load<Texture2D>("Ship");

			tesTexture2D = new Texture2D(GraphicsDevice, 1, 1);
			tesTexture2D.SetData(new Color[]{Color.AliceBlue});


			/*_spriteBatch.Begin();
			_spriteBatch.Draw(tesTexture2D, rectangle, Color.DarkRed);*/
			

			//test


			_stopwatch = Stopwatch.StartNew();

			_gameTime = new GameTime();

			_gameObjects = new List<GameObjectBase>();

			Ship playerOne = new Ship();

			_gameObjects.Add(playerOne);

			//loop through game object initialize methods
			foreach (GameObjectBase gameObject in _gameObjects)
			{
				gameObject.Initialize();
			}

			//hook the idle event to constantly redraw the animation
			Application.Idle += delegate { Invalidate(); };
		}

		protected override void Draw()
		{
			//background color
			GraphicsDevice.Clear(Color.Gray);

			int elapsedTime = _stopwatch.Elapsed.Milliseconds;

			if (elapsedTime > 200)
			{
				UpdateGameObjects();

				_stopwatch.Restart();
			}

			//loop through game object draw methods
			foreach (GameObjectBase gameObject in _gameObjects)
			{
				gameObject.Draw();
			}

			
			_spriteBatch.Begin();
			_spriteBatch.Draw(tesTexture2D, rectangle, Color.DarkRed);
			_spriteBatch.Draw(shipTexture2D, new Vector2(120,120), Color.Blue );
			_spriteBatch.End();

		}

		#endregion Overrides

		#region Methods

		private void UpdateGameObjects()
		{
			//loop through game object update methods
			foreach (GameObjectBase gameObject in _gameObjects)
			{
				gameObject.Update();
			}
		}

		#endregion Methods

		#region Helper Methods



		#endregion Helper Methods
	}
}