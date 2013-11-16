using Microsoft.Xna.Framework.Input;
using ShipGame.GameDisplay;
using ShipGame.GameObjects.BaseClass;

namespace ShipGame.GameObjects
{
	public class GameStats : GameObjectBase
	{
		#region Fields
		
		#endregion Fields

		#region Properties


		#endregion Properties

		#region Constructors

		public GameStats(XnaGame xnaXnaGame)
			: base(xnaXnaGame)
		{

		}

		#endregion Constructors

		#region Methods

		public override void Initialize()
		{
			IsVisible = false;
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