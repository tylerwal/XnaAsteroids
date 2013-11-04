using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
