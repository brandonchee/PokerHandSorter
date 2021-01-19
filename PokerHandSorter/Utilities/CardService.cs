using System;
using System.Collections.Generic;
using System.Text;
using PokerHandSorter.Enums;
using PokerHandSorter.Ranker;
using System.Linq;

namespace PokerHandSorter.Utilities
{
    /// <summary>
    /// Provide service/utility that is commonly used. Can be turn into proper service with DI.
    /// </summary>
    public class CardService
    {
        /// <summary>
        /// Mapping between card value char representation to a value
        /// </summary>
        Dictionary<char, int> cardValueMap = new Dictionary<char, int>();

        /// <summary>
        /// Mapping between a card suit symbol to SuitEnum
        /// </summary>
        Dictionary<char, SuitEnum> cardSuitMap = new Dictionary<char, SuitEnum>();

        /// <summary>
        /// List of ranker that will be used to rank a hand.
        /// </summary>
        List<IRanker> rankers = new List<IRanker>();

        /// <summary>
        /// Constructor initialises maps
        /// </summary>
        public CardService()
        {
            InitialiseCardValueMap();

            InitialiseSuitMap();

            InitialiseRankers();
        }

        /// <summary>
        /// Initialise mapping data for card value
        /// </summary>
        void InitialiseCardValueMap()
        {
            cardValueMap.Add('2', 2);
            cardValueMap.Add('3', 3);
            cardValueMap.Add('4', 4);
            cardValueMap.Add('5', 5);
            cardValueMap.Add('6', 6);
            cardValueMap.Add('7', 7);
            cardValueMap.Add('8', 8);
            cardValueMap.Add('9', 9);
            cardValueMap.Add('T', 10);
            cardValueMap.Add('J', 11);
            cardValueMap.Add('Q', 12);
            cardValueMap.Add('K', 13);
            cardValueMap.Add('A', 14);
        }

        /// <summary>
        /// Initialise mapping data for card suit
        /// </summary>
        void InitialiseSuitMap()
        {
            cardSuitMap.Add('C', SuitEnum.Clubs);
            cardSuitMap.Add('D', SuitEnum.Diamonds);
            cardSuitMap.Add('H', SuitEnum.Hearts);
            cardSuitMap.Add('S', SuitEnum.Spades);
        }

        /// <summary>
        /// Initialise list of rankers
        /// </summary>
        void InitialiseRankers()
        {
            rankers.Add(new RoyalFlush());
            rankers.Add(new StraightFlush());
            rankers.Add(new FourOfAKind());
            rankers.Add(new FullHouse());
            rankers.Add(new Flush());
            rankers.Add(new Straight());
            rankers.Add(new ThreeOfAKind());
            rankers.Add(new TwoPairs());
            rankers.Add(new Pair());
            rankers.Add(new HighCard());

            //Sort by descending rank. The order is important as we'll be looking for a match with the higest ranking first.
            rankers = rankers.OrderByDescending(ranker => ranker.Rank).ToList();
        }

        public bool TryGetCardValue(char c, out int value)
        {
            return cardValueMap.TryGetValue(c, out value);
        }

        public bool TryGetCardSuit(char c, out SuitEnum suit)
        {
            return cardSuitMap.TryGetValue(c, out suit);
        }

        public (int rank, Card highestCard) GetRanking(Hand hand)
        {
            //match hand to rank.
            foreach (var ranker in rankers)
            {
                var result = ranker.IsMatch(hand);

                if (result.isMatch)
                {
                    return (result.rank, result.highestCard);
                }
            }

            throw new ArgumentException("Hand has an unknown rank");
        }
    }
}
