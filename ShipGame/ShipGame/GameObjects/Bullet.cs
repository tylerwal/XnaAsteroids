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
		
		private Color _textureTint;

		#endregion Fields

		#region Properties

		public new Color TextureTint 
		{
			get
			{
				return _textureTint;
			}
			set
			{
				_textureTint = value;
			}
		}

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

			Texture = new Texture2D(XnaGame.GraphicsDevice, 1, 1);
			Texture.SetData(new Color[] { Color.White });

			//position comes from ship center
			//have to account for width/height of bullet for new position
			PositionVector = PositionVector - new Vector2(.5f, .5f);
		}
		public override void Draw()
		{
			XnaGame.SpriteBatch.Draw(Texture, Bounds, TextureTint);
		}

		public override void Update()
		{
			Bounds = new Rectangle((int)PositionVector.X, (int)PositionVector.Y, 2, 2);

			//delete if goes off screen
			if (!XnaGame.ClientRectangle.Contains(new Point((int)PositionVector.X, (int)PositionVector.Y)))
			{
				IsMarkedForDeletion = true;
			}
			
			Asteroid collidedAsteroid = GetCollidedObject() as Asteroid;

			if (collidedAsteroid != null)
			{
				IsMarkedForDeletion = true;

				collidedAsteroid.Health -= GameConfig.BulletDamage;

				XnaGame.GameStatRepository.Score += 10;
			}

			PositionVector += VelocityVector;
		}

		#endregion Methods

		#region Helper Methods



		#endregion Helper Methods
	}
}