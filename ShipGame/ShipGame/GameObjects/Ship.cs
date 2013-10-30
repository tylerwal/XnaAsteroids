using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShipGame.GameObjects
{
	public class Ship
	{
		#region Fields

		private int _xPosition;

		private int _yPosition;

		private int _xVelocity;

		private int _yVelocity;

		private int _height;

		private int _width;

		#endregion Fields

		#region Properties

		public int XPosition
		{
			get
			{
				return _xPosition;
			}
			set
			{
				_xPosition = value;
			}
		}

		public int YPosition
		{
			get
			{
				return _yPosition;
			}
			set
			{
				_yPosition = value;
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

		public int Height
		{
			get
			{
				return _height;
			}
			set
			{
				_height = value;
			}
		}

		public int Width
		{
			get
			{
				return _width;
			}
			set
			{
				_width = value;
			}
		}

		#endregion Properties

		#region Constructors

		public Ship()
		{

		}

		#endregion Constructors

		#region Methods



		#endregion Methods

		#region Helper Methods



		#endregion Helper Methods
	}
}
