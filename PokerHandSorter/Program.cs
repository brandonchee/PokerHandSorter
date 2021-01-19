using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PokerHandSorter
{
    class Program
    {
        /// <summary>
        /// Entry pointn of this program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //top level try catch allow us to handle unexpected errors gracefully and log it.
            try
            {
                //create our players and give them names.
                var player1 = new Player() { Name = "Player 1" };
                var player2 = new Player() { Name = "Player 2" };

#if DEBUG
                //collect statistics of rank and occurence for debug
                List<int> rankAndCount = new List<int>();

                //create an index for each hand rank
                for (int i = 0; i < 10; i++)
                {
                    rankAndCount.Add(0);
                }
#endif

                //keep track of lines processed. this allow us to give more meaningful error in case of a bad input
                int lineCount = 0;

                //open STDIN
                using (var inputReader = new StreamReader(Console.OpenStandardInput(), Console.InputEncoding))
                {
                    //read line by line till the end of stream
                    while (!inputReader.EndOfStream)
                    {
                        //we're working on the next line
                        lineCount++;

                        //read line and split into 10 strings representing the current game cards for both players
                        var gameCards = inputReader.ReadLine()?
                            .Trim()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        //ensure that there are 10 string of cards
                        if (gameCards == null || gameCards.Length != 10)
                        {
                            throw new Exception($"A game must consist of 10 cards. 5 for each player. Line {lineCount}");
                        }

                        //change player's hand to the new sets of cards
                        player1.Hand.ChangeHand(gameCards.Take(5).ToArray());

                        player2.Hand.ChangeHand(gameCards.TakeLast(5).ToArray());

#if DEBUG
                        //collect statistics for debug
                        rankAndCount[player1.Hand.Rank.rank - 1] = rankAndCount[player1.Hand.Rank.rank - 1] + 1;
                        rankAndCount[player2.Hand.Rank.rank - 1] = rankAndCount[player2.Hand.Rank.rank - 1] + 1;
#endif

                        //add score for the winning hand
                        if (player1.Hand > player2.Hand)
                        {
                            player1.Score++;
                        }
                        else if (player2.Hand > player1.Hand)
                        {
                            player2.Score++;
                        }
                        else
                        {
                            //unexpected situation where nobody wins
                            throw new Exception($"Player1 and Player2 has the same Rank and highest card value. Line {lineCount}");
                        }
                    }
                }

                //open STDOUT for output
                using (var writer = new StreamWriter(Console.OpenStandardOutput(), Console.OutputEncoding))
                {
                    writer.WriteLine($"{player1.Name}: {player1.Score}.");
                    writer.WriteLine($"{player2.Name}: {player2.Score}.");

                    //ensure data are flushed to stream
                    writer.Flush();
                }
            }
            //Catch all exception for a graceful exit
            catch (Exception ex)
            {
                //write exception message
                using (var writer = new StreamWriter(Console.OpenStandardOutput(), Console.OutputEncoding))
                {
                    //get executable name
                    string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                    string exeName = Path.GetFileName(codeBase);

                    writer.WriteLine($"An unexpected error occured while running {exeName} {ex.Message}");

                    //ensure data are flushed to stream
                    writer.Flush();
                }
            }

        }
    }
}
