namespace ShipGame.GameObjects.BaseClass
{
	public interface IGameObject
	{
		int DisplayOrder
		{
			get;
			set;
		}

		bool IsVisible
		{
			get;
			set;
		}

		void Initialize();

		void Update();

		void Draw();
	}
}