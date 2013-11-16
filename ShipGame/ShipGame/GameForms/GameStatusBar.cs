using System;
using System.Windows.Forms;
using ShipGame.Entities;

namespace ShipGame.GameForms
{
	public partial class MainWindowMenu : UserControl
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

		public int Health
		{
			set
			{
				pbPlayerOneHealth.Value = value;
			}
		}

		#endregion Properties

		public MainWindowMenu()
		{
			InitializeComponent();

			GameStatsCriteria = new GameStats();

			GameStatsCriteria.Score = 0;

			bsGameStats.DataSource = GameStatsCriteria;

			((GameStats)bsGameStats.DataSource).PlayerOneHealth = 50;

			pbPlayerOneHealth.Value = 50;
		}

		#region Methods

		public void SetScore(int score)
		{
			txtPlayerOneScore.Text = score.ToString();
		}

		#endregion Methods
	}
}
