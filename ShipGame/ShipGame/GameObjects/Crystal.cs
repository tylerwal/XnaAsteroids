using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShipGame.GameDisplay;
using ShipGame.GameObjects.BaseClass;
using ShipGame.GameUtilities;
using System;
using System.Linq;

namespace ShipGame.GameObjects
{
	using ShipGame.Entities;

	public class Crystal : GameObjectBase
	{
		#region Fields

		private float _rotationSpeed;

		private Random _random;

		private float _textureScale;
		
		private int _crystalTypeId;

		private GameStatRepository _gameStatRepository;

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
			Texture = XnaGame.Content.Load<Texture2D>(GameConfig.CrystalTextureName);

			InitializeRandomTexture();

			RandomizeStart();

			_textureScale = GameConfig.CrystalScale;

			DisplayOrder = 1;

			IsVisible = true;

			Health = GameConfig.AsteroidStartingHealth;

			TerminalVelocity = GameConfig.AsteroidTerminalVelocity;

			_gameStatRepository = XnaGame.GameObjects.OfType<GameStatUpdater>().First().GameStatRepository;

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
					null, 
					TextureTint,
					RotationAngle,
					new Vector2(Texture.Height / 2, Texture.Width / 2), 
					_textureScale, 
					SpriteEffects.None,
					1.0f 
				);

			//shows the bound boxes
			//XnaGame.SpriteBatch.Draw(testingTexture, Bounds, Color.Purple);
		}

		public override void Update()
		{
			Bounds = GetBounds(_textureScale);

			RotationAngle += _rotationSpeed;
			
			Ship collidedShip = GetCollidedObject() as Ship;

			if (collidedShip != null)
			{
				string boostType = HandleCrystalTypes(collidedShip);

				string crystalMessage = string.Concat(StringEnum.GetStringValue((CrystalEnum)_crystalTypeId), " : ", boostType);
				
				XnaGame.GameObjects.OfType<GameMessage>().First().AddMessage(XnaGame.GlobalGameStopWatch.Elapsed, crystalMessage);

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
				GameConfig.CrystalTextureRows,
				GameConfig.CrystalTextureColumns,
				random,
				false
				);

			_crystalTypeId = ((random / GameConfig.CrystalTextureColumns) % GameConfig.CrystalTextureRows) + 1;
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

		private string HandleCrystalTypes(Ship ship)
		{
			string boostType = string.Empty;

			int boostAmount = 0;

			switch (_crystalTypeId)
			{
				case (int)CrystalEnum.RedCrystal:
					boostType = GameConfig.RedCrystalType;
					boostAmount = GameConfig.RedCrystalAmount;
					break;
				case (int)CrystalEnum.GoldCrystal:
					boostType = GameConfig.GoldCrystalType;
					boostAmount = GameConfig.GoldCrystalAmount;
					break;
				case (int)CrystalEnum.BlueCrystal:
					boostType = GameConfig.BlueCrystalType;
					boostAmount = GameConfig.BlueCrystalAmount;
					break;
				case (int)CrystalEnum.GreenCrystal:
					boostType = GameConfig.GreenCrystalType;
					boostAmount = GameConfig.GreenCrystalAmount;
					break;
				case (int)CrystalEnum.GreyCrystal:
					boostType = GameConfig.GreyCrystalType;
					boostAmount = GameConfig.GreyCrystalAmount;
					break;
			}

			BoostShip(ship, boostType, boostAmount);

			return string.Concat(boostType, " ", boostAmount);
		}

		private void BoostShip(Ship ship, string boostType, int boostAmount)
		{
			switch (boostType)
			{
				case "Ammo":
					_gameStatRepository.AmmoLeft += boostAmount;
					break;
				case "Health":
					ship.Health += boostAmount;
					break;
				case "Score":
					_gameStatRepository.Score += boostAmount;
					break;
				case "Shield":
					XnaGame.GameObjects.OfType<Shield>().First().Health += boostAmount;
					break;
			}
		}

		#endregion Helper Methods
	}
}