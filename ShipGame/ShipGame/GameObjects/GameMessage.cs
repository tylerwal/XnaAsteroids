using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShipGame.GameDisplay;
using ShipGame.GameObjects.BaseClass;

namespace ShipGame.GameObjects
{
	using System.Drawing;
	using System.Text;

	using Color = Microsoft.Xna.Framework.Color;

	public class GameMessage : GameObjectBase
	{
		#region Fields

		private SpriteFont _spriteFont;

		private string _message;

		private StringBuilder _stringBuilder;
		
		#endregion Fields

		#region Properties

		#endregion Properties

		#region Constructors

		/*public GameMessage(XnaGame xnaXnaGame)
			: base(xnaXnaGame)
		{
		}*/

		public GameMessage(XnaGame xnaXnaGame, string message)
			: base(xnaXnaGame)
		{
			_message = message;
		}

		public GameMessage(XnaGame xnaXnaGame, string message, bool isCentered)
			: base(xnaXnaGame)
		{
			_message = message;

			Rectangle test = XnaGame.ClientRectangle;


			
		}

		#endregion Constructors

		#region Methods

		public override void Initialize()
		{
			DisplayOrder = 1;

			IsVisible = true;

			_spriteFont = XnaGame.Content.Load<SpriteFont>("SpriteFont");

			PositionVector = new Vector2(20, 20);
		}

		public override void Draw()
		{
			XnaGame.SpriteBatch.DrawString(
				_spriteFont,
				new StringBuilder(_message),
				PositionVector,
				Color.Red
				);

		}

		public override void Update()
		{
		}

		#endregion Methods

		#region Helper Methods
		

		#endregion Helper Methods
	}
}