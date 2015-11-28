namespace Uno.Feature
{
	public class UnoCard
	{
		public UnoCardId Id { get; private set; }

		public UnoColor Color { get; set; }

		public bool IsWild{ get { return Id == UnoCardId.Wild || Id == UnoCardId.WildDrawFour; }}

		public UnoCard(UnoCardId unoCardId, UnoColor unoColor)
		{
			Id = unoCardId;
			Color = unoColor;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((UnoCard) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((int)Id * 397) ^ (int)Color;
			}
		}

		protected bool Equals(UnoCard other)
		{
			return Id == other.Id && Color == other.Color;
		}
	}
}