using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShipGame.GameDisplay;
using ShipGame.GameObjects.BaseClass;
using Point = System.Drawing.Point;

namespace ShipGame.GameObjects
{
	public class Bullet : GameObjectBase
	{
		#region Fields

		//delete below
		//private Rectangle rectangle;
		private Texture2D testingTexture;
		//delete above

		#endregion Fields

		#region Properties
		
		#endregion Properties

		#region Constructors

		public Bullet(XnaGame xnaXnaGame)
			: base(xnaXnaGame)
		{

		}

		#endregion Constructors

		#region Methods

		public override void Initialize()
		{
			DisplayOrder = 1;

			IsVisible = true;

			//testing
			//rectangle = new Rectangle(50, 50, 50, 50);
			testingTexture = new Texture2D(XnaGame.GraphicsDevice, 1, 1);
			testingTexture.SetData(new Color[] { Color.AliceBlue });
		}

		public override void Draw()
		{
			XnaGame.SpriteBatch.Draw(testingTexture, new Rectangle((int)PositionVector.X,(int)PositionVector.Y,50,50), Color.Purple);
		}

		public override void Update()
		{
			if (!XnaGame.ClientRectangle.Contains(new Point((int)PositionVector.X, (int)PositionVector.Y)))
			{
				IsVisible = false;
			}

			PositionVector += VelocityVector;
		}

		#endregion Methods

		#region Helper Methods



		#endregion Helper Methods
	}
}