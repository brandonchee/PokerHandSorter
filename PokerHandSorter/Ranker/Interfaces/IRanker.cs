using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandSorter.Ranker
{
    /// <summary>
    /// Interface for ranking a hand (sets of 5 cards).
    /// </summary>
    public interface IRanker
    {
        (bool isMatch, int rank, Card highestCard) IsMatch(Hand hand);

        int Rank { get; }
    }
}
