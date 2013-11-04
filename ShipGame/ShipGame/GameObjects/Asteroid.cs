using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShipGame.GameDisplay;
using ShipGame.GameObjects.BaseClass;

namespace ShipGame.GameObjects
{
	public class Asteroid : GameObjectBase
	{
		#region Fields

		private float _rotationSpeed;

		private Random _random;

		#endregion Fields

		#region Properties

		#endregion Properties

		#region Constructors

		public Asteroid(XnaGame xnaGame)
			: base(xnaGame)
		{
		}

		#endregion Constructors

		#region Methods

		public override void Initialize()
		{
			SpriteSelectedFrame = GameUtilities.GameConfig.AsteroidSelectedFrame;

			Texture = GameDisplay.Content.Load<Texture2D>(GameUtilities.GameConfig.AsteroidTextureName);

			SpriteRectangles = GameUtilities.GameUtilities.GetSpriteRectangles(Texture,
				GameUtilities.GameConfig.AsteroidTextureRows,
				GameUtilities.GameConfig.AsteroidTextureColumns);

			SpriteRectangles = GameUtilities.GameUtilities.RemoveFrameLines(SpriteRectangles);

			Texture = GameUtilities.GameUtilities.ReturnSingleSpriteFrame(Texture,
				GameUtilities.GameConfig.AsteroidTextureRows,
				GameUtilities.GameConfig.AsteroidTextureColumns,
				SpriteSelectedFrame,
				true);

			DisplayOrder = 1;

			IsVisible = true;

			_random = GameDisplay.GameUtilities.Random;

			PositionVector = GetRandomStartingPoint();

			RotationAngle = GetRandomStartingRotation();

			_rotationSpeed = GetRandomRotationSpeed();

			VelocityVector = GetRandomVelocity();
		}

		public override void Draw()
		{
			GameDisplay.SpriteBatch.Draw(
					Texture,
					PositionVector,
					null, //use whole texture
					Color.White, //tint
					RotationAngle,
					new Vector2(Height / 2, Width / 2), //origin of rotation
					GameUtilities.GameConfig.AsteroidScale, //scale
					SpriteEffects.None,
					1.0f //layer depth, not used
				);
		}

		public override void Update()
		{
			ApplyEndlessDisplay();

			RotationAngle += _rotationSpeed;

			PositionVector += VelocityVector;
		}

		#endregion Methods

		#region Helper Methods

		private Vector2 GetRandomStartingPoint()
		{
			return GameDisplay.GameUtilities.GetRandomVector(
				GameDisplay.ClientRectangle.Left,
				GameDisplay.ClientRectangle.Right,
				GameDisplay.ClientRectangle.Top,
				GameDisplay.ClientRectangle.Bottom
				);
		}

		private float GetRandomStartingRotation()
		{
			double randomRotation = _random.NextDouble() * ((Math.PI * 2));

			return (float)randomRotation;
		}

		private float GetRandomRotationSpeed()
		{
			float rotationSpeed = _random.Next(0, 10) * .005f;

			if (GameDisplay.GameUtilities.CoinFlip())
			{
				rotationSpeed *= -1;
			}

			return rotationSpeed;
		}

		private Vector2 GetRandomVelocity()
		{
			Vector2 velocity = GameDisplay.GameUtilities.GetRandomVector(0f, 1.2f, 0f, 1.2f);

			if (GameDisplay.GameUtilities.CoinFlip())
			{
				velocity.X *= -1;
			}
			if (GameDisplay.GameUtilities.CoinFlip())
			{
				velocity.Y *= -1;
			}

			return velocity;
		}

		#endregion Helper Methods
	}
}