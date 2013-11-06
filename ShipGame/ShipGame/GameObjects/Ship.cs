using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShipGame.GameDisplay;
using ShipGame.GameObjects.BaseClass;
using System;

namespace ShipGame.GameObjects
{
	public class Ship : GameObjectBase
	{
		#region Fields

		private float _brakePower;

		private float _enginePower;

		private float _thrusterPower;

		private int _spriteSelectedFrame;

		private KeyboardState _keyboardState;

		private MouseState _mouseState;

		#endregion Fields

		#region Properties



		#endregion Properties

		#region Constructors

		public Ship(XnaGame xnaXnaGame)
			: base(xnaXnaGame)
		{
			//start ship in center
			Vector2 centerScreenVector = new Vector2(XnaGame.ClientRectangle.Width / 2, XnaGame.ClientRectangle.Height / 2);
			PositionVector = centerScreenVector;

			TerminalVelocity = GameUtilities.GameConfig.ShipTerminalVelocity;
			_brakePower = GameUtilities.GameConfig.ShipBrakePower;
			_enginePower = GameUtilities.GameConfig.ShipEnginePower;
			_thrusterPower = GameUtilities.GameConfig.ShipThrusterPower;
		}

		#endregion Constructors

		#region Methods

		public override void Initialize()
		{
			SpriteSelectedFrame = GameUtilities.GameConfig.ShipSelectedFrame;

			Texture = XnaGame.Content.Load<Texture2D>(GameUtilities.GameConfig.ShipTextureName);
			
			/*SpriteRectangles = GameUtilities.GameUtilities.GetSpriteRectangles(Texture, 
				GameUtilities.GameConfig.ShipTextureRows, 
				GameUtilities.GameConfig.ShipTextureColumns);

			SpriteRectangles = GameUtilities.GameUtilities.RemoveFrameLines(SpriteRectangles);*/

			Texture = GameUtilities.GameUtilities.ReturnSingleSpriteFrame(Texture, 
				GameUtilities.GameConfig.ShipTextureRows, 
				GameUtilities.GameConfig.ShipTextureColumns,
				SpriteSelectedFrame, 
				true);

			DisplayOrder = 2;

			IsVisible = true;
		}

		public override void Draw()
		{
			#region Junk

			/*XnaGame.SpriteBatch.Draw(
					Texture,
					PositionVector,
					SpriteRectangles[0], //source rectangle
					Color.White, //tint
					RotationAngle/* + (float)(Math.PI/2)#1#,
					new Vector2(Height / 2, Width / 2), //origin of rotation
					1.0f, //scale
					SpriteEffects.None,
					1.0f
				);*/

			/*XnaGame.SpriteBatch.Draw(
					Texture,
					new Vector2(30, 30),
					null,
					Color.White,
					RotationAngle,
					new Vector2(Width / 2, Height / 2),
					1.0f,
					SpriteEffects.None,
					1.0f);*/

			/*XnaGame.SpriteBatch.Draw(
					Texture,
					new Rectangle(50, 50, 24, 24),
					null, //use whole texture
					Color.White, //tint
					RotationAngle/* + (float)(Math.PI/2)#1#,
					new Vector2(Height / 2, Width / 2), //origin of rotation
				//1.0f, //scale
					SpriteEffects.None,
					1.0f
				);*/


			#endregion Junk

			//moving
			XnaGame.SpriteBatch.Draw(
					Texture,
					PositionVector,
					null, //use whole texture
					Color.White, //tint
					RotationAngle/* + (float)(Math.PI/2)*/,
					new Vector2(Bounds.Width/2, Bounds.Height / 2), //origin of rotation from the top left of the texture
					GameUtilities.GameConfig.ShipScale, //scale
					SpriteEffects.None,
					1.0f //layer depth, for sorting sprites but this is already done
				);
		}

		public override void Update()
		{
			Bounds = GetBounds(GameUtilities.GameConfig.ShipScale);

			GetCurrentKeyboardMouseStates();

			#region Position And Velocity

			ApplyEndlessDisplay();

			Vector2 tempPosition = PositionVector;

			Vector2 tempVelocity = VelocityVector;

			#region Keyboard States

			if (_keyboardState.IsKeyDown(Keys.W) && !HasReachedTerminalYNegativeVelocity())
			{
				tempVelocity.Y -= _enginePower;
			}
			if (_keyboardState.IsKeyDown(Keys.A) && !HasReachedTerminalXNegativeVelocity())
			{
				tempVelocity.X -= _thrusterPower;
			}
			if (_keyboardState.IsKeyDown(Keys.S) && !HasReachedTerminalYPositiveVelocity())
			{
				tempVelocity.Y += _enginePower;
			}
			if (_keyboardState.IsKeyDown(Keys.D) && !HasReachedTerminalXPositiveVelocity())
			{
				tempVelocity.X += _thrusterPower;
			}

			if (_keyboardState.IsKeyDown(Keys.Space))
			{
				tempVelocity = ApplyBrakes(tempVelocity);
			}

			#endregion Keyboard States

			tempPosition = Vector2.Add(tempPosition, tempVelocity);
			
			#endregion Position And Velocity

			#region Rotation Angle

			Vector2 mousePosition = new Vector2(_mouseState.X, _mouseState.Y);

			Vector2 directionVector = mousePosition - GameUtilities.GameUtilities.GetVectorFromPoint(Bounds.Center);
			
			directionVector.Normalize();

			RotationAngle = (float)(Math.Atan2(directionVector.Y, directionVector.X));

			#endregion Rotation Angle

			#region Mouse Press

			if (_mouseState.LeftButton == ButtonState.Pressed)
			{
				XnaGame.Stopwatch.Stop();
			}

			#endregion Mouse Press

			VelocityVector = tempVelocity;

			PositionVector = tempPosition;
		}

		#endregion Methods

		#region Helper Methods

		private void GetCurrentKeyboardMouseStates()
		{
			_mouseState = XnaGame.GameObjects.OfType<GameControls>().First().MouseCurrentState;

			_keyboardState = XnaGame.GameObjects.OfType<GameControls>().First().KeyboardCurrentState;
		}

		private Vector2 ApplyBrakes(Vector2 currentVelocity)
		{
			Vector2 tempVelocity = currentVelocity;

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

			if (Math.Abs(tempVelocity.X) < .1f && Math.Abs(tempVelocity.Y) < 0.1f)
			{
				tempVelocity.X = 0;
				tempVelocity.Y = 0;
			}

			return tempVelocity;
		}
		
		#endregion Helper Methods
	}
}
