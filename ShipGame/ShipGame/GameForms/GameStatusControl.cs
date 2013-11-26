using System;
using System.Windows.Forms;
using ShipGame.Entities;

namespace ShipGame.GameForms
{
	using ShipGame.GameUtilities;

	public partial class GameStatusControl : UserControl
	{
		#region Fields
		
		#endregion Fields

		#region Properties
		
		public int Health
		{
			set
			{
				if (value >= 0)
				{
					pbPlayerOneHealth.Value = value;
				}
				else
				{
					pbPlayerOneHealth.Value = 0;
				}
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
		}
	}
}
