using System.Collections.Generic;

namespace Uno.Feature
{
	public class EtantDonnéLaDispositonDesJoueursAbcd
	{
		private readonly UnoGame _unoGame;
		private Stack<UnoCard> _deck;

		public EtantDonnéLaDispositonDesJoueursAbcd()
		{
			_deck = new Stack<UnoCard>();
			_unoGame = new UnoGame(_deck, "A", "B", "C", "D");
		}
		public bool SiLaCarteTalonEst(UnoCardParser parser)
		{
			_deck.Push(parser.Card);
			return true;
		}

		public bool LeJoueurPeutPoser(string playerName, UnoCardParser parser)
		{
			return _unoGame.Player(playerName).CanPlay(parser.Card);
		}

		public bool LeJoueurNePeutPasPoser(string playerName, UnoCardParser parser)
		{
			return !_unoGame.Player(playerName).CanPlay(parser.Card);
		}

		public bool SiLeJoueurPose(string playerName, UnoCardParser parser)
		{
			_unoGame.Player(playerName).Plays(parser.Card);
			return true;
		}

		public string AlorsCestLetourDuJoueur()
		{
			return _unoGame.PlayerToPlay.Name;
		}
	}
}
