using System.Collections.Generic;

namespace Uno.Feature
{
	public class CumulSameCardBehaviour : IRule
	{
		private IEnumerable<IRule> cardBehaviourRules;
		private readonly List<UnoCard> playedCardSet;

		public CumulSameCardBehaviour(
			IRule[] rules, 
			List<UnoCard> playedCardSet)
		{
			cardBehaviourRules = rules;
			this.playedCardSet = playedCardSet;
		}

		public void Apply(Player player, UnoCard card)
		{
			int index = playedCardSet.Count - 1;
			while (index > 0 && card.Equals(playedCardSet[index]))
			{
				ApplyRules(player, card);
				index--;
			}			
		}

		private void ApplyRules(Player player, UnoCard card)
		{
			foreach (var rule in cardBehaviourRules)
			{
				rule.Apply(player, card);
			}
		}
	}
}