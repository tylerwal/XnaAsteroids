using ShipGame.Entities;
using ShipGame.GameDisplay;
using ShipGame.GameForms;
using ShipGame.GameObjects.BaseClass;
using ShipGame.GameUtilities;
using System.Linq;

namespace ShipGame.GameObjects
{
	
	public class GameStatUpdater : GameObjectBase
	{
		#region Fields

		private GameStatusControl _gameStatusControl;

		private GameStatRepository _gameStatRepository;

		private GameMessage _message;
		
		#endregion Fields

		#region Properties

		public GameStatusControl GameStatusControl
		{
			get
			{
				return _gameStatusControl;
			}
			set
			{
				_gameStatusControl = value;
			}
		}

		public GameStatRepository GameStatRepository
		{
			get
			{
				return _gameStatRepository;
			}
			set
			{
				_gameStatRepository = value;
			}
		}
		
		#endregion Properties

		#region Constructors

		public GameStatUpdater(XnaGame xnaXnaGame)
			: base(xnaXnaGame)
		{

		}

		#endregion Constructors

		#region Methods

		public override void Initialize()
		{
			IsVisible = false;

			GameStatRepository = XnaGame.GameStatRepository;

			GameStatRepository.AmmoLeft = GameConfig.StartingAmmo;

			GameStatusControl = ((GameForm)XnaGame.TopLevelControl).GameStatusBar;

			_message = XnaGame.GameObjects.OfType<GameMessage>().First();
		}

		public override void Draw()
		{
		}

		public override void Update()
		{
			UpdateAmmoLeft();
			
			UpdateNumberOfAsteroidsoLeft();

			UpdatePlayerHealth();

			UpdatePlayerScore();

			UpdatePlayerShield();
		}

		#endregion Methods

		#region Helper Methods

		private void UpdateAmmoLeft()
		{
			GameStatusControl.AmmoLeft = GameStatRepository.AmmoLeft;
		}

		private void UpdatePlayerScore()
		{
			GameStatusControl.Score = GameStatRepository.Score;
		}

		private void UpdateNumberOfAsteroidsoLeft()
		{
			GameStatRepository.AsteroidsLeft = XnaGame.GameObjects.OfType<Asteroid>().Count();
			GameStatusControl.AsteroidsLeft = GameStatRepository.AsteroidsLeft;
		}

		private void UpdatePlayerHealth()
		{
			GameStatRepository.Health = XnaGame.GameObjects.OfType<Ship>().First().Health;
			GameStatusControl.Health = GameStatRepository.Health;
		}

		private void UpdatePlayerShield()
		{
			int updatedShield = XnaGame.GameObjects.OfType<Shield>().First().Health;

			bool isShieldLow = (updatedShield < 10) && (GameStatRepository.Shield >= 10);

			GameStatRepository.Shield = updatedShield;
			GameStatusControl.Shield = GameStatRepository.Shield;

			if (isShieldLow)
			{
				_message.AddMessage(XnaGame.GlobalGameStopWatch.Elapsed, "Shield Low");
			}
		}

		#endregion Helper Methods
	}
}