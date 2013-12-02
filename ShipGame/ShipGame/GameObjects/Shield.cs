using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShipGame.GameDisplay;
using ShipGame.GameObjects.BaseClass;
using ShipGame.GameUtilities;
using System.Collections.Generic;

namespace ShipGame.GameObjects
{
	using System;

	public class Shield : GameObjectBase
	{
		#region Fields

		private Color _textureTint;

		private Ship _ship;

		#endregion Fields

		#region Properties

		public new Color TextureTint
		{
			get
			{
				return _textureTint;
			}
			set
			{
				_textureTint = value;
			}
		}

		#endregion Properties

		#region Constructors

		public Shield(XnaGame xnaXnaGame, Ship ship)
			: base(xnaXnaGame)
		{
			_ship = ship;
		}

		#endregion Constructors

		#region Methods

		public override void Initialize()
		{
			Texture = XnaGame.Content.Load<Texture2D>(GameConfig.ShieldTextureName);

			DisplayOrder = 1;

			IsVisible = true;

			Health = GameConfig.ShieldStartingHealth;

			MaxHealth = GameConfig.ShieldMaxHealth;
		}

		public override void Draw()
		{
			XnaGame.SpriteBatch.Draw(Texture, Bounds, TextureTint);
		}

		public override void Update()
		{
			Rectangle tempRectangle = _ship.Bounds;

			tempRectangle.Inflate(15, 15);

			Bounds = tempRectangle;

			CollisionHandling();

			if (Health <= 0)
			{
				IsVisible = false;
			}
			else
			{
				IsVisible = true;
			}
		}

		#endregion Methods

		#region Helper Methods

		private void CollisionHandling()
		{
			List<GameObjectBase> objectsToIgnore = new List<GameObjectBase>
			{
				_ship
			};

			List<Type> typesToIgnore = new List<Type>
			{
				typeof(Bullet),
				typeof(Crystal)
			};
			
			GameObjectBase collidedObject = GetCollidedObject(objectsToIgnore, typesToIgnore);

			if (collidedObject == null)
			{
				TextureTint = new Color((int)(Health * 2.5), 0, 0, 0);
			}
			else
			{
				TextureTint = Color.DarkRed;

				Health --;
			}
		}

		#endregion Helper Methods
	}
}