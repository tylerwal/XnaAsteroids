using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShipGame.GameDisplay;
using ShipGame.GameObjects.BaseClass;
using System.Collections.Generic;

namespace ShipGame.GameObjects
{
	using ShipGame.GameUtilities;

	public class Explosion : GameObjectBase
	{
		#region Fields
		
		private IList<Rectangle> _spriteRectangles;

		#endregion Fields

		#region Properties

		#endregion Properties

		#region Constructors

		public Explosion(XnaGame xnaXnaGame)
			: base(xnaXnaGame)
		{
		}

		public Explosion(XnaGame xnaGame, Asteroid asteroid)
			: base(xnaGame)
		{
			Bounds = asteroid.Bounds;
		}

		#endregion Constructors

		#region Methods

		public override void Initialize()
		{
			Texture = XnaGame.Content.Load<Texture2D>(GameConfig.ExplosionTextureName);

			_spriteRectangles = GameUtilities.GetSpriteRectangles(
				Texture,
				GameConfig.ExplosionTextureRows,
				GameConfig.ExplosionTextureColumns
				);

			DisplayOrder = 1;

			IsVisible = true;

			SpriteSelectedFrame = 0;
		}

		public override void Draw()
		{
			XnaGame.SpriteBatch.Draw(
				Texture,
				Bounds,
				_spriteRectangles[SpriteSelectedFrame],
				Color.White
				);
		}

		public override void Update()
		{
			if (SpriteSelectedFrame < 24)
			{
				SpriteSelectedFrame++;
			}
			else
			{
				IsMarkedForDeletion = true;
			}
		}

		#endregion Methods

		#region Helper Methods

		#endregion Helper Methods
	}
}