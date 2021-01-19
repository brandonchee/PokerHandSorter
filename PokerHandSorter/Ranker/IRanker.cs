using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandSorter.Ranker
{
    public interface IRanker
    {
        (bool isMatch, int rank, Card highestCard) IsMatch(IHand hand);

        int Rank { get; }
    }
}
