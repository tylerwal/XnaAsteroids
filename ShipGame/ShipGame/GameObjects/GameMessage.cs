using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShipGame.GameDisplay;
using ShipGame.GameObjects.BaseClass;
using System.Text;
using Color = Microsoft.Xna.Framework.Color;

namespace ShipGame.GameObjects
{
	using ShipGame.GameUtilities;
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class GameMessage : GameObjectBase
	{
		#region Fields

		private SpriteFont _spriteFont;
		
		private StringBuilder _stringBuilder;

		private List<Tuple<TimeSpan, string>> _messages;

		#endregion Fields

		#region Properties

		#endregion Properties

		#region Constructors

		public GameMessage(XnaGame xnaXnaGame)
			: base(xnaXnaGame)
		{
		}

		#endregion Constructors

		#region Methods

		public override void Initialize()
		{
			DisplayOrder = 5;

			IsVisible = true;

			_spriteFont = XnaGame.Content.Load<SpriteFont>("SpriteFont");

			_messages = new List<Tuple<TimeSpan, string>>();

			PositionVector = new Vector2(20, 20);

			_stringBuilder = new StringBuilder();
		}

		public override void Draw()
		{
			XnaGame.SpriteBatch.DrawString(
				_spriteFont,
				_stringBuilder,
				PositionVector,
				Color.Red
				);
		}

		public override void Update()
		{
			_stringBuilder.Clear();

			RemoveOldMessages();

			SetMessageNumberLimit();

			foreach (var message in _messages)
			{
				_stringBuilder.Append(message.Item2);

				_stringBuilder.Append(Environment.NewLine);
			}
		}

		public void AddMessage(TimeSpan time, string message)
		{
			Tuple<TimeSpan, string> newMessage = new Tuple<TimeSpan, string>(time, message);

			_messages.Add(newMessage);
		}

		#endregion Methods

		#region Helper Methods

		private void RemoveOldMessages()
		{
			var oldMessages = _messages
				.Where(i => (XnaGame.GlobalGameStopWatch.Elapsed - i.Item1 > TimeSpan.FromSeconds(GameConfig.MessageScreenTime)))
				.ToList();

			foreach (Tuple<TimeSpan, string> oldMessage in oldMessages)
			{
				_messages.Remove(oldMessage);
			}
		}

		private void SetMessageNumberLimit()
		{
			_messages = _messages.OrderBy(i => i.Item1).Take(5).ToList();
		}

		#endregion Helper Methods
	}
}