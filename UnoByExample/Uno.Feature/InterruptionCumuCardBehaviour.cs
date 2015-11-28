using System.Collections.Generic;
using System.Linq;

namespace Uno.Feature
{
	public class CumulSameCardBehaviour : IRule
	{
		private readonly IEnumerable<IRule> _cardBehaviourRules;
		private readonly Stack<UnoCard> _playedCardSet;

		public CumulSameCardBehaviour(
			IRule[] rules,
			Stack<UnoCard> playedCardSet)
		{
			_cardBehaviourRules = rules;
			_playedCardSet = playedCardSet;
		}

		public void Apply(Player player, UnoCard card)
		{
			int index = 0;
			while (index < _playedCardSet.Count && card.Equals(_playedCardSet.ElementAt(index)))
			{
				ApplyRules(player, card);
				index++;
			}			
		}

		private void ApplyRules(Player player, UnoCard card)
		{
			foreach (var rule in _cardBehaviourRules)
			{
				rule.Apply(player, card);
			}
		}
	}
}