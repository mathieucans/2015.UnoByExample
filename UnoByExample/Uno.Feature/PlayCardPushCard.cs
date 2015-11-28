using System.Collections.Generic;

namespace Uno.Feature
{
	public class PlayCardPushCard : IRule
	{
		private List<UnoCard> playedCardSet;

		public PlayCardPushCard(List<UnoCard> playedCardSet)
		{
			this.playedCardSet = playedCardSet;
		}

		public void Apply(Player player, UnoCard card)
		{
			playedCardSet.Add(card);
		}
	}
}