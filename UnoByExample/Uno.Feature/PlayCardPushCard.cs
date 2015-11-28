using System.Collections.Generic;

namespace Uno.Feature
{
	public class PlayCardPushCard : IRule
	{
		private readonly Stack<UnoCard> _playedCardSet;

		public PlayCardPushCard(Stack<UnoCard> playedCardSet)
		{
			_playedCardSet = playedCardSet;
		}

		public void Apply(Player player, UnoCard card)
		{
			_playedCardSet.Push(card);
		}
	}
}