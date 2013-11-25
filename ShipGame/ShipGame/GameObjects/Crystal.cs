using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShipGame.GameDisplay;
using ShipGame.GameObjects.BaseClass;

namespace ShipGame.GameObjects
{
	public class Crystal : GameObjectBase
	{
		#region Fields

		private float _rotationSpeed;

		private Random _random;
		
		private string _textureName;

		private int _textureRows;

		private int _textureColumns;

		private float _textureScale;

		private bool _explosionStarted;

		//delete below
		private Texture2D testingTexture;
		//delete above

		#endregion Fields

		#region Properties

		#endregion Properties

		#region Constructors

		public Crystal(XnaGame xnaXnaGame)
			: base(xnaXnaGame)
		{
			_random = XnaGame.GameUtility.Random;
		}

		#endregion Constructors

		#region Methods

		public override void Initialize()
		{
			Texture = XnaGame.Content.Load<Texture2D>(GameUtilities.GameConfig.CrystalTextureName);

			InitializeRandomTexture();

			RandomizeStart();

			DisplayOrder = 1;

			IsVisible = true;

			Health = GameUtilities.GameConfig.AsteroidStartingHealth;

			TerminalVelocity = GameUtilities.GameConfig.AsteroidTerminalVelocity;

			//delete below
			testingTexture = new Texture2D(XnaGame.GraphicsDevice, 1, 1);
			testingTexture.SetData(new Color[] { Color.AliceBlue });
			//delete above
		}

		public override void Draw()
		{
			XnaGame.SpriteBatch.Draw(
					Texture,
					PositionVector,
					null, //use whole texture
					Color.White, //tint
					RotationAngle,
					new Vector2(Texture.Height / 2, Texture.Width / 2), //origin of rotation
					_textureScale, //scale
					SpriteEffects.None,
					1.0f //layer depth, not used
				);

			//shows the bound boxes
			//XnaGame.SpriteBatch.Draw(testingTexture, Bounds, Color.Purple);
		}

		public override void Update()
		{
			Bounds = GetBounds(_textureScale);

			RotationAngle += _rotationSpeed;
			
			CollisionHandling();
			
			if (Health <= 0)
			{
				IsMarkedForDeletion = true;

				Explosion explosion = new Explosion(XnaGame, this);

				XnaGame.GameObjects.Add(explosion);

				explosion.Initialize();
			}
		}

		#endregion Methods

		#region Helper Methods

		#region Randomized Start Methods

		/// <summary>
		/// Randomizes the starting position, velocity, rotation, rotation speed, texture, texture scale (and health) for each Asteroid instantiation
		/// </summary>
		private void RandomizeStart()
		{
			do
			{
				PositionVector = GetRandomStartingPoint();
			}
			while (IsBoundsWithinAnotherObjectsBounds());

			RotationAngle = GetRandomStartingRotation();

			_rotationSpeed = GetRandomRotationSpeed();
		}

		/// <summary>
		/// Chooses an Asteroid texture randomly and plugs in the settings for that particular texture
		/// </summary>
		private void InitializeRandomTexture()
		{
			int random = _random.Next(1, 6);

			_textureName = asteroidSettingsTuple.Item1;

			_textureRows = asteroidSettingsTuple.Item2;

			_textureColumns = asteroidSettingsTuple.Item3;

			SpriteSelectedFrame = asteroidSettingsTuple.Item4;

			_textureScale = asteroidSettingsTuple.Item5;
		}

		/// <summary>
		/// Gets random starting rotation, otherwise all asteroids would start in the same orientation
		/// </summary>
		/// <returns>random float within 0 and 2PI</returns>
		private float GetRandomStartingRotation()
		{
			double randomRotation = _random.NextDouble() * ((Math.PI * 2));

			return (float)randomRotation;
		}

		/// <summary>
		/// Gets random rotation speed for start
		/// </summary>
		/// <returns>Random Velocity</returns>
		private float GetRandomRotationSpeed()
		{
			float rotationSpeed = _random.Next(0, 10) * .005f;

			if (XnaGame.GameUtility.GetRandomBool())
			{
				rotationSpeed *= -1;
			}

			return rotationSpeed;
		}

		#endregion Randomized Start Methods

		/// <summary>
		/// Methods that handles the collision detection and collision event handling.
		/// </summary>
		private void CollisionHandling()
		{
			GameObjectBase collidedObject = GetCollidedObject();

			if (collidedObject != null)
			{
				{
					Vector2 centerOfMass = (collidedObject.VelocityVector + VelocityVector) / 2;

					Vector2 normalizedVector = GameUtilities.GameUtilities.GetVectorFromPoint(collidedObject.Bounds.Center) - GameUtilities.GameUtilities.GetVectorFromPoint(Bounds.Center);

					normalizedVector.Normalize();

					VelocityVector -= centerOfMass;

					VelocityVector = Vector2.Reflect(VelocityVector, normalizedVector);

					VelocityVector += centerOfMass;
				}
			}
		}

		#endregion Helper Methods
	}
}