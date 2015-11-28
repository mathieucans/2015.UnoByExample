using System;

namespace Uno.Feature
{
	class JumpUpdateTurnToNextPlayer : IRule
	{
		private Turn turn;

		public JumpUpdateTurnToNextPlayer(Turn turn)
		{
			this.turn = turn;
		}

		public void Apply(Player player, UnoCard card)
		{
			if (card.Id == UnoCardId.Jump) turn.IncTurn();
		}
	}
}
