using System;
using System.Windows.Forms;
using ShipGame.Entities;

namespace ShipGame.GameForms
{
	public partial class GameStatusControl : UserControl
	{
		#region Fields
		
		#endregion Fields

		#region Properties
		
		public int Health
		{
			set
			{
				pbPlayerOneHealth.Value = value;
			}
		}

		public int AmmoLeft
		{
			set
			{
				txtAmmoLeft.Text = value.ToString();
			}
		}

		public int Score
		{
			set
			{
				txtScore.Text = value.ToString();
			}
		}

		public int AsteroidsLeft
		{
			set
			{
				txtAsteroidsLeft.Text = value.ToString();
			}
		}

		#endregion Properties

		public GameStatusControl()
		{
			InitializeComponent();

			/*GameStatsCriteria = new GameStats();

			GameStatsCriteria.Score = 0;

			bsGameStats.DataSource = GameStatsCriteria;

			((GameStats)bsGameStats.DataSource).PlayerOneHealth = 50;

			pbPlayerOneHealth.Value = 50;*/
		}
	}
}
