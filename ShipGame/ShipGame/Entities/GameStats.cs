using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShipGame.Entities
{
	public class GameStats
	{
		#region Fields

		private int _playerOneScore;

		private int _playerTwoScore;

		private int _playerOneHealth;

		private int _playerTwoHealth;

		#endregion Fields

		#region Properties

		public int PlayerOneScore
		{
			get
			{
				return _playerOneScore;
			}
			set
			{
				_playerOneScore = value;
			}
		}

		public int PlayerTwoScore
		{
			get
			{
				return _playerTwoScore;
			}
			set
			{
				_playerTwoScore = value;
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

		public int PlayerTwoHealth
		{
			get
			{
				return _playerTwoHealth;
			}
			set
			{
				_playerTwoHealth = value;
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
