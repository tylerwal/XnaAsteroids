using System.Linq;
using ShipGame.Entities;
using ShipGame.GameDisplay;
using ShipGame.GameForms;
using ShipGame.GameObjects.BaseClass;

namespace ShipGame.GameObjects
{
	public class GameStatUpdater : GameObjectBase
	{
		#region Fields

		private GameStatusControl _gameStatusControl;

		private GameStatRepository _gameStatRepository;
		
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

			GameStatusControl = ((GameForm)XnaGame.TopLevelControl).GameStatusBar;
		}

		public override void Draw()
		{
		}

		public override void Update()
		{
			UpdateNumberOfAsteroidsoLeft();

			UpdatePlayerHealth();

			UpdatePlayerScore();
			
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

		#endregion Helper Methods
	}
}