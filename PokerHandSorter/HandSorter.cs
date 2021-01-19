using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PokerHandSorter.Ranker;

namespace PokerHandSorter
{
    class HandSorter
    {
        
    }

    public enum SuitEnum
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public class Card
    {
        public int Value;

        public SuitEnum Suit;
    }


    class Hand : IHand
    {
        List<Card> cards = new List<Card>();

        public Hand()
        {

        }

        public Hand(string cardsString)
        {

        }

        /// <summary>
        /// True if hand consist of cards with the same suit
        /// </summary>
        public bool IsSameSuit {
            get
            {
                var suit = cards.First().Suit;

                return cards.Where(card => card.Suit != suit).Any();
            }
        }



        public (int rank, int value) Rank
        {
            get
            {

                throw new NotImplementedException();
            }
        }

        public ICollection<Card> SortedDescending
        {
            get
            {
                throw new NotImplementedException();
            }
        } 

        public static bool operator > (Hand lhs, Hand rhs)
        {
            if(lhs.Rank.rank > rhs.Rank.rank)
            {
                return true;
            }
            else
            {
                return lhs.Rank.rank == rhs.Rank.rank && lhs.Rank.value > rhs.Rank.value;
            }
            
        }

        public static bool operator < (Hand lhs, Hand rhs)
        {
            return true;
        }
    }
}
