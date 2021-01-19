using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandSorter
{
    /// <summary>
    /// Player class
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Player's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Hand of 5 cards
        /// </summary>
        public Hand Hand { get; set; } = new Hand();

        /// <summary>
        /// Current score
        /// </summary>
        public int Score { get; set; }
        
    }
}
