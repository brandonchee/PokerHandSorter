using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PokerHandSorter.Utilities;

namespace PokerHandSorter.Ranker
{
    public class RoyalFlush : IRanker
    {
        public int Rank => 10;

        public (bool isMatch, int rank, Card highestCard) IsMatch(IHand hand)
        {
            //hand must be of the same suit for a royal flush
            if (!hand.IsSameSuit)
            {
                return (false, -1, null);
            }

            //value of a royal flush is the same with a straight flush with 10 as the starting value
            var expectedRoyalSum = MathUtil.ArithmeticSeries(5, 10, 1);

            //get sum value of current hand
            var handSum = hand.SortedDescending.Sum(card => card.Value);

            if (handSum == expectedRoyalSum)
            {
                return (true, Rank, hand.SortedDescending.Last());
            }

            return (false, -1, null);
        }
    }
}
