using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PokerHandSorter.Ranker
{
    /// <summary>
    /// Highest value card
    /// </summary>
    public class HighCard : IRanker
    {
        public int Rank => 1;

        public (bool isMatch, int rank, Card highestCard) IsMatch(Hand hand)
        {
            //card collection is sorted. last card has the highest value
            return (true, Rank, hand.CardCollection.Last());
        }
    }
}
