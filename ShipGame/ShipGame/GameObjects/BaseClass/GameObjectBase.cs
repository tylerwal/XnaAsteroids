using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShipGame.GameObjects.BaseClass
{
	abstract public class GameObjectBase: IDrawableObject
	{
		#region Fields

		private Texture2D _texture;

		private Vector2 _vector;

		private bool _isActive;

		private int _xVelocity;

		private int _yVelocity;

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

		public Vector2 Vector
		{
			get
			{
				return _vector;
			}
			set
			{
				_vector = value;
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
				return _texture.Width;
			}
		}

		public int Height
		{
			get
			{
				return _texture.Height;
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

		#endregion Properties

		#region Constructors

		protected GameObjectBase()
		{
			
		}

		#endregion Constructors

		#region Methods

		public abstract void Initialize();

		public abstract void Draw();

		public abstract void Update();

		#endregion Methods

		#region Helper Methods



		#endregion Helper Methods
	}
}