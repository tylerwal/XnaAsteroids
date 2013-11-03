using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShipGame.GameUtilities
{
	public class GameUtilities
	{
		#region Fields



		#endregion Fields

		#region Properties



		#endregion Properties

		#region Constructors

		public GameUtilities()
		{
			
		}

		#endregion Constructors

		#region Methods

		public static IList<Rectangle> GetSpriteRectangles(Texture2D texture, int rows, int columns)
		{
			IList<Rectangle> spriteRectangles = new List<Rectangle>(rows * columns);

			int frameHeight = GetFrameHeight(texture, rows);

			int frameWidth = GetFrameWidth(texture, columns);

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					Rectangle currentFrame = new Rectangle(frameWidth * j, frameHeight * i, frameWidth, frameHeight);
					spriteRectangles.Add(currentFrame);
				}
			}

			return spriteRectangles;
		}

		public static IList<Rectangle> RemoveFrameLines(IEnumerable<Rectangle> spriteRectangles)
		{
			IList<Rectangle> tempList = spriteRectangles.ToList();

			for (int i = 0; i < tempList.Count(); i++)
			{
				Rectangle tempRectangle = tempList[i];

				tempRectangle.Inflate(-1, -1);

				tempList[i] = tempRectangle;
			}

			return tempList;
		}

		#endregion Methods

		#region Helper Methods

		private static int GetFrameWidth(Texture2D texture, int columns)
		{
			return texture.Width / columns;
		}

		private static int GetFrameHeight(Texture2D texture, int rows)
		{
			return texture.Height / rows;
		}

		#endregion Helper Methods
	}
}