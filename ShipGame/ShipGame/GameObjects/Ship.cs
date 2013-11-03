using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.VisualStyles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShipGame.GameDisplay;
using ShipGame.GameObjects.BaseClass;

namespace ShipGame.GameObjects
{
	public class Ship : GameObjectBase
	{
		#region Fields



		#endregion Fields

		#region Properties



		#endregion Properties

		#region Constructors

		public Ship(XNAGameDisplay xnaGameDisplay) : base(xnaGameDisplay)
		{
		}

		#endregion Constructors

		#region Methods

		public override void Initialize()
		{
			Texture = GameDisplay.Content.Load<Texture2D>("Ship");

			SpriteRectangles = GameUtilities.GameUtilities.GetSpriteRectangles(Texture, 2, 8);

			SpriteRectangles = GameUtilities.GameUtilities.RemoveFrameLines(SpriteRectangles);

			PositionVector = new Vector2(0, 0);

			TerminalVelocity = 4;
		}

		public override void Draw()
		{
			GameDisplay.SpriteBatch.Draw(Texture, PositionVector, SpriteRectangles[0], Color.White);
		}

		public override void Update()
		{
			Vector2 tempPosition = PositionVector;

			Vector2 tempVelocity = VelocityVector;

			if (GameDisplay.KeyboardCurrentState.IsKeyDown(Keys.W))
			{
				if (IsWithinVerticalNorthBounds())
				{
					if (!HasReachedTerminalYNegativeVelocity())
					{
						tempVelocity.Y--;
					}
				}
				else
				{
					tempVelocity.Y = 0;
				}
			}
			if (GameDisplay.KeyboardCurrentState.IsKeyDown(Keys.A))
			{
				if (IsWithinHorizontalWestBounds())
				{
					if (!HasReachedTerminalXNegativeVelocity())
					{
						tempVelocity.X--;
					}
				}
				else
				{
					tempVelocity.X = 0;
				}
				/*var test1 = IsWithinHorizontalEastBounds();
				var test2 = IsWithinHorizontalWestBounds();
				var test3 = IsWithinVerticalNorthBounds();
				var test4 = IsWithinVerticalSouthBounds();*/
			}
			if (GameDisplay.KeyboardCurrentState.IsKeyDown(Keys.S))
			{
				if (IsWithinVerticalSouthBounds())
				{
					if (!HasReachedTerminalYVelocity())
					{
						tempVelocity.Y++;
					}
				}
				else
				{
					tempVelocity.Y = 0;
				}
			}
			if (GameDisplay.KeyboardCurrentState.IsKeyDown(Keys.D))
			{
				if (IsWithinHorizontalEastBounds())
				{
					if (!HasReachedTerminalXVelocity())
					{
						tempVelocity.X++;
					}
				}
				else
				{
					tempVelocity.X = 0;
				}
			}

			tempPosition = Vector2.Add(tempPosition, tempVelocity);

			VelocityVector = tempVelocity;

			PositionVector = tempPosition;
		}

		#endregion Methods

		#region Helper Methods



		#endregion Helper Methods
	}
}
