using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandSorter.Ranker
{
    /// <summary>
    /// Two different pairs
    /// </summary>
    public class TwoPairs : IRanker
    {
        public int Rank => 3;

        public (bool isMatch, int rank, Card highestCard) IsMatch(Hand hand)
        {
            //get 3 of a kind
            var firstPair = hand.CardCollection.GroupBy(card => card.Value)
                .Where(grp => grp.Count() == 2)
                .FirstOrDefault()? //get the first group that has a match (in this case, one or none)
                .FirstOrDefault(); //get a card from this pair

            //we have a pair. we'll exclude these and see if we still have another pair
            if (firstPair != null)
            {
                var secondPair = hand.CardCollection
                    .Where(card => card.Value != firstPair.Value)
                    .GroupBy(card => card.Value)
                    .Where(grp => grp.Count() == 2)
                    .FirstOrDefault()? //get the first group that has a match (in this case, one or none)
                    .FirstOrDefault(); //get a card from this second pair

                if (secondPair != null)
                {
                    //return the highest valued pair as the highestCard for this rank
                    return (true, Rank, firstPair.Value > secondPair.Value ? firstPair : secondPair);
                }
            }

            return (false, -1, null);

        }
    }
}
