using System;
using System.Collections.Generic;
using System.Linq;

namespace Uno.Feature
{
	public class UnoCardParser
	{

		static Dictionary<string, UnoCardId> _unoCardIdDictionnarDictionary = new Dictionary<string, UnoCardId>()
		{
			{"9", UnoCardId.Nine},
			{"8", UnoCardId.Height},
			{"7", UnoCardId.Seven},
			{"6", UnoCardId.Six},
			{"5", UnoCardId.Five},
			{"4", UnoCardId.Four},
			{"3", UnoCardId.Three},
			{"2", UnoCardId.Two},
			{"1", UnoCardId.One},
			{"0", UnoCardId.Zero},
			{"+2", UnoCardId.DrawTwo},
			{"\"passe\"", UnoCardId.Jump},
			{"joker", UnoCardId.Wild},
			{"+4", UnoCardId.WildDrawFour},
		};

		static Dictionary<string, UnoColor> _unoCardColorDictionnarDictionary = new Dictionary<string, UnoColor>()
		{
			{"rouge", UnoColor.Red},
			{"jaune", UnoColor.Yellow},
			{"bleu", UnoColor.Blue},
			{"vert", UnoColor.Green},
			{"", UnoColor.Black},
		};


		public UnoCardParser(UnoCardId id, UnoColor color)
		{
			Card = new UnoCard(id, color);
		}

		public static UnoCardParser Parse(string s)
		{
			var split = s.ToLower().Replace("un ", String.Empty).Split(' ');
			UnoCardId id = _unoCardIdDictionnarDictionary[split[0]];
			UnoColor color = UnoColor.Black;
			if (split.Length > 1)
			{
				_unoCardColorDictionnarDictionary.TryGetValue(split[1], out color);
			}
			return new UnoCardParser(id, color);
		}

		public override string ToString()
		{
			return "un "
			 + _unoCardIdDictionnarDictionary.First(s => s.Value == Card.Id).Key
			 + " "
			 + _unoCardColorDictionnarDictionary.First(s => s.Value == Card.Color).Key;
		}

		public UnoCard Card { get; private set; }
	}
}