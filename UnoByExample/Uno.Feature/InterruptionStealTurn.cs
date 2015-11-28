namespace Uno.Feature
{
	public class InterruptionStealTurn : IRule
	{
		private Turn turn;

		public InterruptionStealTurn(Turn turn)
		{
			this.turn = turn;
		}

		public void Apply(Player player, UnoCard card)
		{			
			if (player != turn.PlayerToPlay)
			{
				turn.StealTurn(player);
			}
		}
	}
}