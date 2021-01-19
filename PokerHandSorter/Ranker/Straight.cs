using PokerHandSorter.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandSorter.Ranker
{
    /// <summary>
    /// All five cards in consecutive value order
    /// </summary>
    public class Straight : IRanker
    {
        public int Rank => 5;

        public (bool isMatch, int rank, Card highestCard) IsMatch(Hand hand)
        {
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
