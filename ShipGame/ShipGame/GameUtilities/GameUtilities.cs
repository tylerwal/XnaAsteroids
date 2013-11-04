using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShipGame.GameUtilities
{
	public class GameUtilities
	{
		#region Fields

		private Random _random;

		#endregion Fields

		#region Properties

		public Random Random
		{
			get
			{
				return _random;
			}
			set
			{
				_random = value;
			}
		}

		

		#endregion Properties

		#region Constructors

		public GameUtilities()
		{
			Random = new Random();
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

				tempRectangle.Inflate(-2, -2);

				tempList[i] = tempRectangle;
			}

			return tempList;
		}

		public static Texture2D ReturnSingleSpriteFrame(Texture2D originalTexture, int rows, int columns, int frameSelection, bool removeFrameLines)
		{
			IList<Rectangle> spriteRectangles = GetSpriteRectangles(originalTexture, rows, columns);

			if (removeFrameLines)
			{
				spriteRectangles = RemoveFrameLines(spriteRectangles);
			}

			Tuple<int, int> frameRectangeWidthAndHeight = GetSingleRectangleWidthAndHeight(spriteRectangles);

			Color[] pixels = new Color[frameRectangeWidthAndHeight.Item1 * frameRectangeWidthAndHeight.Item2];

			Texture2D croppedTexture2D = new Texture2D(originalTexture.GraphicsDevice, frameRectangeWidthAndHeight.Item1, frameRectangeWidthAndHeight.Item2);

			originalTexture.GetData(0, spriteRectangles[frameSelection], pixels, 0, pixels.Length);

			croppedTexture2D.SetData(pixels);

			return croppedTexture2D;
		}

		public Vector2 GetRandomVector(int lowerXBounds, int upperXboards, int lowerYBounds, int upperYBounds)
		{
			Vector2 randomVector = new Vector2();

			randomVector.X = Random.Next(lowerXBounds, upperXboards);

			randomVector.Y = Random.Next(lowerYBounds, upperYBounds);

			return randomVector;
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

		private static Tuple<int, int> GetSingleRectangleWidthAndHeight(IList<Rectangle> sourceRectangles)
		{
			Tuple<int, int> rectangleWidthHeigt = new Tuple<int, int>(
				sourceRectangles.First().Width,
				sourceRectangles.First().Height
				);

			return rectangleWidthHeigt;
		}
			

		#endregion Helper Methods
	}
}