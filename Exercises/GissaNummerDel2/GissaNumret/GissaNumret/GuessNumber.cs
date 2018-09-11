using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GissaNumret
{
    /// <summary>
    /// This class is the main game. It loops until the user chose to exit the game
    /// </summary>
    class GuessNumber
    {
        private bool runGame;

        /// <summary>
        ///  Initialize a new game. 
        /// </summary>
        /// <param name="start">True creates a new game, false doesn't</param>
        public GuessNumber(bool start)
        {
            runGame = start;
        }

        /// <summary>
        ///  Starts The Game
        /// </summary>
        public void PlayGame()
        {
            if (runGame)
            {

                //Create a score board holding the name and result of all rounds
                ArrayList scoreBoard = new ArrayList();
                
                String userInput;

                do
                {
                    //New game. Clear the screen
                    Console.Clear();


                    //Create random number 1 to 100
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

                                    Console.WriteLine("Skriv ditt namn så sparas ditt resultat: ");
                                        
                                    //Add the score to the score board
                                    scoreBoard.Add(new Score() { Name = Console.ReadLine(), Guess = numberOfGuesees });

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

                //User want to exit, save the highscore
                HighScore hs = new HighScore();

                //Try to save the current highscore.
                //Let the user know if the save was successful
                if (!hs.SaveScore(scoreBoard))
                {
                    Console.WriteLine("Något gick fel när listan sparades. Kontakta din systemadministratör");
                } else
                {
                    Console.WriteLine(  "Nya resultat har lagts till i Highscore \n" +
                                        "Tack för idag!");
                    Console.ReadKey();
                }
            }
        }
    }


}

