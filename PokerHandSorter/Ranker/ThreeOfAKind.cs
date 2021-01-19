using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandSorter.Ranker
{
    /// <summary>
    /// Three cards of the same value
    /// </summary>
    public class ThreeOfAKind : IRanker
    {
        public int Rank => 4;

        public (bool isMatch, int rank, Card highestCard) IsMatch(Hand hand)
        {
            //get 3 of a kind
            var result = hand.CardCollection.GroupBy(card => card.Value)
                .Where(grp => grp.Count() == 3)
                .FirstOrDefault()? //get the first group that has a match (in this case, one or none)
                .FirstOrDefault(); //get a card from this triplet

            if (result != null)
            {
                //we return 1 of the triplet as the highest card for this rank
                return (true, Rank, result);
            }

            return (false, -1, null);

        }
    }
}
