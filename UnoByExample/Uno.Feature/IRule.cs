namespace Uno.Feature
{
	public interface IRule
	{
		void Apply(Player player, UnoCard card);
	}
}