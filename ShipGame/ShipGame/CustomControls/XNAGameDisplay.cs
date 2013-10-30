using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ShipGame.CustomControls
{
	public class XNAGameDisplay : WinFormsGraphicsDevice.GraphicsDeviceControl
	{
		#region Fields

		private ContentManager _contentManager;

		private SpriteBatch _spriteBatch;

		#endregion Fields

		#region Properties



		#endregion Properties

		#region Constructors

		public XNAGameDisplay()
		{
			
		}

		#endregion Constructors

		#region Overrides

		protected override void Initialize()
		{
			_contentManager = new ContentManager(Services, "Content");

			_spriteBatch = new SpriteBatch(GraphicsDevice);
		}

		protected override void Draw()
		{
			GraphicsDevice.Clear(Color.Blue);
		}

		#endregion Overrides

		#region Methods



		#endregion Methods

		#region Helper Methods



		#endregion Helper Methods
	}
}