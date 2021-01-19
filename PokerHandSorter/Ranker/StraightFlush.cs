using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PokerHandSorter.Utilities;

namespace PokerHandSorter.Ranker
{
    /// <summary>
    /// All five cards in consecutive value order, with the same suit
    /// </summary>
    public class StraightFlush : IRanker
    {
        public int Rank => 9;

        public (bool isMatch, int rank, Card highestCard) IsMatch(Hand hand)
        {
            //hand must be of the same suit for a straight flush
            if (!hand.IsSameSuit)
            {
                return (false, -1, null);
            }

            //is in series?
            var cards = hand.CardCollection.ToList();

            for (int i = 1; i < cards.Count; i++)
            {

                if (cards[i].Value != cards[i - 1].Value + 1)
                {
                    //no, not in series
                    return (false, -1, null);
                }
            }

            //card collection is sorted. last card has the highest value
            return (true, Rank, hand.CardCollection.Last());
        }
    }
}
