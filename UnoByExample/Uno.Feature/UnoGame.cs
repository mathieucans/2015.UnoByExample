using System;
using System.Collections.Generic;
using System.Linq;

namespace Uno.Feature
{
	public class UnoGame
	{
		private List<Player> _players;
		private readonly Turn _turn;
		private readonly IEnumerable<IRule> _rules;
		private readonly Stack<UnoCard> _playedCardSet;

		public UnoGame(Stack<UnoCard> playedCardSet, params string[] playernames)
		{
			_playedCardSet = playedCardSet;
			_players = new List<Player>();
			foreach (var name in playernames)
			{
				_players.Add(new Player(name));
			}
			_turn = new Turn(_players);

			_rules = new IRule[]
			{				
				new InterruptionStealTurn(_turn),				
				new PlayCardPushCardIfAllowed(playedCardSet, CanPlayCommand),
				new PlayCardUpdateTurnToNextPlayer(_turn),				
				new CumulSameCardBehaviour(
					new IRule[] {						
						new JumpUpdateTurnToNextPlayer(_turn),
						},
					playedCardSet
				),
			};
		}

		public UnoCard Last
		{
			get { return _playedCardSet.Peek(); }
		}

		public Player PlayerToPlay { get { return _turn.PlayerToPlay; } }

		public List<Player> Players
		{
			set { _players = value; }
			get { return _players; }
		}

		public PlayOperation Player(string name)
		{
			return new PlayOperation(_players.First(s => s.Name == name), PlayCommand, CanPlayCommand);
		}

		private bool CanPlayCommand(Player player, UnoCard card)
		{
			return (PlayerToPlay == player && (card.Id == Last.Id 
						|| card.Color == Last.Color
						|| card.IsWild))
						|| (card.Equals(Last));
		}

		private void PlayCommand(Player player, UnoCard card)
		{
			foreach (var rule in _rules)
			{
				rule.Apply(player, card);				
			}		
		}
	}

	public class PlayCardPushCardIfAllowed : IRule
	{
		private readonly Stack<UnoCard> _playedCardSet;
		private readonly Func<Player, UnoCard, bool> _canPlayCommand;

		public PlayCardPushCardIfAllowed(Stack<UnoCard> playedCardSet, Func<Player, UnoCard, bool> canPlayCommand)
		{
			_playedCardSet = playedCardSet;
			_canPlayCommand = canPlayCommand;
		}

		public void Apply(Player player, UnoCard card)
		{
			if (_canPlayCommand(player, card))
			{
				_playedCardSet.Push(card);
			}
		}
	}
}