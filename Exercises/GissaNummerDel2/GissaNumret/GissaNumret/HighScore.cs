using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GissaNumret
{
    /// <summary>
    /// This class is saving and reading the high score from a file
    /// </summary>
    class HighScore
    {

        private FileStream fStream;
        private StreamWriter sWriter;
        private StreamReader sReader;
        private const string fileName = @"c:\temp\highScore.txt";

        public HighScore()
        {

        }

        /// <summary>
        /// Adds the score to the high score file
        /// </summary>
        /// <param name="score">The score to be saved</param>
        /// <returns>true if successful save else false</returns>
        public bool SaveScore(ArrayList score)
        {
            try
            {
                //Create a new FileStream where we append the new information to the file
                //If the file doesn't exist a new file is created
                fStream = new FileStream(fileName, FileMode.Append);
                sWriter = new StreamWriter(fStream);

                //Loop through the score array and save each result as a new line
                //Name and score is separated using a semi colon "Name;Score"
                foreach (Score s in score)
                {
                    sWriter.WriteLine("{0};{1}", s.Name, s.Guess);
                }

                //Close the file
                sWriter.Close();
                
            //Catch any errors and return false 
            } catch
            {
                return false;
            }

            //Successful save. Return true
            return true;
        }

        /// <summary>
        ///  Reads the high score file and returns an arraylist of Score objects
        /// </summary>
        /// <returns></returns>
        public ArrayList PrintScore()
        {
            //List that is returned
            ArrayList al = new ArrayList();

            //Create a new FileStream that opens the file
            fStream = new FileStream(fileName, FileMode.OpenOrCreate);
            sReader = new StreamReader(fStream);

            //Read each line in the file until end of file
            String line;
            while ((line = sReader.ReadLine()) != null)
            {
                //Select the name part of the string (before the semi colon)
                String name = line.Substring(0, line.IndexOf(";"));

                //Select the score part of the string (after the semi colon)
                if(Int32.TryParse(line.Substring(line.IndexOf(";")+1, line.Length- line.IndexOf(";")-1), out int guess))
                {
                    //If we are able to parse the score into an int. Create a new score object and add it to the array
                    Score s = new Score() { Name = name, Guess = guess };
                    al.Add(s);
                }                    
             }

            //Close the file
            sReader.Close();

            //Sort the list using our custom interface ScoreComparer
            al.Sort(new ScoreComparer());

            //return our list of scores
            return al;
        }
    }
}
