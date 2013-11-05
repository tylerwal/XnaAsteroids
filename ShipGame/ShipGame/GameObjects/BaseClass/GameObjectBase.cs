using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShipGame.GameDisplay;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShipGame.GameObjects.BaseClass
{
	abstract public class GameObjectBase: IGameObject
	{
		#region Fields

		private Texture2D _texture;

		private Vector2 _positionVector;

		private Vector2 _velocityVector;

		private bool _isVisible;

		private XnaGame _gameDisplay;

		private int _displayOrder;

		private IList<Rectangle> _spriteRectangles;

		private float _terminalVelocity;

		private float _rotationAngle;

		private int _spriteSelectedFrame;

		private Rectangle _bounds;
		
		#endregion Fields

		#region Properties

		public Texture2D Texture
		{
			get
			{
				return _texture;
			}
			set
			{
				_texture = value;
			}
		}

		public Vector2 PositionVector
		{
			get
			{
				return _positionVector;
			}
			set
			{
				_positionVector = value; 
			}
		}

		public bool IsVisible
		{
			get
			{
				return _isVisible;
			}
			set
			{
				_isVisible = value;
			}
		}

		public int Width
		{
			get
			{
				return SpriteRectangles.First().Width;
			}
		}

		public int Height
		{
			get
			{
				return SpriteRectangles.First().Height;
			}
		}

		protected XnaGame GameDisplay
		{
			get
			{
				return _gameDisplay;
			}
			set
			{
				_gameDisplay = value;
			}
		}

		public int DisplayOrder
		{
			get
			{
				return _displayOrder;
			}
			set
			{
				_displayOrder = value;
			}
		}

		public IList<Rectangle> SpriteRectangles
		{
			get
			{
				return _spriteRectangles;
			}
			set
			{
				_spriteRectangles = value;
			}
		}

		public Vector2 VelocityVector
		{
			get
			{
				return _velocityVector;
			}
			set
			{
				_velocityVector = value; 
			}
		}

		public float TerminalVelocity
		{
			get
			{
				return _terminalVelocity;
			}
			set
			{
				_terminalVelocity = value;
			}
		}

		public float RotationAngle
		{
			get
			{
				return _rotationAngle;
			}
			set
			{
				_rotationAngle = value;
			}
		}

		public int SpriteSelectedFrame
		{
			get
			{
				return _spriteSelectedFrame;
			}
			set
			{
				_spriteSelectedFrame = value;
			}
		}

		public Rectangle Bounds
		{
			get
			{
				return new Rectangle((int)PositionVector.X, (int)PositionVector.Y, Width, Height);
				//return _bounds;
			}
			set
			{
				_bounds = value;
			}
		}
		
		#endregion Properties

		#region Constructors

		protected GameObjectBase(XnaGame xnaGame)
		{
			GameDisplay = xnaGame;

			//initial display order
			DisplayOrder = 1;
		}

		#endregion Constructors

		#region Methods

		public abstract void Initialize();

		public abstract void Draw();

		public abstract void Update();

		#endregion Methods

		#region Helper Methods

		#region Bound Methods

		protected bool IsWithinBounds()
		{
			return GameDisplay.ClientRectangle.Contains(Convert.ToInt32(_positionVector.X), Convert.ToInt32(_positionVector.Y));
		}

		protected bool IsWithinHorizontalEastBounds()
		{
			return GameDisplay.ClientRectangle.Right >= _positionVector.X;
		}

		protected bool IsWithinHorizontalWestBounds()
		{
			return GameDisplay.ClientRectangle.Left <= _positionVector.X;
		}

		protected bool IsWithinVerticalNorthBounds()
		{
			return GameDisplay.ClientRectangle.Top <= _positionVector.Y;
		}

		protected bool IsWithinVerticalSouthBounds()
		{
			return GameDisplay.ClientRectangle.Bottom >= _positionVector.Y;
		} 

		#endregion Bound Methods

		#region Velocity Methods

		protected bool HasReachedTerminalXPositiveVelocity()
		{

			return VelocityVector.X >= TerminalVelocity;
		}

		protected bool HasReachedTerminalXNegativeVelocity()
		{

			return VelocityVector.X <= (TerminalVelocity * -1);
		}

		protected bool HasReachedTerminalYPositiveVelocity()
		{

			return VelocityVector.Y >= TerminalVelocity;
		}

		protected bool HasReachedTerminalYNegativeVelocity()
		{

			return VelocityVector.Y <= (TerminalVelocity * -1);
		} 

		#endregion Velocity Methods

		protected void ApplyEndlessDisplay()
		{
			Vector2 tempPosition = PositionVector;

			if (!IsWithinHorizontalEastBounds())
			{
				tempPosition.X = GameDisplay.ClientRectangle.Left;
			}
			if (!IsWithinHorizontalWestBounds())
			{
				tempPosition.X = GameDisplay.ClientRectangle.Right;
			}
			if (!IsWithinVerticalNorthBounds())
			{
				tempPosition.Y = GameDisplay.ClientRectangle.Bottom;
			}
			if (!IsWithinVerticalSouthBounds())
			{
				tempPosition.Y = GameDisplay.ClientRectangle.Top;
			}

			PositionVector = tempPosition;
		}

		protected bool IsBoundsWithinAnotherObjectsBounds()
		{
			return GetCollidedObject() != null;
		}

		protected GameObjectBase GetCollidedObject()
		{
			IEnumerable<GameObjectBase> otherGameObjectsVisible = GameDisplay.GameObjects.OfType<GameObjectBase>().Where(i => i.IsVisible).Where(i => i != this);

			foreach (GameObjectBase otherGameObject in otherGameObjectsVisible)
			{
				Rectangle gameObjectRectangle = otherGameObject.Bounds;

				Rectangle startingRectangle = new Rectangle((int)PositionVector.X, (int)PositionVector.Y, Width, Height);

				if (startingRectangle.Intersects(gameObjectRectangle))
				{
					return otherGameObject;
				}
			}

			return null;
		}

		protected Vector2 GetRandomStartingPoint()
		{
			return GameDisplay.GameUtilities.GetRandomVector(
				GameDisplay.ClientRectangle.Left,
				GameDisplay.ClientRectangle.Right,
				GameDisplay.ClientRectangle.Top,
				GameDisplay.ClientRectangle.Bottom
				);
		}

		protected Rectangle GetBounds(float scale)
		{
			Rectangle bounds = new Rectangle();

			bounds.Width = (int)(Width * scale);

			bounds.Height = (int)(Height * scale);

			bounds.X -= Width / 2;

			bounds.Y -= Height / 2;

			return bounds;
		}

		#endregion Helper Methods
	}
}