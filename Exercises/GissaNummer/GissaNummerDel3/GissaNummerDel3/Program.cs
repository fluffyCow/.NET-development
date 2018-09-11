using System;

namespace GissaNummerDel3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Create array to the score board
            int[] scoreBoard = new int[1];
            int round=0;

            String userInput;

            do
            {
                //New game. Clear the screen
                Console.Clear();


                //Create random numver 1 to 100
                Random random = new Random();
                int numberToGuess = random.Next(1, 101);

                //Reset the try counter
                int numberOfGuesees = 0;

                Console.WriteLine("Hej och välkommen till gissa talet! \n" +
                        "Du kan när som helst avsluta genom att skriva 'x', eller börja om från början genom att skriva 'n' \n" +
                        "Lycka till! \n \n" +
                        "Gissa ett tal mellan 1 och 100: ");

                //Start guessing and continue until the user is correct or aborted by the user
                do
                {
                    //Get user input
                    userInput = Console.ReadLine();

                    //Make sure the "guess" isn't exit or new comamand
                    if (userInput != "x" && userInput != "n")
                    {

                        //Try to parse the answer into an integer
                        if (Int32.TryParse(userInput, out int guessedNumber))
                        {
                            //Valid answer
                            //Increase how many guesses the user has done
                            numberOfGuesees++;

                            //Save the guess to the score board

                            //Guessed number is too high
                            if (guessedNumber > numberToGuess)
                            {
                                Console.WriteLine("Fel, talet är lägre än det du gissade. \n" +
                                     "Gissa igen, talet ska vara mellan 1 och 100: ");
                            }
                            //guessedNumber number is too low
                            else if (guessedNumber < numberToGuess)
                            {
                                Console.WriteLine("Fel, talet är högre än det du gissade. \n" +
                                       "Gissa igen, talet ska vara mellan 1 och 100: ");
                            }
                            //Guessed number is correct!
                            else
                            {
                                Console.WriteLine("Görsnyggt! Grattis, du gissade rätt efter " + numberOfGuesees + " försök!");

                                //Add the result to the array
                                scoreBoard[round] = numberOfGuesees;
                                
                                //Increase the lenght of the array
                                Array.Resize(ref scoreBoard, scoreBoard.Length+1);

                                //Increase the number of rounds, only do this for completed rounds
                                round++;

                                //Ask the user to try again or exit, loop until valid answer
                                do
                                {
                                    Console.WriteLine("Vill du spela igen? tryck n för nytt spel eller x för att avsluta: ");
                                    userInput = Console.ReadLine();
                                } while (userInput != "n" && userInput != "x");
                            }
                        }
                        else
                        {
                            //Invalid answer (or a invalid command), ask the user to try again
                            Console.WriteLine("Ogiltig gissning. Ange ett tal mellan 1 och 100: ");
                        }
                    }

                    //Continue until new or exit command
                } while (userInput != "x" && userInput != "n");
                
            
                //Continue until exit command
            } while (userInput != "x");

            //If there are any result show the score board, else just exit
            if (scoreBoard.Length > 0)
            {
                Console.Clear();
                Console.WriteLine("Sammanställning över dina resultat:");
                for (int i = 0; i < round; i++)
                {
                    Console.WriteLine("Omgång " + (i+1) + ": " + scoreBoard[i] + " försök.");
                }
                Console.WriteLine("\nTryck på valfri tangent för att avsluta");
                Console.ReadKey();
            }
        }
    }

}
