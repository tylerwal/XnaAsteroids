using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShipGame.GameObjects;
using ShipGame.GameObjects.BaseClass;
using ShipGame.WinFormGraphicDevice;

namespace ShipGame.GameDisplay
{
	public class XNAGameDisplay : GraphicsDeviceControl
	{
		#region Constants

		private const int _gameUpdateElapsedTime = 20;

		#endregion Constants

		#region Fields

		private ContentManager _content;

		private SpriteBatch _spriteBatch;

		private Stopwatch _stopwatch;

		private GameTime _gameTime;

		private IList<GameObjectBase> _gameObjects;

		//private IList<Rectangle> _shipRects;

		private KeyboardState _keyboardCurrentState;

		private MouseState _mouseCurrentState;

		

		/*//test

		private Texture2D tesTexture2D;
		private Texture2D shipTexture2D;
		private Rectangle rectangle;*/

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

		
		
		#endregion Properties

		#region Constructors

		public XNAGameDisplay()
		{
			var test = this.Size;
		}

		#endregion Constructors

		#region Overrides

		protected override void Initialize()
		{
			_content = new ContentManager(Services, "Content");

			_spriteBatch = new SpriteBatch(GraphicsDevice);

			/*//test

			rectangle = new Rectangle(50,50,50,50);

			shipTexture2D = _content.Load<Texture2D>("Ship");

			_shipRects =  GameUtilities.GameUtilities.GetSpriteRectangles(shipTexture2D, 2, 8);

			_shipRects = GameUtilities.GameUtilities.RemoveFrameLines(_shipRects);

			tesTexture2D = new Texture2D(GraphicsDevice, 1, 1);
			tesTexture2D.SetData(new Color[]{Color.AliceBlue});

			
			//test end*/
			
			_stopwatch = Stopwatch.StartNew();

			_gameTime = new GameTime();

			_gameObjects = new List<GameObjectBase>();

			Ship playerOne = new Ship(this);

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
			GraphicsDevice.Clear(Color.Black);

			int elapsedTime = _stopwatch.Elapsed.Milliseconds;

			//only update game objects so often to avoid game moving too fast
			if (elapsedTime > _gameUpdateElapsedTime)
			{
				UpdateGameObjects();

				_stopwatch.Restart();
			}
			
			_spriteBatch.Begin();

			//tcw delete
			/*_spriteBatch.Draw(tesTexture2D, rectangle, Color.DarkRed);
			_spriteBatch.Draw(shipTexture2D, new Vector2(120, 120), _shipRects[0], Color.White);*/

			//lop through game objects and draw them based on DisplayOrder
			_gameObjects.OrderBy(i => i.DisplayOrder).ToList().ForEach(j => j.Draw());
		
			_spriteBatch.End();

		}

		#endregion Overrides

		#region Methods

		private void UpdateGameObjects()
		{
			KeyboardCurrentState = Keyboard.GetState();

			MouseCurrentState = Mouse.GetState();

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