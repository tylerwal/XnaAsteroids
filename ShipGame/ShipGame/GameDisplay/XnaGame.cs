using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShipGame.GameObjects;
using ShipGame.GameObjects.BaseClass;
using ShipGame.GameUtilities;
using ShipGame.WinFormGraphicDevice;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace ShipGame.GameDisplay
{
	public class XnaGame : GraphicsDeviceControl
	{
		#region Fields

		private ContentManager _content;

		private SpriteBatch _spriteBatch;

		private Stopwatch _stopwatch;

		private IList<IGameObject> _gameObjects;

		private KeyboardState _keyboardCurrentState;

		private MouseState _mouseCurrentState;

		private GameUtilities.GameUtilities _gameUtilities;

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

		public GameUtilities.GameUtilities GameUtilities
		{
			get
			{
				return _gameUtilities;
			}
			set
			{
				_gameUtilities = value;
			}
		}

		#endregion Properties

		#region Constructors

		public XnaGame()
		{
			/*Content = new ContentManager(Services, "Content");

			SpriteBatch = new SpriteBatch(GraphicsDevice);*/

			GameObjects = new List<IGameObject>();

			GameUtilities = new GameUtilities.GameUtilities();

			//hook the idle event to constantly redraw the animation
			Application.Idle += delegate { Invalidate(); };
		}

		#endregion Constructors

		#region Overrides

		protected override void Initialize()
		{
			Content = new ContentManager(Services, GameConfig.ContentManagerName);

			SpriteBatch = new SpriteBatch(GraphicsDevice);

			/*//test
			rectangle = new Rectangle(50,50,50,50);
			tesTexture2D = new Texture2D(GraphicsDevice, 1, 1);
			tesTexture2D.SetData(new Color[]{Color.AliceBlue});
			//test end*/
			
			_stopwatch = Stopwatch.StartNew();
			
			Ship ship = new Ship(this);

			GameObjects.Add(ship);

			GameControls gameControls = new GameControls(this);

			GameObjects.Add(gameControls);

			for (int i = 0; i < 10; i++)
			{
				GameObjects.Add(new Asteroid(this)); 
			}

			//loop through game object initialize methods
			foreach (GameObjectBase gameObject in GameObjects)
			{
				gameObject.Initialize();
			}
		}

		protected override void Draw()
		{
			//background color
			GraphicsDevice.Clear(Color.Black);

			int elapsedTime = _stopwatch.Elapsed.Milliseconds;

			//only update game objects so often to avoid game moving too fast
			if (elapsedTime > ShipGame.GameUtilities.GameConfig.GameUpdateTime)
			{
				UpdateGameObjects();

				_stopwatch.Restart();
			}
			
			SpriteBatch.Begin();

			//tcw delete
			/*_spriteBatch.Draw(tesTexture2D, rectangle, Color.DarkRed);
			_spriteBatch.Draw(shipTexture2D, new Vector2(120, 120), _shipRects[0], Color.White);*/

			//loop through game objects and draw them based on DisplayOrder
			GameObjects.Where(v => v.IsVisible).OrderBy(i => i.DisplayOrder).ToList().ForEach(j => j.Draw());
		
			_spriteBatch.End();

		}

		#endregion Overrides

		#region Methods

		private void UpdateGameObjects()
		{
			KeyboardCurrentState = Keyboard.GetState();

			MouseCurrentState = Mouse.GetState();

			//loop through game object update methods
			foreach (GameObjectBase gameObject in GameObjects)
			{
				gameObject.Update();
			}
		}

		#endregion Methods

		#region Helper Methods



		#endregion Helper Methods
	}
}