using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShipGame.Entities
{
	public class GameStatRepository
	{
		#region Fields

		private int _score;
		
		private int _health;

		private int _ammoLeft;

		private int _asteroidsLeft;
		
		#endregion Fields

		#region Properties

		public int Score
		{
			get
			{
				return _score;
			}
			set
			{
				_score = value;
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
			}
		}

		public int AmmoLeft
		{
			get
			{
				return _ammoLeft;
			}
			set
			{
				_ammoLeft = value;
			}
		}

		public int AsteroidsLeft
		{
			get
			{
				return _asteroidsLeft;
			}
			set
			{
				_asteroidsLeft = value;
			}
		}

		
		
		#endregion Properties

		#region Constructors

		public GameStatRepository()
		{

		}

		#endregion Constructors

		#region Methods



		#endregion Methods

		#region Helper Methods



		#endregion Helper Methods
	}
}
