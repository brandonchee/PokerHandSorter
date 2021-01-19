using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PokerHandSorter.Utilities;

namespace PokerHandSorter.Ranker
{
    public class StraightFlush : IRanker
    {
        public (bool isMatch, int rank, Card highestCard) IsMatch(IHand hand)
        {
            //hand must be of the same suit for a straight flush
            if (!hand.IsSameSuit)
            {
                return (false, -1, null);
            }

            //if it is a straight flush, sum will be an arithmetic series
            //https://en.wikipedia.org/wiki/Arithmetic_progression#:~:text=In%20mathematics,%20an%20arithmetic%20progression%20(AP)%20or%20arithmetic,sequence%205,%207,%209,%2011,%2013,%2015,%20.
            var expectedStraightSum = MathUtil.ArithmeticSeries(5, hand.SortedDescending.First().Value, 1);

            //get sum value of current hand
            var handSum = hand.SortedDescending.Sum(card => card.Value);

            if (handSum == expectedStraightSum)
            {
                return (true, Rank, hand.SortedDescending.Last());
            }

            return (false, -1, null);
        }

        public int Rank => 9;

    }
}
