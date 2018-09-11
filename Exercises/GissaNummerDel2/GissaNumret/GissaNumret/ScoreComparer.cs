using System;
using System.Collections;
using System.Text;

namespace GissaNumret
{
    /// <summary>
    /// Interface that makes it possible to compare two score objects
    /// Compares the number of guesses between two scores
    /// We are now able to use Sort on an ArrayList
    /// Stolen from: https://stackoverflow.com/questions/27043055/how-do-i-order-an-arraylist-of-objects-by-one-of-the-objects-attributes
    /// </summary>

    class ScoreComparer : IComparer
    {
        /// <summary>
        /// 0:  equal
        /// 1:  x > y
        /// -1: y > x
        /// </summary>
        /// <param name="x">First score to be compare</param>
        /// <param name="y">Second score to be compared</param>
        /// <returns>
        /// 0:  equal
        /// 1:  x > y
        /// -1: y > x
        /// </returns>
        int IComparer.Compare(Object x, Object y)
        {
           
            
            ///If x and y are empty return equal
            ///if x is empty and y not return y greater than x
            if(x == null)
            {
                return (y == null) ? 0 : 1;
            }

            //if y is empty return x is greater than y
            if (y == null)
            {
                return -1;
            }

            //If none are empty compare the number of guesses
            //Retype imnut objects as score...
            Score sx = x as Score;
            Score sy = y as Score;

            ///...And compare the number of guesses
            ///return 0 if x and y is equal
            if (sx.Guess == sy.Guess)
            {
                return 0;
            }

            //otherwise return 1 if x/y or -1 if y>x
            return (sx.Guess > sy.Guess) ? 1 : -1;

        }
    }
}
