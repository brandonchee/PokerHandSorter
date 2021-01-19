using System;
using System.Collections.Generic;
using System.Text;
using PokerHandSorter.Enums;
using PokerHandSorter.Utilities;

namespace PokerHandSorter
{
    /// <summary>
    /// Represent a card
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Card is in the format of "NS"
        /// N is 1 of the value (2, 3, 4, 5, 6, 7, 8, 9, T, J, Q, K, A)
        /// S is 1 of the suit (C, D, H, S) - Clubs, Diamonds, Hearts, Spades
        /// </summary>
        /// <param name="cardString">Format is "NS"</param>
        /// <param name="cardService">CardService instance</param>
        public Card(string cardString, CardService cardService)
        {
            //length validation
            if (string.IsNullOrEmpty(cardString) || cardString.Length != 2)
            {
                throw new FormatException("cardString format must be in the form of NS where N is the card value and S is the card suit.");
            }

            //get mapped values.
            if (!cardService.TryGetCardValue(cardString[0], out Value) || !cardService.TryGetCardSuit(cardString[1], out Suit))
            {
                throw new FormatException("cardString contains invalid characters.");
            }
        }

        /// <summary>
        /// Value of the card. J, Q, K, A has the value of 11, 12, 13, 14
        /// </summary>
        public int Value;

        /// <summary>
        /// Card suit
        /// </summary>
        public SuitEnum Suit;
    }
}
