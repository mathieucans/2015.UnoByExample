using System;

namespace Uno.Feature
{
	internal class PlayCardUpdateTurnToNextPlayer : IRule
	{
		private Turn _turn;

		public PlayCardUpdateTurnToNextPlayer(Turn turn)
		{
			_turn = turn;
		}

		public void Apply(Player player, UnoCard card)
		{
			_turn.IncTurn();
		}
	}
}