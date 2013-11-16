using System.Windows.Forms;

namespace ShipGame.GameForms
{
	public partial class MainWindowForm : Form
	{
		public MainWindowForm()
		{
			InitializeComponent();

			/*XnaGame.MouseEnter += xnaGameDisplay_MouseEnter;

			XnaGame.MouseLeave += xnaGameDisplay_MouseLeave;*/

			gameStatusBar.GameStatsCriteria.Score = 50;

			gameStatusBar.SetScore(25);

			gameStatusBar.Health = 75;
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
