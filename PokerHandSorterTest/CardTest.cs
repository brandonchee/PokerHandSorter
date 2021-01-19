using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandSorter;
using PokerHandSorter.Enums;
using PokerHandSorter.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandSorterTest
{
    [TestClass]
    public class CardTest
    {
        /// <summary>
        /// Create sample data for testing
        /// </summary>
        /// <returns></returns>
        List<string> CreateSamples()
        {
            return new List<string>() { 
                //royal flush
                "TC JC QC KC AC",
            
                //straight flush
                "9C TC JC QC KC",
                "2C 3C 4C 5C 6C",

                //four of a kind
                "KC KD KH KS 3C",
                "2C 2D 2H 2S 4C",

                //full house
                "QS QC QD 2D 2S",
                "3S 3C 3D AD AS",

                //flush
                "3H 5H 7H 9H JH",
                "2H 4H 6H 8H TH",
            
                //"straight
                "3C 4D 5H 6S 7C",
                "2C 3D 4H 5S 6C",

                //three of a kind
                "KD KC KS 3C 4C",
                "2D 2C 2S 5C 6C",

                //two pairs
                "QC QC 2D 2D 4D",
                "2C 2C 3H 3H 8H",

                //pairs
                "QC QC 2D 3D 4D",
                "2C 2C 6H 7H 8H",

                //high card
                "3C 4D 5H 6S AC",
                "2C 3D 4H 5S QC",
            };
        }
        
        /// <summary>
        /// Overloaded operator > in class Hand is used to determine if a player has the winning hand.
        /// This test will ensure that the comparison operator is giving the expected results with our crafted sample data.
        /// Sample data is in descending order in terms of scoring (to win).
        /// </summary>
        [TestMethod]
        public void TestRankingCompareOperator()
        {
            
            Player p1 = new Player() { Name = "Player 1" };
            Player p2 = new Player() { Name = "Player 2" };

            //Sample data is in ascending order of ranking. 
            var hands = CreateSamples();

            for (int currentIndex = 0; currentIndex < hands.Count; currentIndex++)
            {
                p1.Hand.ChangeHand(hands[currentIndex]); ;

                //test higher ranks
                for (int i = 0; i < currentIndex; i++)
                {
                    p2.Hand.ChangeHand(hands[i]);

                    Assert.IsFalse(p1.Hand > p2.Hand);
                }

                //test lower ranks
                for (int i = currentIndex + 1; i < hands.Count; i++)
                {
                    p2.Hand.ChangeHand(hands[i]);

                    Assert.IsTrue(p1.Hand > p2.Hand);
                }
            }                
        }

        /// <summary>
        /// This test ensure that only a royal flush pattern will match. This is done by using our sample and counting the number of successful matches
        /// </summary>
        [TestMethod]
        public void TestRoyalFlush()
        {
            Player p1 = new Player() { Name = "Player 1" };

            var hands = CreateSamples();

            int matchCount = 0;

            foreach(var hand in hands)
            {
                p1.Hand.ChangeHand(hand);

                if(p1.Hand.Rank.rank == 10)
                {
                    matchCount++;
                }
            }

            Assert.IsTrue(matchCount == 1);
        }

        /// <summary>
        /// This test ensure that only a straight flush pattern will match. This is done by using our sample and counting the number of successful matches
        /// </summary>
        [TestMethod]
        public void TestStraightFlush()
        {
            Player p1 = new Player() { Name = "Player 1" };

            var hands = CreateSamples();

            int matchCount = 0;

            foreach (var hand in hands)
            {
                p1.Hand.ChangeHand(hand);

                if (p1.Hand.Rank.rank == 9)
                {
                    matchCount++;
                }
            }

            Assert.IsTrue(matchCount == 2);
        }

        /// <summary>
        /// This test ensure that only a four of a kind pattern will match. This is done by using our sample and counting the number of successful matches
        /// </summary>
        [TestMethod]
        public void TestFourOfAKind()
        {
            Player p1 = new Player() { Name = "Player 1" };

            var hands = CreateSamples();

            int matchCount = 0;

            foreach (var hand in hands)
            {
                p1.Hand.ChangeHand(hand);

                if (p1.Hand.Rank.rank == 8)
                {
                    matchCount++;
                }
            }

            Assert.IsTrue(matchCount == 2);
        }

        /// <summary>
        /// This test ensure that only a full house pattern will match. This is done by using our sample and counting the number of successful matches
        /// </summary>
        [TestMethod]
        public void TestFullHouse()
        {
            Player p1 = new Player() { Name = "Player 1" };

            var hands = CreateSamples();

            int matchCount = 0;

            foreach (var hand in hands)
            {
                p1.Hand.ChangeHand(hand);

                if (p1.Hand.Rank.rank == 7)
                {
                    matchCount++;
                }
            }

            Assert.IsTrue(matchCount == 2);
        }

        /// <summary>
        /// This test ensure that only a flush pattern will match. This is done by using our sample and counting the number of successful matches
        /// </summary>
        [TestMethod]
        public void TestFlush()
        {
            Player p1 = new Player() { Name = "Player 1" };

            var hands = CreateSamples();

            int matchCount = 0;

            foreach (var hand in hands)
            {
                p1.Hand.ChangeHand(hand);

                if (p1.Hand.Rank.rank == 6)
                {
                    matchCount++;
                }
            }

            Assert.IsTrue(matchCount == 2);
        }

        /// <summary>
        /// This test ensure that only a straight pattern will match. This is done by using our sample and counting the number of successful matches
        /// </summary>
        [TestMethod]
        public void TestStraight()
        {
            Player p1 = new Player() { Name = "Player 1" };

            var hands = CreateSamples();

            int matchCount = 0;

            foreach (var hand in hands)
            {
                p1.Hand.ChangeHand(hand);

                if (p1.Hand.Rank.rank == 5)
                {
                    matchCount++;
                }
            }

            Assert.IsTrue(matchCount == 2);
        }

        /// <summary>
        /// This test ensure that only a three of a kind pattern will match. This is done by using our sample and counting the number of successful matches
        /// </summary>
        [TestMethod]
        public void TestThreeOfAKind()
        {
            Player p1 = new Player() { Name = "Player 1" };

            var hands = CreateSamples();

            int matchCount = 0;

            foreach (var hand in hands)
            {
                p1.Hand.ChangeHand(hand);

                if (p1.Hand.Rank.rank == 4)
                {
                    matchCount++;
                }
            }

            Assert.IsTrue(matchCount == 2);
        }

        /// <summary>
        /// This test ensure that only a two pairs pattern will match. This is done by using our sample and counting the number of successful matches
        /// </summary>
        [TestMethod]
        public void TestTwoPairs()
        {
            Player p1 = new Player() { Name = "Player 1" };

            var hands = CreateSamples();

            int matchCount = 0;

            foreach (var hand in hands)
            {
                p1.Hand.ChangeHand(hand);

                if (p1.Hand.Rank.rank == 3)
                {
                    matchCount++;
                }
            }

            Assert.IsTrue(matchCount == 2);
        }

        /// <summary>
        /// This test ensure that only a pair pattern will match. This is done by using our sample and counting the number of successful matches
        /// </summary>
        [TestMethod]
        public void TestPairs()
        {
            Player p1 = new Player() { Name = "Player 1" };

            var hands = CreateSamples();

            int matchCount = 0;

            foreach (var hand in hands)
            {
                p1.Hand.ChangeHand(hand);

                if (p1.Hand.Rank.rank == 2)
                {
                    matchCount++;
                }
            }

            Assert.IsTrue(matchCount == 2);
        }

        /// <summary>
        /// This test ensure that only a high card pattern will match. This is done by using our sample and counting the number of successful matches
        /// </summary>
        [TestMethod]
        public void TestHighCard()
        {
            Player p1 = new Player() { Name = "Player 1" };

            var hands = CreateSamples();

            int matchCount = 0;

            foreach (var hand in hands)
            {
                p1.Hand.ChangeHand(hand);

                if (p1.Hand.Rank.rank == 1)
                {
                    matchCount++;
                }
            }

            Assert.IsTrue(matchCount == 2);
        }

        /// <summary>
        /// Test Card creation when parsing/mapping from string
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.FormatException))]
        public void TestCardParsing()
        {
            var cardService = new CardService();

            Card card3C = new Card("3C", cardService);

            Assert.AreEqual(card3C.Value, 3);
            Assert.AreEqual(card3C.Suit, SuitEnum.Clubs);

            //we are expecting this to generate and exception and thus will be null.
            Card card10C = new Card("10C", cardService);
            Assert.IsNull(card10C);


            Card card3G = new Card("3G", cardService);
            Assert.IsNull(card10C);
        }

        /// <summary>
        /// Test hand accuracy after changing hands
        /// </summary>
        [TestMethod]
        public void TestChangeOfHand()
        {
            //initial empty hand
            Hand hand = new Hand();

            var cards = hand.CardCollection.ToList();

            Assert.IsTrue(cards.Count == 0);

            //change hand
            hand.ChangeHand("2C 3D TS QH AC");

            cards = hand.CardCollection.ToList();

            Assert.IsTrue(cards.Count == 5);

            Assert.IsTrue(cards[0].Value == 2 && cards[0].Suit == SuitEnum.Clubs);
            Assert.IsTrue(cards[1].Value == 3 && cards[1].Suit == SuitEnum.Diamonds);
            Assert.IsTrue(cards[2].Value == 10 && cards[2].Suit == SuitEnum.Spades);
            Assert.IsTrue(cards[3].Value == 12 && cards[3].Suit == SuitEnum.Hearts);
            Assert.IsTrue(cards[4].Value == 14 && cards[4].Suit == SuitEnum.Clubs);
        }

        /// <summary>
        /// Hand should always be sorted (ascending)
        /// </summary>
        [TestMethod]
        public void TestHandSort()
        {
            Hand hand = new Hand("2C AD 5S 6H QC");

            var cards = hand.CardCollection.ToList();

            Assert.IsTrue(cards[0].Value == 2 && cards[0].Suit == SuitEnum.Clubs);
            Assert.IsTrue(cards[1].Value == 5 && cards[1].Suit == SuitEnum.Spades);
            Assert.IsTrue(cards[2].Value == 6 && cards[2].Suit == SuitEnum.Hearts);
            Assert.IsTrue(cards[3].Value == 12 && cards[3].Suit == SuitEnum.Clubs);
            Assert.IsTrue(cards[4].Value == 14 && cards[4].Suit == SuitEnum.Diamonds);
        }
    }
}
