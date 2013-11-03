using System;
using System.CodeDom.Compiler;
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

		private int _previousMouseX;

		private int _previousMouseY;

		private float _brakePower;

		private float _enginePower;

		private float _thrusterPower;

		#endregion Fields

		#region Properties



		#endregion Properties

		#region Constructors

		public Ship(XNAGameDisplay xnaGameDisplay) : base(xnaGameDisplay)
		{
			//start ship in center
			Vector2 tempVector2 = new Vector2(GameDisplay.ClientRectangle.Width / 2, GameDisplay.ClientRectangle.Height / 2);
			PositionVector = tempVector2;

			TerminalVelocity = 2.5f;
			_brakePower = .1f;
			_enginePower = 1f;
			_thrusterPower = .5f;
		}

		#endregion Constructors

		#region Methods

		public override void Initialize()
		{
			Texture = GameDisplay.Content.Load<Texture2D>("Ship");

			SpriteRectangles = GameUtilities.GameUtilities.GetSpriteRectangles(Texture, 2, 8);

			SpriteRectangles = GameUtilities.GameUtilities.RemoveFrameLines(SpriteRectangles);

			//set starting mouse point
			MouseState mouseState = Mouse.GetState();

			_previousMouseX = mouseState.X;

			RotationAngle = 0;
		}

		public override void Draw()
		{
			GameDisplay.SpriteBatch.Draw(
					Texture,
					PositionVector,
					SpriteRectangles[0], //source rectangle
					Color.White, //tint
					RotationAngle/* + (float)(Math.PI/2)*/,
					new Vector2(Height / 2, Width / 2), //origin of rotation
					1.0f, //scale
					SpriteEffects.None,
					1.0f
				);

			GameDisplay.SpriteBatch.Draw(
					Texture,
					new Vector2(30,30), 
					null,
					Color.White,
					RotationAngle,
					new Vector2(Width / 2, Height / 2),
					1.0f,
					SpriteEffects.None,
					1.0f);
			}

		public override void Update()
		{
			#region Position And Velocity

			Vector2 tempPosition = PositionVector;

			Vector2 tempVelocity = VelocityVector;

			#region Keyboard States

			if (GameDisplay.KeyboardCurrentState.IsKeyDown(Keys.W))
			{
				if (IsWithinVerticalNorthBounds())
				{
					if (!HasReachedTerminalYNegativeVelocity())
					{
						tempVelocity.Y -= _enginePower;
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
						tempVelocity.X -= _thrusterPower;
					}
				}
				else
				{
					tempVelocity.X = 0;
				}
			}
			if (GameDisplay.KeyboardCurrentState.IsKeyDown(Keys.S))
			{
				if (IsWithinVerticalSouthBounds())
				{
					if (!HasReachedTerminalYVelocity())
					{
						tempVelocity.Y += _enginePower;
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
						tempVelocity.X += _thrusterPower;
					}
				}
				else
				{
					tempVelocity.X = 0;
				}
			}

			if (GameDisplay.KeyboardCurrentState.IsKeyDown(Keys.Space))
			{
				if (tempVelocity.X > 0)
				{
					tempVelocity.X -= _brakePower;
				}
				if (tempVelocity.Y > 0)
				{
					tempVelocity.Y -= _brakePower;
				}
				if (tempVelocity.X < 0)
				{
					tempVelocity.X += _brakePower;
				}
				if (tempVelocity.Y < 0)
				{
					tempVelocity.Y += _brakePower;
				}

				if (Math.Abs(tempVelocity.X) < .01f && Math.Abs(tempVelocity.Y) < 0.1f)
				{
					tempVelocity.X = 0;
					tempVelocity.Y = 0;
				}
			}

			#endregion Keyboard States

			tempPosition = Vector2.Add(tempPosition, tempVelocity);

			VelocityVector = tempVelocity;

			PositionVector = tempPosition;

			#endregion Position And Velocity

			#region Rotation Angle

			Vector2 mousePosition = new Vector2(GameDisplay.MouseCurrentState.X, GameDisplay.MouseCurrentState.Y);

			Vector2 directionVector = mousePosition - new Vector2(PositionVector.X + Width, PositionVector.Y + Height);

			directionVector.Normalize();

			RotationAngle = (float)(Math.Atan2(directionVector.Y, directionVector.X));

			/*
		    if (HasMouseMovedRight())
		    {
			    RotationAngle += RotationAngle + .00000000000001f;
		    }

		    if (HasMouseMovedLeft())
		    {
			    RotationAngle += RotationAngle - .000000000000001f;
		    }

		    _previousMouseX = GameDisplay.MouseCurrentState.X;*/

			#endregion Rotation Angle

			#region Mouse Press

			if (GameDisplay.MouseCurrentState.LeftButton == ButtonState.Pressed)
			{
				var test = 1;
			}

			#endregion Mouse Press

			//RotationAngle += RotationAngle + 1.0f;
		}

		#endregion Methods

		#region Helper Methods

		private bool HasMouseMovedRight()
		{
			return _previousMouseX < GameDisplay.MouseCurrentState.X + 10;
		}

		private bool HasMouseMovedLeft()
		{
			return _previousMouseX > GameDisplay.MouseCurrentState.X - 10;
		}

		#endregion Helper Methods
	}
}
