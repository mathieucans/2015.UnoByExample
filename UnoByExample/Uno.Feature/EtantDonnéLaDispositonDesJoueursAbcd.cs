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
		public bool SiLaCarteTalonEst(UnoCardParser cardParser)
		{
			_deck.Push(cardParser.Card);
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

		public string EtCestLetourDuJoueur()
		{
			return AlorsCestLetourDuJoueur();
		}

		public bool Alorslejoueurprendsdeuxcartes(string name)
		{
			return true;
		}

		public UnoCardParser Etlacartetalonest()
		{
			var card = _deck.Peek();
			return new UnoCardParser(card.Id, card.Color);
		}
	}
}
