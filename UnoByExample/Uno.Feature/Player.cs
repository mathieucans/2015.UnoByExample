namespace Uno.Feature
{
	public class Player
	{
		public Player(string name)
		{
			Name = name;
		}

		public void Plays(UnoCard s2)
		{
		}

		public bool CanPlay()
		{
			return	false;
		}		
		public string Name { get; private set; }
	}
}