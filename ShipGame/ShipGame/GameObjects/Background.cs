using System.Net.Sockets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShipGame.GameDisplay;
using ShipGame.GameObjects.BaseClass;

namespace ShipGame.GameObjects
{
	public class Background : GameObjectBase
	{
		#region Fields



		#endregion Fields

		#region Properties



		#endregion Properties

		#region Constructors

		public Background(XnaGame xnaGame): base(xnaGame)
		{
		}

		#endregion Constructors

		#region Methods

		public override void Initialize()
		{
			//Texture = XnaGame.Content.Load<Texture2D>(GameUtilities.GameConfig.BackgroundOneTextureName);

			InitializeRandomTexture();
			
			DisplayOrder = 0;

			IsVisible = true;
		}

		public override void Update()
		{
		}
		
		public override void Draw()
		{
			XnaGame.SpriteBatch.Draw(Texture, new Vector2(XnaGame.ClientRectangle.Left, XnaGame.ClientRectangle.Top), Color.White);
		}
		
		#endregion Methods

		#region Helper Methods

		private void InitializeRandomTexture()
		{
			int random = XnaGame.GameUtilities.Random.Next(1, 4);

			switch (random)
			{
				case 1:
					Texture = XnaGame.Content.Load<Texture2D>(GameUtilities.GameConfig.BackgroundOneTextureName);
					break;

				case 2:
					Texture = XnaGame.Content.Load<Texture2D>(GameUtilities.GameConfig.BackgroundTwoTextureName);
					break;

				case 3:
					Texture = XnaGame.Content.Load<Texture2D>(GameUtilities.GameConfig.BackgroundThreeTextureName);
					break;

				default:
					return;
			}
		}

		#endregion Helper Methods
	}
}