using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    class Program
    {
        static void Main(string[] args)/*this is a semantic*/
        {
            /*System.Console.WriteLine(); system is a namespace, console is under system, but with the 'using', we can skip typing System.*/

            // for turn.cs
            /*int side;
            string color;

            Turn game = new Turn(20, "red");
            game.Result();

            Console.ReadKey();*/

            //for turn1.cs

            //new cause an instance (occurance) of the specified
            //   class to be created and placed in the
            //   receiving variable
            //the variable is a pointer address to the actual
            //   physical memory location of the instance


            //declaring an instance (occurance) of the specified
            //   class will not create a physical instance, just a 
            //   a pointer which can hold a physical instance
            Turn1 theTurn;
            List<Turn1> rounds = new List<Turn1>();
            //new cause the constructor of a class to execute
            //   and a phyiscal instance to be created
            Die Player1 = new Die();
            Die Player2 = new Die(6,"Green");
            


            string menuChoice = "";
            do
            {
                //Console is a static class
                Console.WriteLine("\nMake a choice\n");
                Console.WriteLine("A) Roll");
                Console.WriteLine("B) Set number of dice sides");
                Console.WriteLine("C) Display Current Game Stats");
                Console.WriteLine("X) Exit\n");
                Console.Write("Enter your choice:\t");
                menuChoice = Console.ReadLine();

                //user friendly error handling
                try
                {
                    switch (menuChoice.ToUpper())
                    {
                        case "A":
                            {
                                //Turn is a non-static class
                                theTurn = new Turn1();
                                //generate a new FaceValue
                                Player1.Roll();
                                //generate a new FaceValue
                                Player2.Roll();
                                // save the roll 
                                theTurn.Player1 = Player1.FaceValue; //these are properties(respected variables), the left side of = is a set, the right side of = is get
                                theTurn.Player2 = Player2.FaceValue;

                                //display the round results
                                Console.WriteLine("Player 1 rolled {0}", theTurn.Player1);
                                Console.WriteLine("Player 2 rolled {0}", Player2.FaceValue);
                                //track the round
                                if (Player1.FaceValue > Player2.FaceValue)
                                {
                                    Console.WriteLine("Player 1 wins.");
                                }
                                else
                                {
                                    if (Player2.FaceValue > Player1.FaceValue)
                                    {
                                        Console.WriteLine("Player 2 wins.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Draw.");
                                    }
                                }
                                rounds.Add(theTurn);
                                break;
                            }
                        case "B":
                            {
                                string inputSides = "";
                                int sides = 0;

                                Console.Write("Enter your number of desired sides (greater than 1):\t");
                                inputSides = Console.ReadLine();

                                //using the conversion try version of parsing
                                // TryParse has two parameters
                                // one: in string to convert
                                // two: the output conversion value if the string can be
                                //      converted
                                // successful conversion returns a true bool
                                // failed conversion returns a false bool
                                if (int.TryParse(inputSides, out sides))
                                {
                                    //validation of the incoming value
                                    if (sides > 1)
                                    {
                                        //set the die instance Sides
                                        Player1.Side = sides;
                                        Player2.Side = sides;
                                    }
                                    else
                                    {
                                        throw new Exception("You did not enter a numeric value greater than 1.");
                                    }
                                }
                                else
                                {
                                    throw new Exception("You did not enter a numeric value.");
                                }
                                break;
                            }
                        case "C":
                            {
                                //Display the current players' stats
                                break;
                            }
                        case "X":
                            {
                                //Display the final players' stats
                                Console.WriteLine("\nThank you for playing.");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Your choice was invalid. Try again.");
                                break;
                            }   
                    }//eos
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: " + ex.Message);
                    Console.ResetColor();
                }
            } while (menuChoice.ToUpper() != "X");


        }
        public static void DisplayCurrentPlayerStats(?????)
        {

            int wins1 = 0;
            int wins2 = 0;
            int draws = 0;

            //travser the List<Turn> to calculate wins, losses, and draws


            //display the results
            Console.WriteLine("\n Total Rounds: " + (wins1 + wins2 + draws).ToString());
            Console.WriteLine("\nPlayer1: Wins: {0}  Player2: Wins: {1}  Total Draws: {2}",
                wins1, wins2, draws);

        }
    }
}
