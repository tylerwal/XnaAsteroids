using System.Windows.Forms;

namespace ShipGame.GameForms
{
	public partial class GameForm : Form
	{
		#region Fields

		 

		#endregion Fields

		#region Properties

		public GameStatusControl GameStatusBar
		{
			get
			{
				return gameStatusBar;
			}
			set
			{
				gameStatusBar = value;
			}
		}
		
		#endregion Properties

		public GameForm()
		{
			InitializeComponent();

			/*XnaGame.MouseEnter += xnaGameDisplay_MouseEnter;

			XnaGame.MouseLeave += xnaGameDisplay_MouseLeave;*/

			/*gameStatusBar.GameStatsCriteria.Score = 50;*/

			/*gameStatusBar.SetScore(25);*/

			GameStatusBar.Health = 75;

			GameStatusBar.Score = 10000;
		}

		#region Event Handlers

		/*void xnaGameDisplay_MouseLeave(object sender, EventArgs e)
		{
			Cursor.Show();
		}

		void xnaGameDisplay_MouseEnter(object sender, EventArgs e)
		{
			Cursor.Hide();
		} */

		#endregion Event Handlers
	}
}
