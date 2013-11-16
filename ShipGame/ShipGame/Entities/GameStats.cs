using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShipGame.Entities
{
	public class GameStats
	{
		#region Fields

		private int _score;
		
		private int _playerOneHealth;
		
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
		
		public int PlayerOneHealth
		{
			get
			{
				return _playerOneHealth;
			}
			set
			{
				_playerOneHealth = value;
			}
		}
		
		#endregion Properties

		#region Constructors

		public GameStats()
		{

		}

		#endregion Constructors

		#region Methods



		#endregion Methods

		#region Helper Methods



		#endregion Helper Methods
	}
}
