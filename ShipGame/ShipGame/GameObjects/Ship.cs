using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShipGame.GameDisplay;
using ShipGame.GameObjects.BaseClass;
using System;
using System.Linq;

namespace ShipGame.GameObjects
{
	using ShipGame.GameUtilities;

	public class Ship : GameObjectBase
	{
		#region Fields

		private float _brakePower;

		private float _enginePower;

		private float _thrusterPower;
		
		private KeyboardState _keyboardState;

		private MouseState _mouseState;

		//delete below
		private Texture2D testingTexture;
		//delete above

		private Color _textureTint;

		#endregion Fields

		#region Properties

		public new Color TextureTint
		{
			get
			{
				return _textureTint;
			}
			set
			{
				_textureTint = value;
			}
		}
		
		#endregion Properties

		#region Constructors

		public Ship(XnaGame xnaXnaGame)
			: base(xnaXnaGame)
		{
			//start ship in center
			Vector2 centerScreenVector = new Vector2(XnaGame.ClientRectangle.Width / 2, XnaGame.ClientRectangle.Height / 2);
			PositionVector = centerScreenVector;

			TerminalVelocity = GameConfig.ShipTerminalVelocity;
			_brakePower = GameConfig.ShipBrakePower;
			_enginePower = GameConfig.ShipEnginePower;
			_thrusterPower = GameConfig.ShipThrusterPower;
		}

		#endregion Constructors

		#region Methods

		public override void Initialize()
		{
			SpriteSelectedFrame = GameConfig.ShipSelectedFrame;

			Texture = XnaGame.Content.Load<Texture2D>(GameConfig.ShipTextureName);

			Texture = GameUtilities.ReturnSingleSpriteFrame(
				Texture, 
				GameConfig.ShipTextureRows, 
				GameConfig.ShipTextureColumns,
				SpriteSelectedFrame, 
				true);

			DisplayOrder = 3;

			IsVisible = true;

			Health = GameConfig.ShipStartingHealth;

			MaxHealth = GameConfig.ShipTotalMaxHealth;

			TextureTint = Color.White;

			//delete below
			testingTexture = new Texture2D(XnaGame.GraphicsDevice, 1, 1);
			testingTexture.SetData(new Color[] { Color.AliceBlue });
			//delete above
		}

		public override void Draw()
		{
			XnaGame.SpriteBatch.Draw(
					Texture,
					PositionVector,
					null,
					TextureTint, 
					RotationAngle,
					new Vector2(Bounds.Width/2, Bounds.Height / 2), 
					GameConfig.ShipScale, 
					SpriteEffects.None,
					1.0f 
				);

			//for testing ship bounds
			//XnaGame.SpriteBatch.Draw(testingTexture, Bounds, Color.Red);
		}

		public override void Update()
		{
			Bounds = GetBounds(GameConfig.ShipScale);

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

			Vector2 directionVector = mousePosition - GameUtilities.GetVectorFromPoint(Bounds.Center);
			
			directionVector.Normalize();

			RotationAngle = (float)(Math.Atan2(directionVector.Y, directionVector.X));

			#endregion Rotation Angle

			#region Mouse Press

			/*if (_mouseState.LeftButton == ButtonState.Pressed)
			{
				Bullet bullet = new Bullet(XnaGame);

				bullet.PositionVector = PositionVector;

				bullet.VelocityVector = new Vector2(2f, 2f);

				XnaGame.GameObjects.Add(bullet);

			}*/

			#endregion Mouse Press

			VelocityVector = tempVelocity;

			PositionVector = tempPosition;

			GameObjectBase collidedObject = GetCollidedObject();

			if (collidedObject is Asteroid)
			{
				Health--;

				TextureTint = Color.Red;
			}
			else
			{
				TextureTint = Color.White;
			}
		}

		#endregion Methods

		#region Helper Methods

		private void GetCurrentKeyboardMouseStates()
		{
			_mouseState = XnaGame.GameObjects.OfType<GameControl>().First().MouseCurrentState;

			_keyboardState = XnaGame.GameObjects.OfType<GameControl>().First().KeyboardCurrentState;
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
