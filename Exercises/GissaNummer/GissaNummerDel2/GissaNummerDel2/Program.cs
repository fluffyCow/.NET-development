using System;

namespace GissaNummerDel2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create random numver 1 to 100
            Random random = new Random();
            int numberToGuess = random.Next(1, 101);

            String userInput;

            do
            {
                //Reset the try counter
                int numberOfGuesees = 0;

                //New game. Clear screen
                Console.Clear();

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
                    if (userInput != "x" && userInput != "n") {

                        //Try to parse the answer into an integer
                        if (Int32.TryParse(userInput, out int guessedNumber))
                        {
                            //Valid answer
                            //Increase how many guesses the user has done
                            numberOfGuesees++;

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
                                Console.WriteLine("Görsnyggt! Grattis, du gissade rätt efter försök nummer " +
                                    numberOfGuesees.ToString() + "!");

                                //Ask the user to try again or exit, loop until valid answer
                                do
                                {
                                    Console.WriteLine("Vill du spela igen? tryck n för nytt spel eller x för att avsluta: ");
                                    userInput = Console.ReadLine();
                                } while(userInput != "n" && userInput != "x");
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
        }
    }
    
}
