using System;
using System.Windows.Forms;
using ShipGame.GameForms;

namespace ShipGame
{
	static class Program
	{

		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			using (GameForm mainWindowForm = new GameForm())
			{
				Application.Run(mainWindowForm);
			}
		}
	}
}

