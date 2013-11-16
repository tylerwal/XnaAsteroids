using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShipGame.GameDisplay;
using ShipGame.GameObjects.BaseClass;
using ShipGame.GameUtilities;
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
			DisplayOrder = 2;

			IsVisible = true;

			//testing
			testingTexture = new Texture2D(XnaGame.GraphicsDevice, 1, 1);
			testingTexture.SetData(new Color[] { Color.LightGreen });

		}

		public override void Draw()
		{
			XnaGame.SpriteBatch.Draw(testingTexture, new Rectangle((int)PositionVector.X,(int)PositionVector.Y,2,2), Color.LightGreen);
		}

		public override void Update()
		{
			Bounds = new Rectangle((int)PositionVector.X, (int)PositionVector.Y, 5, 5);

			if (!XnaGame.ClientRectangle.Contains(new Point((int)PositionVector.X, (int)PositionVector.Y)))
			{
				IsMarkedForDeletion = true;
			}

			GameObjectBase collidedObject = GetCollidedObject();

			if (collidedObject is Asteroid)
			{
				IsMarkedForDeletion = true;

				collidedObject.Health -= GameConfig.BulletDamage;
			}

			PositionVector += VelocityVector;
		}

		#endregion Methods

		#region Helper Methods



		#endregion Helper Methods
	}
}