namespace Uno.Feature
{
	internal class PlayCardUpdateTurnToNextPlayer : IRule
	{
		private Turn turn;

		public PlayCardUpdateTurnToNextPlayer(Turn turn)
		{
			this.turn = turn;
		}

		public void Apply(Player player, UnoCard card)
		{
			turn.IncTurn();			
		}
	}
}