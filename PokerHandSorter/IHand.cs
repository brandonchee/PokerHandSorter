using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandSorter
{
    public interface IHand
    {
        (int rank, int value) Rank { get; }

        bool IsSameSuit { get; }

        ICollection<Card> SortedDescending { get; }
    }
}
