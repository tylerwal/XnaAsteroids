using System;
using System.Windows.Forms;
using ShipGame.Entities;

namespace ShipGame.GameForms
{
	using Microsoft.Xna.Framework;

	using ShipGame.GameUtilities;

	using Color = System.Drawing.Color;

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
				dtlAmmoLeft.Text = value.ToString();
			}
		}

		public int Score
		{
			set
			{
				dtlScore.Text = value.ToString();
			}
		}

		public int AsteroidsLeft
		{
			set
			{
				dtlAsteroidsLeft.Text = value.ToString();
			}
		}

		#endregion Properties

		public GameStatusControl()
		{
			InitializeComponent();
		}
	}
}
