using Microsoft.Xna.Framework;
using ShipGame.GameDisplay;
using ShipGame.GameObjects.BaseClass;

namespace ShipGame.GameObjects
{
	public class TargetingSystem : GameObjectBase
	{
		#region Fields
		
		#endregion Fields

		#region Properties
		
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