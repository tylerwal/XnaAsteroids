using Microsoft.Xna.Framework;
using ShipGame.GameDisplay;
using ShipGame.GameObjects.BaseClass;

namespace ShipGame.GameObjects
{
	public class TargetingSystem : GameObjectBase
	{
		#region Fields

		private Vector2 _originatingVector;

		private Vector2 _targetedVector;

		private float _targetingLength;

		#endregion Fields

		#region Properties

		public Vector2 OriginatingVector
		{
			get
			{
				return _originatingVector;
			}
			set
			{
				_originatingVector = value;
			}
		}

		public Vector2 TargetedVector
		{
			get
			{
				return _targetedVector;
			}
			set
			{
				_targetedVector = value;
			}
		}

		public float TargetingLength
		{
			get
			{
				return _targetingLength;
			}
			set
			{
				_targetingLength = value;
			}
		}

		

		#endregion Properties

		#region Constructors

		public TargetingSystem(XnaGame xnaXnaGame) : base(xnaXnaGame)
		{
			
		}

		#endregion Constructors

		#region Methods

		public override void Initialize()
		{
			DisplayOrder = 1;
		}

		public override void Draw()
		{
		}

		public override void Update()
		{
			
		}

		#endregion Methods

		#region Helper Methods

		 

		#endregion Helper Methods
	}
}