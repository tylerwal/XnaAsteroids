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
		}

		#region Event Handlers
		
		#endregion Event Handlers
	}
}
