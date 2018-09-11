using System;

namespace GissaNummerDel1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create random numver 1 to 100
            Random random = new Random();
            int numberToGuess = random.Next(1, 101);

            int guessedNumber;
            int numberOfGuesees = 0;


            Console.WriteLine("Hej och välkommen till gissa talet! \n" +
                    "Lycka till! \n \n" +
                    "Gissa ett tal mellan 1 och 100: ");

            //Start guessing and continue until the user is correct
            do
            {
                //Increase how many guesses the user has done
                numberOfGuesees++;

                //Wait for user input and try to parse it into an integer
                if (Int32.TryParse(Console.ReadLine(), out guessedNumber))
                {
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
                        Console.ReadKey();
                    }
                }
                else
                {
                    //If the guessed number is not a number, invalidate the guess and ask the user to try again
                    numberOfGuesees--;
                    Console.WriteLine("Ogiltig gissning. Ange ett tal mellan 1 och 100: ");
                }

            } while (guessedNumber != numberToGuess);
        }
    }
}
