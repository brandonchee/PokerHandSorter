using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PokerHandSorter.Ranker
{
    /// <summary>
    /// All five cards having the same suit
    /// </summary>
    public class Flush : IRanker
    {
        public int Rank => 6;

        public (bool isMatch, int rank, Card highestCard) IsMatch(Hand hand)
        {
            if (hand.IsSameSuit)
            {
                //card collection is sorted. last card has the highest value
                return (true, Rank, hand.CardCollection.Last());
            }

            return (false, -1, null);
        }
    }
}
