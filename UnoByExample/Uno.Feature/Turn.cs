namespace Uno.Feature
{
	public class Turn
	{
		private int index;
		
		private System.Collections.Generic.List<Player> players;

		

		public Turn(System.Collections.Generic.List<Player> players)
		{		
			this.players = players;
		}

		public int Index
		{
			get { return index; }
			set { index = value; }
		}

		public Player PlayerToPlay { get { return players[index]; } }

		public void IncTurn()
		{
			index = (index + 1) % players.Count;
		}

		public void StealTurn(Player player)
		{
			index = players.IndexOf(player);
		}
	}
}