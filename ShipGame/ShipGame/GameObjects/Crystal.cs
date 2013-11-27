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
		
		private int _crystalTypeId;

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

			_textureScale = GameUtilities.GameConfig.CrystalScale;

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
			//XnaGame.SpriteBatch.Draw(Texture, new Rectangle((int)PositionVector.X, (int)PositionVector.Y, 50, 50), Color.Tomato);
		}

		public override void Update()
		{
			Bounds = GetBounds(_textureScale);

			RotationAngle += _rotationSpeed;
			
			Ship collidedShip = GetCollidedObject() as Ship;

			if (collidedShip != null)
			{
				HandleCrystalTypes(collidedShip);

				IsMarkedForDeletion = true;
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
			PositionVector = GetRandomStartingPoint();

			RotationAngle = GetRandomStartingRotation();
			
			_rotationSpeed = GetRandomRotationSpeed();
		}

		/// <summary>
		/// Chooses an Asteroid texture randomly and plugs in the settings for that particular texture
		/// </summary>
		private void InitializeRandomTexture()
		{
			int random = _random.Next(0, 20);

			Texture = GameUtilities.GameUtilities.ReturnSingleSpriteFrame(
				Texture,
				GameUtilities.GameConfig.CrystalTextureRows,
				GameUtilities.GameConfig.CrystalTextureColumns,
				random,
				false
				);

			_crystalTypeId = ((random / GameUtilities.GameConfig.CrystalTextureColumns) % GameUtilities.GameConfig.CrystalTextureRows) + 1;
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

		private void HandleCrystalTypes(Ship ship)
		{
			string boostType = string.Empty;

			int boostAmount = 0;

			switch (_crystalTypeId)
			{
				case (int)GameUtilities.CrystalEnum.RedCrystal:
					boostType = GameUtilities.GameConfig.RedCrystalType;
					boostAmount = GameUtilities.GameConfig.RedCrystalAmount;
					break;
				case (int)GameUtilities.CrystalEnum.GoldCrystal:
					boostType = GameUtilities.GameConfig.GoldCrystalType;
					boostAmount = GameUtilities.GameConfig.GoldCrystalAmount;
					break;
				case (int)GameUtilities.CrystalEnum.BlueCrystal:
					boostType = GameUtilities.GameConfig.BlueCrystalType;
					boostAmount = GameUtilities.GameConfig.BlueCrystalAmount;
					break;
				case (int)GameUtilities.CrystalEnum.GreenCrystal:
					boostType = GameUtilities.GameConfig.GreenCrystalType;
					boostAmount = GameUtilities.GameConfig.GreenCrystalAmount;
					break;
				case (int)GameUtilities.CrystalEnum.GreyCrystal:
					boostType = GameUtilities.GameConfig.GreyCrystalType;
					boostAmount = GameUtilities.GameConfig.GreyCrystalAmount;
					break;
			}

			BoostShip(ship, boostType, boostAmount);
		}

		private void BoostShip(Ship ship, string boostType, int boostAmount)
		{
			switch (boostType)
			{
				case "Ammo":
					XnaGame.GameObjects.OfType<GameStatUpdater>().First().GameStatRepository.AmmoLeft += boostAmount;
					break;
				case "Health":
					ship.Health += boostAmount;
					break;
				case "Score":
					XnaGame.GameObjects.OfType<GameStatUpdater>().First().GameStatRepository.Score += boostAmount;
					break;
			}
		}

		#endregion Helper Methods
	}
}