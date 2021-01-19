using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandSorter.Ranker
{
    /// <summary>
    /// Two cards of same value
    /// </summary>
    public class Pair : IRanker
    {
        public int Rank => 2;

        public (bool isMatch, int rank, Card highestCard) IsMatch(Hand hand)
        {
            //get 3 of a kind
            var result = hand.CardCollection.GroupBy(card => card.Value)
                .Where(grp => grp.Count() == 2)
                .FirstOrDefault()? //get the first group that has a match (in this case, one or none)
                .FirstOrDefault(); //get a card from this pair

            if (result != null)
            {
                //we return 1 of the pair as the highest card for this rank
                return (true, Rank, result);
            }

            return (false, -1, null);

        }
    }
}
