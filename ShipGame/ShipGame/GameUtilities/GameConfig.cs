
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

		public const float MessageScreenTime = 2f;
		
		#endregion General

		#region Ship Constants

		public const string ShipTextureName = "Ship";

		public const int ShipTextureRows = 2;

		public const int ShipTextureColumns = 8;

		public const int ShipSelectedFrame = 4;

		public const float ShipBrakePower = .09f;

		public const float ShipTerminalVelocity = 3.5f;

		public const float ShipEnginePower = 1f;

		public const float ShipThrusterPower = .5f;

		public const float ShipScale = 1.25f;

		public const int ShipStartingHealth = 100;

		public const int ShipTotalMaxHealth = 100;

		#endregion Ship Constants

		#region Shield Constants

		public const string ShieldTextureName = "Shield";

		public const int ShieldStartingHealth = 100;

		public const int ShieldMaxHealth = 100;

		#endregion Shield Constants

		#region Bullet Constants

		public const float BulletReloadSpeed = 0.02f;

		public const int BulletSpeed = 7;

		public const int BulletDamage = 1;

		public const int StartingAmmo = 500;

		public const int LowBulletFirstWarningNumber = 100;

		public const int LowBulletSecondWarningNumber = 50;

		public const string LowBulletFirstWarningText = "-!Warning!-\nRunning Low On Ammo\n-!Warning!-";

		public const string LowBulletSecondWarningText = "--!!Danger!!--\nCritically Low On Ammo\n--!!Danger!!--";

		#endregion Bullet Constants

		#region Asteroid Constants

		public const float AsteroidTerminalVelocity = 1.5f;

		public const int AsteroidStartingHealth = 25;

		public const int NumberOfLevelOneAsteroids = 10;
		
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

		#region Explosion Constants

		public const string ExplosionTextureName = "Explosion";

		public const int ExplosionTextureRows = 5;

		public const int ExplosionTextureColumns = 5;

		#endregion Explosion Constants

		#region Crystal Constants

		public const string CrystalTextureName = "Crystal";

		public const int NumberOfLevelOneCrystals = 10;

		public const int CrystalTextureRows = 5;

		public const int CrystalTextureColumns = 4;

		public const float CrystalScale = 1.2f;

		public const string RedCrystalType = "Ammo";
		public const int RedCrystalAmount = 100;

		public const string GoldCrystalType = "Ammo";
		public const int GoldCrystalAmount = 200;

		public const string BlueCrystalType = "Health";
		public const int BlueCrystalAmount = 50;

		public const string GreenCrystalType = "Shield";
		public const int GreenCrystalAmount = 50;

		public const string GreyCrystalType = "Score";
		public const int GreyCrystalAmount = 1000;

		#endregion Crystal Constants
	}
}