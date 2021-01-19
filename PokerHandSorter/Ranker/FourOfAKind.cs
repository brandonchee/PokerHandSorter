using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PokerHandSorter.Ranker
{
    /// <summary>
    /// Four cards of the same value
    /// </summary>
    public class FourOfAKind : IRanker
    {
        public int Rank => 8;

        public (bool isMatch, int rank, Card highestCard) IsMatch(Hand hand)
        {
            //get 4 of a kind
            var result = hand.CardCollection.GroupBy(card => card.Value)
                .Where(grp => grp.Count() == 4)
                .FirstOrDefault()? //get the first group that has a match (in this case, one or none)
                .FirstOrDefault(); //get a card from this quad group

            if (result != null)
            {
                return (true, Rank, result);
            }

            return (false, -1, null);
        }
    }
}
