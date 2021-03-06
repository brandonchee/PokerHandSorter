﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PokerHandSorter.Utilities;

namespace PokerHandSorter.Ranker
{
    /// <summary>
    /// Ten, Jack, Queen, King and Ace in the same suit
    /// </summary>
    public class RoyalFlush : IRanker
    {
        public int Rank => 10;

        public (bool isMatch, int rank, Card highestCard) IsMatch(Hand hand)
        {
            //royal flush must start with a 10
            if(hand.CardCollection.First().Value != 10)
            {
                return (false, -1, null);
            }

            //hand must be of the same suit for a royal flush
            if (!hand.IsSameSuit)
            {
                return (false, -1, null);
            }

            //is in series?
            var cards = hand.CardCollection.ToList();

            for (int i = 1; i < cards.Count; i++)
            {
                //no, not in series
                if (cards[i].Value != cards[i - 1].Value + 1)
                {
                    return (false, -1, null);
                }
            }

            //card collection is sorted. last card has the highest value
            return (true, Rank, hand.CardCollection.Last());
        }
    }
}
