﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardLib
{
	public class Deck : ICloneable
	{
		//private Card[] cards;
		private Cards cards = new Cards();

		public Deck()
		{
			//cards = new Card[52];
			for (int suitVal = 0; suitVal < 4; suitVal++)
			{
				for (int rankVal = 1; rankVal < 14; rankVal++)
				{
					//cards[suitVal * 13 + rankVal - 1] = new Card((Suit)suitVal, (Rank)rankVal);
					cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
				}
			}
		}

		private Deck(Cards newCards) => cards = newCards;

		public Card GetCard(int cardNum)
		{
			if (cardNum >= 0 && cardNum <= 51)
			{
				return cards[cardNum];
			}
			else
			{
				throw (new System.ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between 0 and 51"));
			}
		}

		public void Shuffle()
		{
			//Card[] newDeck = new Card[52];
			Cards newDeck = new Cards();
			bool[] assigned = new bool[52];
			Random sourceGen = new Random();
			for (int i = 0; i < 52; i++)
			{
				int souseCard = 0;
				bool foundCard = false;
				while (foundCard == false)
				{
					souseCard = sourceGen.Next(52);
					if (assigned[souseCard] == false)
					{
						foundCard = true;
					}
				}
				assigned[souseCard] = true;
				//newDeck[destCard] = cards[i];
				newDeck.Add(cards[souseCard]);
			}
			//newDeck.CopyTo(cards, 0);
			newDeck.CopyTo(cards);
		}

		public object Clone()
		{
			Deck newDeck = new Deck(cards.Clone() as Cards);
			return newDeck;
		}
	}
}