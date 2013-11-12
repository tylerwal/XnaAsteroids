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

		public Dictionary<int, Tuple<string, int, int, int, float>> _asteroidSettings; 

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

		public Dictionary<int, Tuple<string, int, int, int, float>> AsteroidSettings
		{
			get
			{
				return _asteroidSettings;
			}
			set
			{
				_asteroidSettings = value;
			}
		}
		
		#endregion Properties

		#region Constructors

		public GameUtilities()
		{
			Random = new Random();

			AsteroidSettings = new Dictionary<int, Tuple<string, int, int, int, float>>();

			InitializeAsteroidSettings();
		}

		#endregion Constructors

		#region Methods
		
		/// <summary>
		/// Gets a single sprite frame from an image with multiple frames
		/// </summary>
		/// <param name="originalTexture"></param>
		/// <param name="rows"></param>
		/// <param name="columns"></param>
		/// <param name="frameSelection"></param>
		/// <param name="removeFrameLines"></param>
		/// <returns>A Sprite Texture</returns>
		public static Texture2D ReturnSingleSpriteFrame(Texture2D originalTexture, int rows, int columns, int frameSelection, bool removeFrameLines)
		{
			if ((rows * columns) == 1)
			{
				return originalTexture;
			}

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
		
		/// <summary>
		/// Gets a random vector based on int type lower and upper bounds
		/// </summary>
		/// <param name="lowerXBounds"></param>
		/// <param name="upperXboards"></param>
		/// <param name="lowerYBounds"></param>
		/// <param name="upperYBounds"></param>
		/// <returns>A random vector</returns>
		public Vector2 GetRandomVector(int lowerXBounds, int upperXboards, int lowerYBounds, int upperYBounds)
		{
			Vector2 randomVector = new Vector2();

			randomVector.X = Random.Next(lowerXBounds, upperXboards);

			randomVector.Y = Random.Next(lowerYBounds, upperYBounds);

			return randomVector;
		}

		/// <summary>
		/// Gets a random vector based on float type lower and upper bounds
		/// </summary>
		/// <param name="lowerXBounds"></param>
		/// <param name="upperXboards"></param>
		/// <param name="lowerYBounds"></param>
		/// <param name="upperYBounds"></param>
		/// <returns>A random vector</returns>
		public Vector2 GetRandomVector(float lowerXBounds, float upperXboards, float lowerYBounds, float upperYBounds)
		{
			Vector2 randomVector = new Vector2();

			randomVector.X = (float)Random.NextDouble() * (upperXboards - lowerXBounds) + lowerXBounds;

			randomVector.Y = (float)Random.NextDouble() * (upperYBounds - lowerYBounds) + lowerYBounds;

			return randomVector;
		}

		/// <summary>
		/// Gets a random boolean value
		/// </summary>
		/// <returns>random bool</returns>
		public bool GetRandomBool()
		{
			return (Random.Next(0, 6) > 3);
		}

		/// <summary>
		/// Transforms an input float to a float closer to zero
		/// </summary>
		/// <param name="input"></param>
		/// <param name="offset">Amount to move towards zero</param>
		/// <returns>Lower absolute value float</returns>
		public static float ShiftVector(float input, float offset)
		{
			if (input > 0)
			{
				return input += offset;
			}
			if (input < 0)
			{
				return input -= offset;
			}
			return input;
		}

		/// <summary>
		/// Transforms an input int to a int closer to zero
		/// </summary>
		/// <param name="input"></param>
		/// <param name="offset">Amount to move towards zero</param>
		/// <returns>Lower absolute value int</returns>
		public static Vector2 ShiftVector(Vector2 input, float offset)
		{
			Vector2 tempVector2 = input;

			tempVector2.X = ShiftVector(tempVector2.X, offset);

			tempVector2.Y = ShiftVector(tempVector2.Y, offset);

			return tempVector2;
		}

		/// <summary>
		/// Converts a point to a vector
		/// </summary>
		/// <param name="point"></param>
		/// <returns>Vector2</returns>
		public static Vector2 GetVectorFromPoint(Point point)
		{
			return new Vector2(point.X, point.Y);
		}

		/// <summary>
		/// Converts a vector to a point
		/// </summary>
		/// <param name="vector"></param>
		/// <returns>Point</returns>
		public static Point GetPointFromVector(Vector2 vector)
		{
			return new Point((int)vector.X, (int)vector.Y);
		}
		
		#endregion Methods

		#region Helper Methods

		/// <summary>
		/// Gets a list of rectangles for the sprite frames
		/// </summary>
		/// <param name="texture"></param>
		/// <param name="rows"></param>
		/// <param name="columns"></param>
		/// <returns>A list of rectangles</returns>
		private static IList<Rectangle> GetSpriteRectangles(Texture2D texture, int rows, int columns)
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

		/// <summary>
		/// Deflates a list of sprite rectangles to remove Sprite frame lines
		/// </summary>
		/// <param name="spriteRectangles"></param>
		/// <returns>A list of rectangles</returns>
		private static IList<Rectangle> RemoveFrameLines(IEnumerable<Rectangle> spriteRectangles)
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

		private void InitializeAsteroidSettings()
		{
			AsteroidSettings.Add(1, new Tuple<string, int, int, int, float>(
				GameConfig.AsteroidOneTextureName,
				GameConfig.AsteroidOneTextureRows,
				GameConfig.AsteroidOneTextureColumns,
				GameConfig.AsteroidOneSelectedFrame,
				GameConfig.AsteroidOneScale));

			AsteroidSettings.Add(2, new Tuple<string, int, int, int, float>(
				GameConfig.AsteroidTwoTextureName,
				GameConfig.AsteroidTwoTextureRows,
				GameConfig.AsteroidTwoTextureColumns,
				GameConfig.AsteroidTwoSelectedFrame,
				GameConfig.AsteroidTwoScale));

			AsteroidSettings.Add(3, new Tuple<string, int, int, int, float>(
				GameConfig.AsteroidThreeTextureName,
				GameConfig.AsteroidThreeTextureRows,
				GameConfig.AsteroidThreeTextureColumns,
				GameConfig.AsteroidThreeSelectedFrame,
				GameConfig.AsteroidThreeScale));

			AsteroidSettings.Add(4, new Tuple<string, int, int, int, float>(
				GameConfig.AsteroidFourTextureName,
				GameConfig.AsteroidFourTextureRows,
				GameConfig.AsteroidFourTextureColumns,
				GameConfig.AsteroidFourSelectedFrame,
				GameConfig.AsteroidFourScale));

			AsteroidSettings.Add(5, new Tuple<string, int, int, int, float>(
				GameConfig.AsteroidFiveTextureName,
				GameConfig.AsteroidFiveTextureRows,
				GameConfig.AsteroidFiveTextureColumns,
				GameConfig.AsteroidFiveSelectedFrame,
				GameConfig.AsteroidFiveScale));
		}

		#endregion Helper Methods
	}
}