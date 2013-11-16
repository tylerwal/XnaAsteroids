using System;
using System.Collections;
using System.Collections.Generic;

namespace ShipGame.GameUtilities
{
	public static class GameConfig
	{
		#region General

		public const int GameUpdateTime = 20;

		public const string ContentManagerName = "Content";

		public const string BackgroundOneTextureName = "SpaceBackground";

		public const string BackgroundTwoTextureName = "SpaceBackground2";

		public const string BackgroundThreeTextureName = "SpaceBackground3";

		#endregion General

		#region Ship Constants

		public const string ShipTextureName = "Ship";

		public const int ShipTextureRows = 2;

		public const int ShipTextureColumns = 8;

		public const int ShipSelectedFrame = 4;

		public const float ShipBrakePower = .09f;

		public const float ShipTerminalVelocity = 2.5f;

		public const float ShipEnginePower = 1f;

		public const float ShipThrusterPower = .5f;

		public const float ShipScale = 1.25f;

		public const int ShipStartingHealth = 100;

		#endregion Ship Constants

		#region Bullet Constants

		public const float BulletReloadSpeed = 0.02f;

		public const int BulletSpeed = 6;

		public const int BulletDamage = 1;

		#endregion Bullet Constants

		#region Asteroid Constants

		public const float AsteroidTerminalVelocity = 1.5f;

		public const int AsteroidStartingHealth = 25;
		
		#region AsteroidOne

		public const string AsteroidOneTextureName = "Asteroid1";

		public const int AsteroidOneTextureRows = 2;

		public const int AsteroidOneTextureColumns = 3;

		public const int AsteroidOneSelectedFrame = 2;

		public const float AsteroidOneScale = .75f; 

		#endregion AsteroidOne

		#region AsteroidTwo

		public const string AsteroidTwoTextureName = "Asteroid2";

		public const int AsteroidTwoTextureRows = 1;

		public const int AsteroidTwoTextureColumns = 1;

		public const int AsteroidTwoSelectedFrame = 1;

		public const float AsteroidTwoScale = .5f;

		#endregion AsteroidTwo

		#region AsteroidThree

		public const string AsteroidThreeTextureName = "Asteroid3";

		public const int AsteroidThreeTextureRows = 1;

		public const int AsteroidThreeTextureColumns = 1;

		public const int AsteroidThreeSelectedFrame = 1;

		public const float AsteroidThreeScale = .5f;

		#endregion AsteroidThree

		#region AsteroidFour

		public const string AsteroidFourTextureName = "Asteroid4";

		public const int AsteroidFourTextureRows = 1;

		public const int AsteroidFourTextureColumns = 1;

		public const int AsteroidFourSelectedFrame = 1;

		public const float AsteroidFourScale = .25f;

		#endregion AsteroidFour

		#region AsteroidFive

		public const string AsteroidFiveTextureName = "Asteroid5";

		public const int AsteroidFiveTextureRows = 1;

		public const int AsteroidFiveTextureColumns = 1;

		public const int AsteroidFiveSelectedFrame = 1;

		public const float AsteroidFiveScale = .2f;

		#endregion AsteroidFive

		#endregion Asteroid Constants
	}
}