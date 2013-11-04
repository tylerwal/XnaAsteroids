namespace ShipGame.GameUtilities
{
	public static class GameSettings
	{
		#region General

		public const int GameUpdateTime = 20; 

		#endregion General

		#region Ship Constants

		public const string ShipTextureName = "Ship";

		public const int ShipTextureRows = 2;

		public const int ShipTextureColumns = 8;

		public const int ShipSelectedFrame = 4;

		public const float ShipBrakePower = .1f;

		public const float ShipTerminalVelocity = 2.5f;

		public const float ShipEnginePower = 1f;

		public const float ShipThrusterPower = .5f;

		public const float ShipScale = 1.25f;

		#endregion Ship Constants

		#region Asteroid Constants

		public const string AsteroidTextureName = "Asteroid";

		public const int AsteroidTextureRows = 2;

		public const int AsteroidTextureColumns = 3;

		public const int AsteroidSelectedFrame = 1;

		public const float AsteroidTerminalVelocity = 1.5f;

		public const float AsteroidScale = .75f;

		#endregion Asteroid Constants
	}
}