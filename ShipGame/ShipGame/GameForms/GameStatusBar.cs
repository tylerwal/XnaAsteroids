using System.Windows.Forms;
using ShipGame.Entities;

namespace GameProgrammingTest
{
	public partial class MainWindowMenu0 : UserControl
	{
		#region Fields

		private GameStats _gameStatsCriteria;

		#endregion Fields

		#region Properties

		public GameStats GameStatsCriteria
		{
			get
			{
				return _gameStatsCriteria;
			}
			set
			{
				_gameStatsCriteria = value;
			}
		}

		#endregion Properties

		public MainWindowMenu0()
		{
			InitializeComponent();

			_gameStatsCriteria = new GameStats();

			bsGameStats.DataSource = _gameStatsCriteria;

			_gameStatsCriteria.PlayerOneScore = 0;
			_gameStatsCriteria.PlayerTwoScore = 0;
		}
	}
}
