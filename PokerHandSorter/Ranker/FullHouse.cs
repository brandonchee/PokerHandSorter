using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PokerHandSorter.Ranker
{
    /// <summary>
    /// Three of a kind and a Pair
    /// </summary>
    public class FullHouse : IRanker
    {
        public int Rank => 7;

        public (bool isMatch, int rank, Card highestCard) IsMatch(Hand hand)
        {
            //get 3 of a kind
            var result = hand.CardCollection.GroupBy(card => card.Value)
                .Where(grp => grp.Count() == 3)
                .FirstOrDefault()? //get the first group that has a match (in this case, one or none)
                .FirstOrDefault(); //get a card from this triplet

            //we have 3 of a kind. we'll exclude these and see if we still have a pair
            if (result != null)
            {
                var hasPair = hand.CardCollection
                    .Where(card => card.Value != result.Value)
                    .GroupBy(card => card.Value)
                    .Where(grp => grp.Count() == 2)
                    .Any();

                if (hasPair)
                {
                    //we return 1 of the triple as the highest card for this rank
                    return (true, Rank, result);
                }
            }

            return (false, -1, null);

        }
    }
}
