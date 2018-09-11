using System;

namespace GissaNumret
{

    /// <summary>
    /// This is were it all starts... 
    /// We ask the user if he/she want's to play and Creates a new Game 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new UI to initialize the game
            UI ui = new UI();

            //Print the welcome message and ask user if they want to play
            Console.Write(ui.DrawUI());

            //Read response, if the user wants to play
            bool startGame = Console.ReadLine() == "ja" ? true : false;
            
            //initialize a new game
            GuessNumber theGame = new GuessNumber(startGame);

            //start the game if the user wants to
            theGame.PlayGame();

        }
    }
}
