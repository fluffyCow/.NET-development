using System;
using System.Collections.Generic;
using System.Text;

namespace GissaNumret
{
    /// <summary>
    /// This class holds the name of the player and the current score
    /// </summary>
    class Score
    {
        //Player name
        private string name;

        //Number of guesses
        private int guess;

        ///<summary>
        ///Constructor that isn't doing anything
        ///</summary>
        public Score() { }

        ///<summary>
        ///The name of the player
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        ///The number of guesses the player made before guessing the correct answer
        ///</summary>
        public int Guess { get; set; }


    }
}

