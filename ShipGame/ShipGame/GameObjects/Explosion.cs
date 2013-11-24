using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShipGame.GameDisplay;
using ShipGame.GameObjects.BaseClass;

namespace ShipGame.GameObjects
{
	using ShipGame.GameUtilities;

	public class Explosion : GameObjectBase
	{
		#region Fields

		private float _rotationSpeed;

		private Random _random;

		/*private KeyValuePair<int, Tuple<string, int, int, int, float>> _asteroidSettings;*/

		private string _textureName;

		private int _textureRows;

		private int _textureColumns;

		private float _textureScale;

		private bool _explosionStarted;

		private TimeSpan _startingExplosionTime;

		//delete below
		private Texture2D testingTexture;
		//delete above

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

			//delete below
			testingTexture = new Texture2D(XnaGame.GraphicsDevice, 1, 1);
			testingTexture.SetData(new Color[] { Color.AliceBlue });
			//delete above
		}

		public override void Draw()
		{
			XnaGame.SpriteBatch.Draw(
				Texture,
				Bounds,
				_spriteRectangles[SpriteSelectedFrame],
				Color.White
				);

			/*//shows the bound boxes
			XnaGame.SpriteBatch.Draw(Texture, Bounds, Color.Purple);*/
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

		/// <summary>
		/// When the asteroid has zero health, this method starts the texture to an explosion texture.
		/// </summary>
		private void StartExplosion()
		{
			_startingExplosionTime = XnaGame.GlobalGameStopWatch.Elapsed;

			_explosionStarted = true;
		}

		/// <summary>
		/// Continues after the Start Explosion Method has set _explosionStarted to true and eventually marks the asteroid for deletion.
		/// </summary>
		private void ContinueExplosion()
		{
			TimeSpan elapsedTime = _startingExplosionTime - XnaGame.GlobalGameStopWatch.Elapsed;

			IsMarkedForDeletion = true;
		}

		#endregion Helper Methods
	}
}