﻿using System.Globalization;
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

		private XnaGame _xnaGame;

		private int _displayOrder;

		/*private IList<Rectangle> _spriteRectangles;*/

		private float _terminalVelocity;

		private float _rotationAngle;

		private int _spriteSelectedFrame;

		private Rectangle _bounds;

		private int _health;

		private bool _isMarkedForDeletion;

		private int _maxHealth;
		
		#endregion Fields

		#region Properties

		protected Texture2D Texture
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
		
		protected XnaGame XnaGame
		{
			get
			{
				return _xnaGame;
			}
			set
			{
				_xnaGame = value;
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

		protected float TerminalVelocity
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

		protected float RotationAngle
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

		protected int SpriteSelectedFrame
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
				return _bounds;
			}
			set
			{
				_bounds = value;
			}
		}

		public int Health
		{
			get
			{
				return _health;
			}
			set
			{
				_health = value;

				if (MaxHealth != 0 && _health > MaxHealth)
				{
					_health = MaxHealth;
				}

				if (_health < 0)
				{
					_health = 0;
				}
			}
		}

		public bool IsMarkedForDeletion
		{
			get
			{
				return _isMarkedForDeletion;
			}
			set
			{
				_isMarkedForDeletion = value;
			}
		}

		protected int MaxHealth
		{
			get
			{
				return _maxHealth;
			}
			set
			{
				_maxHealth = value;
			}
		}

		protected Color TextureTint
		{
			get
			{
				return Color.White;
			}
		}
		
		#endregion Properties

		#region Constructors

		protected GameObjectBase(XnaGame xnaXnaGame)
		{
			XnaGame = xnaXnaGame;

			//initial display order
			DisplayOrder = 1;
		}

		#endregion Constructors

		#region Methods
		
		/// <summary>
		/// Initializes the required settings for a displayed game object: including visibility, texture, and display order
		/// </summary>
		public abstract void Initialize();

		/// <summary>
		/// Draws the texture for the object using the XnaGame's spritebatch
		/// </summary>
		public abstract void Draw();

		/// <summary>
		/// Updates the object based on other objects, randomness, and player control
		/// </summary>
		public abstract void Update();
		
		#endregion Methods

		#region Helper Methods

		#region Bound Methods

		protected bool IsWithinBounds()
		{
			return XnaGame.ClientRectangle.Contains(Convert.ToInt32(_positionVector.X), Convert.ToInt32(_positionVector.Y));
		}

		protected bool IsWithinHorizontalEastBounds()
		{
			return XnaGame.ClientRectangle.Right >= _positionVector.X;
		}

		protected bool IsWithinHorizontalWestBounds()
		{
			return XnaGame.ClientRectangle.Left <= _positionVector.X;
		}

		protected bool IsWithinVerticalNorthBounds()
		{
			return XnaGame.ClientRectangle.Top <= _positionVector.Y;
		}

		protected bool IsWithinVerticalSouthBounds()
		{
			return XnaGame.ClientRectangle.Bottom >= _positionVector.Y;
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
				tempPosition.X = XnaGame.ClientRectangle.Left;
			}
			if (!IsWithinHorizontalWestBounds())
			{
				tempPosition.X = XnaGame.ClientRectangle.Right;
			}
			if (!IsWithinVerticalNorthBounds())
			{
				tempPosition.Y = XnaGame.ClientRectangle.Bottom;
			}
			if (!IsWithinVerticalSouthBounds())
			{
				tempPosition.Y = XnaGame.ClientRectangle.Top;
			}

			PositionVector = tempPosition;
		}

		#region Collision Handling

		protected bool IsBoundsWithinAnotherObjectsBounds()
		{
			return GetCollidedObject() != null;
		}

		protected GameObjectBase GetCollidedObject()
		{
			return GetCollidedObject(new List<GameObjectBase>(), new List<Type>());
		}

		protected GameObjectBase GetCollidedObject(IEnumerable<GameObjectBase> objectsToIgnore, IEnumerable<Type> typesToIgnore)
		{
			IEnumerable<GameObjectBase> otherGameObjectsVisible = XnaGame.GameObjects
				.OfType<GameObjectBase>()
				.Except(XnaGame.GameObjects.OfType<Background>())
				.Where(i => i.IsVisible)
				.Where(i => i != this);

			otherGameObjectsVisible = otherGameObjectsVisible.Except(objectsToIgnore);

			foreach (Type type in typesToIgnore)
			{
				otherGameObjectsVisible = otherGameObjectsVisible.Where(i => i.GetType() != type);
			}

			foreach (GameObjectBase otherGameObject in otherGameObjectsVisible)
			{
				Rectangle gameObjectRectangle = otherGameObject.Bounds;

				Rectangle startingRectangle = Bounds;

				if (startingRectangle.Intersects(gameObjectRectangle))
				{
					return otherGameObject;
				}
			}

			return null;
		}

		#endregion Collision Handling

		protected Vector2 GetRandomStartingPoint()
		{
			return XnaGame.GameUtility.GetRandomVector(
				XnaGame.ClientRectangle.Left,
				XnaGame.ClientRectangle.Right,
				XnaGame.ClientRectangle.Top,
				XnaGame.ClientRectangle.Bottom
				);
		}

		protected Rectangle GetBounds(float scale)
		{
			Rectangle bounds = Texture.Bounds;

			bounds.Height = (int)(bounds.Height * scale);

			bounds.Width = (int)(bounds.Width * scale);

			bounds.X = (int)PositionVector.X - (bounds.Width / 2);

			bounds.Y = (int)PositionVector.Y - (bounds.Height / 2);

			return bounds;
		}

		#endregion Helper Methods
	}
}