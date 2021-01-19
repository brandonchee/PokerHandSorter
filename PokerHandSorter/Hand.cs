using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PokerHandSorter.Ranker;
using PokerHandSorter.Utilities;

namespace PokerHandSorter
{
    /// <summary>
    /// Represent a hand of 5 cards
    /// </summary>
    public class Hand
    {
        /// <summary>
        /// List of cards. Cards are always sorted once they are modified by calling SortCards()
        /// </summary>
        List<Card> cards = new List<Card>();

        /// <summary>
        /// The ranking for this hand and the higest card of the rank
        /// </summary>
        public (int rank, Card highestCard) Rank { get; private set; }

        /// <summary>
        /// Provide commonly use card services
        /// </summary>
        CardService cardService;

        /// <summary>
        /// Create instance of cardService. This can be inject if using DI
        /// </summary>
        public Hand()
        {
            cardService = new CardService();
        }

        /// <summary>
        /// Takes in a string of 5 cards in the format of "NS NS NS NS NS"
        /// N is 1 of the value (2, 3, 4, 5, 6, 7, 8, 9, T, J, Q, K, A)
        /// S is 1 of the suit (C, D, H, S) - Clubs, Diamonds, Hearts, Spades
        /// </summary>
        /// <param name="cardsString">Format is "NS NS NS NS NS"</param>
        public Hand(string cardsString)
        {
            cardService = new CardService();

            //split string into cards as per the format defined in the design doco
            var cardStr = cardsString.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            ChangeHand(cardStr);
        }

        /// <summary>
        /// Takes an array of 5. Each array is a card string in the format of "NS"
        /// N is 1 of the value (2, 3, 4, 5, 6, 7, 8, 9, T, J, Q, K, A)
        /// S is 1 of the suit (C, D, H, S) - Clubs, Diamonds, Hearts, Spades
        /// </summary>
        /// <param name="cardsString"></param>
        public Hand(string[] cardsString)
        {
            cardService = new CardService();

            ChangeHand(cardsString);
        }

        /// <summary>
        /// Sort cards in ascending order.
        /// </summary>
        void SortCards()
        {
            cards = cards.OrderBy(card => card.Value).ToList();
        }

        /// <summary>
        /// Change hand. Takes in a string of 5 cards in the format of "NS NS NS NS NS"
        /// N is 1 of the value (2, 3, 4, 5, 6, 7, 8, 9, T, J, Q, K, A)
        /// S is 1 of the suit (C, D, H, S) - Clubs, Diamonds, Hearts, Spades
        /// </summary>
        /// <param name="cardsString">Format is "NS NS NS NS NS"</param>
        public void ChangeHand(string cardsString)
        {
            var cardStr = cardsString.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            ChangeHand(cardStr);
        }

        /// <summary>
        /// Change hand with a fresh set of 5 cards in the format of "NS"
        /// N is 1 of the value (2, 3, 4, 5, 6, 7, 8, 9, T, J, Q, K, A)
        /// S is 1 of the suit (C, D, H, S) - Clubs, Diamonds, Hearts, Spades
        /// </summary>
        /// <param name="cardsString">Array of card in the format of "NS"</param>
        public void ChangeHand(string[] cardStr)
        {
            //hand size must be 5
            if (cardStr == null || cardStr.Length != 5)
            {
                throw new Exception("ChangeHand can only be called with 5 cards.");
            }

            //clear existing cards
            cards.Clear();

            //create cards from the array of 5 strings and add them into our card list
            cards.AddRange(cardStr.Select(card => new Card(card?.Trim(), cardService)));

            //cards changed. sort it.
            SortCards();

            //Get ranking for this hand
            Rank = cardService.GetRanking(this);
        }

        /// <summary>
        /// True if hand consist of cards with the same suit, otherwise false
        /// </summary>
        public bool IsSameSuit {
            get
            {
                var suit = cards.First().Suit;

                return !cards.Where(card => card.Suit != suit).Any();
            }
        }

        /// <summary>
        /// Allow cards collection to be accessed but in a read manner only.
        /// </summary>
        public IReadOnlyCollection<Card> CardCollection
        {
            get
            {
                return cards;
            }
        }

        /// <summary>
        /// Determine which hand is the winning hand. Hand1 is the winning hand if Hand1 > OtherHand
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator > (Hand lhs, Hand rhs)
        {
            //rank is higher?
            if (lhs.Rank.rank > rhs.Rank.rank)
            {
                return true;
            }
            //rank is same?
            else if (lhs.Rank.rank == rhs.Rank.rank)
            {
                //ranked card value is higher?
                if (lhs.Rank.highestCard.Value > rhs.Rank.highestCard.Value)
                {
                    return true;
                }
                //if rank and ranked card value is the same. we will compare using the highest card in each hand. if the highest cards tie then the
                //next highest cards are compared, and so on
                else if(lhs.Rank.highestCard.Value == rhs.Rank.highestCard.Value)
                {
                    //cards are sorted. so we'll compare from the last card (the highest value)
                    for(int i = lhs.cards.Count - 1; i >= 0; i--)
                    {
                        //highest card is higher?
                        if(lhs.cards[i].Value > rhs.cards[i].Value)
                        {
                            return true;
                        }
                        //highest card is lower? return false;
                        else if(lhs.cards[i].Value < rhs.cards[i].Value)
                        {
                            return false;
                        }
                    }

                    throw new InvalidOperationException("Both hands are in the same rank.");
                }
            }

            return false;
        }

        /// <summary>
        /// This is needed to complement the above greater than operator. Will only implement if necessary
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator < (Hand lhs, Hand rhs)
        {
            throw new NotImplementedException();
        }
    }
}
