using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShipGame.GameDisplay;
using ShipGame.GameObjects.BaseClass;

namespace ShipGame.GameObjects
{
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

		#endregion Fields

		#region Properties

		#endregion Properties

		#region Constructors

		public Explosion(XnaGame xnaXnaGame)
			: base(xnaXnaGame)
		{
		}

		public Explosion(XnaGame xnaGame, Asteroid asteroid) : base(xnaGame)
		{
			Bounds = asteroid.Bounds;
		}

		#endregion Constructors

		#region Methods

		public override void Initialize()
		{
			Texture = GameUtilities.GameUtilities.ReturnSingleSpriteFrame(Texture,
				_textureRows,
				_textureColumns,
				SpriteSelectedFrame,
				true);

			DisplayOrder = 1;

			IsVisible = true;

			//delete below
			testingTexture = new Texture2D(XnaGame.GraphicsDevice, 1, 1);
			testingTexture.SetData(new Color[] { Color.AliceBlue });
			//delete above
		}

		public override void Draw()
		{
			/*XnaGame.SpriteBatch.Draw(
					Texture,
					PositionVector,
					null, //use whole texture
					Color.White, //tint
					RotationAngle,
					new Vector2(Texture.Height / 2, Texture.Width / 2), //origin of rotation
					_textureScale, //scale
					SpriteEffects.None,
					1.0f //layer depth, not used
				);*/

			//shows the bound boxes
			XnaGame.SpriteBatch.Draw(testingTexture, Bounds, Color.Purple);
		}

		public override void Update()
		{
			Bounds = GetBounds(_textureScale);

			RotationAngle += _rotationSpeed;

			PositionVector += VelocityVector;

			if (Health <= 0)
			{
				if (!_explosionStarted)
				{
					StartExplosion();
				}
				else
				{
					ContinueExplosion();
				}
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