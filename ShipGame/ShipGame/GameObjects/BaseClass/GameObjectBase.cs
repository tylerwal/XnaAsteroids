using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShipGame.GameDisplay;

namespace ShipGame.GameObjects.BaseClass
{
	abstract public class GameObjectBase: IDrawableObject
	{
		#region Fields

		private Texture2D _texture;

		private Vector2 _positionVector;

		private Vector2 _velocityVector;

		private bool _isActive;

		private int _xVelocity;

		private int _yVelocity;

		/*private int _height;

		private int _width;*/

		private XNAGameDisplay _gameDisplay;

		private int _displayOrder;

		private IList<Rectangle> _spriteRectangles;

		private int _terminalVelocity;

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

		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActive = value;
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

		public Rectangle Bounds
		{
			get
			{
				return _texture.Bounds;
			}
		}

		public int XVelocity
		{
			get
			{
				return _xVelocity;
			}
			set
			{
				_xVelocity = value;
			}
		}

		public int YVelocity
		{
			get
			{
				return _yVelocity;
			}
			set
			{
				_yVelocity = value;
			}
		}

		protected XNAGameDisplay GameDisplay
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

		public int TerminalVelocity
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

		
		
		#endregion Properties

		#region Constructors

		protected GameObjectBase(XNAGameDisplay xnaGameDisplay)
		{
			GameDisplay = xnaGameDisplay;

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
			return GameDisplay.ClientRectangle.Right >= (_positionVector.X + Width);
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
			return GameDisplay.ClientRectangle.Bottom >= (_positionVector.Y + Height);
		} 

		#endregion Bound Methods

		#region Velocity Methods

		protected bool HasReachedTerminalXVelocity()
		{

			return VelocityVector.X >= TerminalVelocity;
		}

		protected bool HasReachedTerminalXNegativeVelocity()
		{

			return VelocityVector.X <= (TerminalVelocity * -1);
		}

		protected bool HasReachedTerminalYVelocity()
		{

			return VelocityVector.Y >= TerminalVelocity;
		}

		protected bool HasReachedTerminalYNegativeVelocity()
		{

			return VelocityVector.Y <= (TerminalVelocity * -1);
		} 

		#endregion Velocity Methods

		#endregion Helper Methods
	}
}