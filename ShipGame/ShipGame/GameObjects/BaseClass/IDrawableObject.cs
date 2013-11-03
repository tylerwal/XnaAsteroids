namespace ShipGame.GameObjects.BaseClass
{
	public interface IDrawableObject
	{
		int DisplayOrder
		{
			get;
			set;
		}

		void Initialize();

		void Update();

		void Draw();
	}
}