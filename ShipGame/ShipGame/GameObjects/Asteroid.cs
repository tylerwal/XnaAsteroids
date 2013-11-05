using System;
using System.Collections.Generic;
using System.Linq;
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

		private KeyValuePair<int, Tuple<string, int, int, int, float>> _asteroidSettings;

		private string _textureName;

		private int _textureRows;

		private int _textureColumns;

		private float _textureScale;

		//delete below
		private Rectangle rectangle;
		private Texture2D tesTexture2D;
		//delete above

		#endregion Fields

		#region Properties

		#endregion Properties

		#region Constructors

		public Asteroid(XnaGame xnaXnaGame)
			: base(xnaXnaGame)
		{
			_random = XnaGame.GameUtilities.Random;
		}

		#endregion Constructors

		#region Methods

		public override void Initialize()
		{
			RandomizeStart();
			
			Texture = GameUtilities.GameUtilities.ReturnSingleSpriteFrame(Texture,
				_textureRows,
				_textureColumns,
				SpriteSelectedFrame,
				true);

			DisplayOrder = 1;

			IsVisible = true;

			TerminalVelocity = GameUtilities.GameConfig.AsteroidTerminalVelocity;
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
		}

		public override void Update()
		{
			ApplyEndlessDisplay();

			Bounds = GetBounds(_textureScale);

			RotationAngle += _rotationSpeed;

			PositionVector += VelocityVector;

			GameObjectBase collidedObject = GetCollidedObject();

			if (collidedObject != null)
			{
				if (collidedObject.GetType() == this.GetType())
				{
					Vector2 collidedVelocity = collidedObject.VelocityVector;

					collidedVelocity = GameUtilities.GameUtilities.MoveTowardsZero(collidedVelocity, -0.0001f);

					Vector2 thisVelocity = VelocityVector;

					thisVelocity = GameUtilities.GameUtilities.MoveTowardsZero(thisVelocity, -0.0001f);

					collidedObject.VelocityVector = thisVelocity;

					VelocityVector = collidedVelocity;
				} 
			}

			MaintainTerminalVelocity();
		}

		#endregion Methods

		#region Helper Methods

		private void RandomizeStart()
		{
			InitializeRandomTexture();
			
			Texture = XnaGame.Content.Load<Texture2D>(_textureName);

			/*SpriteRectangles = GameUtilities.GameUtilities.GetSpriteRectangles(Texture,
				_textureRows,
				_textureColumns);

			SpriteRectangles = GameUtilities.GameUtilities.RemoveFrameLines(SpriteRectangles);*/

			do
			{
				PositionVector = GetRandomStartingPoint();
			}
			while (IsBoundsWithinAnotherObjectsBounds());

			RotationAngle = GetRandomStartingRotation();

			_rotationSpeed = GetRandomRotationSpeed();

			VelocityVector = GetRandomVelocity();
		}

		/// <summary>
		/// Chooses an Asteroid texture randomly and plugs in the settings for that particular texture
		/// </summary>
		private void InitializeRandomTexture()
		{
			int random = _random.Next(1, 6);

			KeyValuePair<int, Tuple<string, int, int, int, float>> asteroidSettingsKeyValuePair = XnaGame.GameUtilities.AsteroidSettings.Single(i => i.Key == random);

			Tuple<string, int, int, int, float> asteroidSettingsTuple = asteroidSettingsKeyValuePair.Value;

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

			if (XnaGame.GameUtilities.CoinFlip())
			{
				rotationSpeed *= -1;
			}

			return rotationSpeed;
		}

		/// <summary>
		/// Gets random velocity for start
		/// </summary>
		/// <returns>Random Vector</returns>
		private Vector2 GetRandomVelocity()
		{
			Vector2 velocity = XnaGame.GameUtilities.GetRandomVector(0f, 1.2f, 0f, 1.2f);

			if (XnaGame.GameUtilities.CoinFlip())
			{
				velocity.X *= -1;
			}
			if (XnaGame.GameUtilities.CoinFlip())
			{
				velocity.Y *= -1;
			}

			return velocity;
		}

		/// <summary>
		/// Keeps Velocity under a set Terminal Velocity
		/// </summary>
		private void MaintainTerminalVelocity()
		{
			Vector2 tempVelocity = VelocityVector;

			if (HasReachedTerminalXNegativeVelocity())
			{
				tempVelocity.X = (TerminalVelocity * -1);
			}
			if (HasReachedTerminalXPositiveVelocity())
			{
				tempVelocity.X = TerminalVelocity;
			}
			if (HasReachedTerminalYNegativeVelocity())
			{
				tempVelocity.Y = (TerminalVelocity * -1);
			}
			if (HasReachedTerminalYPositiveVelocity())
			{
				tempVelocity.Y = TerminalVelocity;
			}

			VelocityVector = tempVelocity;
		}

		#endregion Helper Methods
	}
}