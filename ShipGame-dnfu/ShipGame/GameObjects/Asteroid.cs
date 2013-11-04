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
			SpriteSelectedFrame = GameUtilities.GameSettings.AsteroidSelectedFrame;

			Texture = GameDisplay.Content.Load<Texture2D>(GameUtilities.GameSettings.AsteroidTextureName);

			SpriteRectangles = GameUtilities.GameUtilities.GetSpriteRectangles(Texture,
				GameUtilities.GameSettings.AsteroidTextureRows,
				GameUtilities.GameSettings.AsteroidTextureColumns);

			SpriteRectangles = GameUtilities.GameUtilities.RemoveFrameLines(SpriteRectangles);

			Texture = GameUtilities.GameUtilities.ReturnSingleSpriteFrame(Texture,
				GameUtilities.GameSettings.AsteroidTextureRows,
				GameUtilities.GameSettings.AsteroidTextureColumns,
				SpriteSelectedFrame,
				true);

			DisplayOrder = 1;

			IsVisible = true;

			_random = GameDisplay.GameUtilities.Random;

			PositionVector = GetRandomStartingPoint();

			RotationAngle = GetRandomStartingRotation();

			_rotationSpeed = GetRandomRotationSpeed();
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
					GameUtilities.GameSettings.AsteroidScale, //scale
					SpriteEffects.None,
					1.0f //layer depth, not used
				);
		}

		public override void Update()
		{
			ApplyEndlessDisplay();

			RotationAngle += _rotationSpeed;
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
			double randomRotation = _random.NextDouble() * ((Math.PI * 2) - 0d);

			return (float)randomRotation;
		}

		private float GetRandomRotationSpeed()
		{
			float rotationSpeed = _random.Next(0, 10) * .005f;

			if (_random.Next(0, 6) > 3)
			{
				rotationSpeed *= -1;
			}

			return rotationSpeed;
		}

		#endregion Helper Methods
	}
}