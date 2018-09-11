using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GissaNummerGUI
{
    /// <summary>
    /// Saves the highscore to file
    /// </summary>
    class HighScore
    {

        private FileStream fStream;
        private StreamWriter sWriter;
        private StreamReader sReader;

        //PATH
        private const string fileName = @"c:\temp\highScore.txt";

        /// <summary>
        /// Constructor, does nothing
        /// </summary>
        public HighScore()
        {

        }

        /// <summary>
        /// Save the score in an array list to file
        /// </summary>
        /// <param name="score">ArrayList of Score objects</param>
        /// <returns></returns>
        public bool SaveScore(ArrayList score)
        {
            try
            {
                //Open the file
                fStream = new FileStream(fileName, FileMode.Append);

                sWriter = new StreamWriter(fStream);

                //Save each score with name separated by semi colon NAME;SCORE
                foreach (Score s in score)
                {
                    sWriter.WriteLine("{0};{1}", s.Name, s.Guess);
                }

                //Close the file
                sWriter.Close();

            }
            //In case something went wrong
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        ///  Reads the high score file and returns an arraylist of Score objects
        /// </summary>
        /// <returns></returns>
        public ArrayList PrintScore()
        {

            //This arraylist will be returned 
            ArrayList al = new ArrayList();

            //Open the file
            fStream = new FileStream(fileName, FileMode.OpenOrCreate);

            sReader = new StreamReader(fStream);

            String line;

            //Read through the file and save each name and score to a new Score object
            while ((line = sReader.ReadLine()) != null)
            {
                //Get the name
                String name = line.Substring(0, line.IndexOf(";"));
                //Get the score
                Int32.TryParse(line.Substring(line.IndexOf(";") + 1, line.Length - line.IndexOf(";") - 1), out int guess);

                //add as a new score into the arraylist
                Score s = new Score() { Name = name, Guess = guess };

                al.Add(s);
            }

            //Close the file
            sReader.Close();

            //Sort the result
            al.Sort(new ScoreComparer());

            return al;
        }
    }
}
