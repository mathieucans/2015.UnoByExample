using System;

namespace Uno.Feature
{
	public class PlayOperation
	{
		private Action<Player, UnoCard> playCommand;
		private Func<Player,UnoCard, bool> canPlayCommand;
		private Player player;

		public PlayOperation(Player player, Action<Player, UnoCard> playCommand, Func<Player, UnoCard, bool> canPlayCommand)
		{
			this.player = player;
			this.playCommand = playCommand;
			this.canPlayCommand = canPlayCommand;
		}

		public void Plays(UnoCard card)
		{
			if (canPlayCommand(player, card))
			{
				playCommand(player, card);
			}
		}

		internal bool CanPlay(UnoCard unoCard)
		{
			return canPlayCommand(player, unoCard);
		}
	}
}