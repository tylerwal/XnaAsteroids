using Microsoft.Xna.Framework.Input;
using ShipGame.GameDisplay;
using ShipGame.GameObjects.BaseClass;

namespace ShipGame.GameObjects
{
	public class GameControls: GameObjectBase
	{
		#region Fields

		private KeyboardState _keyboardCurrentState;

		private MouseState _mouseCurrentState;

		#endregion Fields

		#region Properties

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

		public GameControls(XnaGame xnaXnaGame): base(xnaXnaGame)
		{
			
		}

		#endregion Constructors

		#region Methods

		public override void Initialize()
		{
			IsVisible = false;
		}

		public override void Draw()
		{
		}

		public override void Update()
		{
			Mouse.WindowHandle = XnaGame.Handle;

			KeyboardCurrentState = Keyboard.GetState();

			MouseCurrentState = Mouse.GetState();
		}

		#endregion Methods

		#region Helper Methods



		#endregion Helper Methods
	}
}