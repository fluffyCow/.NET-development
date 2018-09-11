using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GissaNumret
{
    /// <summary>
    /// This class prints the initial UI and the High score table
    /// </summary>
    class UI
    {

        private HighScore scoreList;
        private ArrayList printList = new ArrayList();

        //Constructor
        public UI()
        {
            //Read the existing high score from file
            scoreList = new HighScore();
            printList = scoreList.PrintScore();
        }

        /// <summary>
        /// Draw the initial UI and the high score
        /// </summary>
        /// <returns>String with the GUI to be presented to the user</returns>
        public String DrawUI() {

            String returnString;

            returnString =  "xxxxxxxxxxxxxxxxxxxxxxxxxxx \n" +
                            "Väkommen till Gissa Numret! \n" +
                            "xxxxxxxxxxxxxxxxxxxxxxxxxxx\n";
            ///If there are any previous results in the high score file. Show them
            if (printList.Count > 0)
            {

                returnString = returnString + "\nHär ser du tidigare gissningar \n" +
                                                "Namn\t\t\tResultat \n";

                foreach (Score s in printList)
                {
                    {
                        returnString = returnString + s.Name +"\t\t\t" + s.Guess + "\n";
                    }
                }
            //If there are no previous result
            } else {
                returnString = returnString + "Du verkar vara första spelaren, bli först med att hamna i high score!\n";
            }
            returnString = returnString + "\nVill du spela (ja/nej)?: ";

            //Return the string containing the UI
            return returnString;
        }
    }
}
