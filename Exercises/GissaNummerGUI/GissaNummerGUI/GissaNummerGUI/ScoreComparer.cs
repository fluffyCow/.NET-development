using System;
using System.Collections;
using System.Text;

namespace GissaNummerGUI
{
    //Stolen from: https://stackoverflow.com/questions/27043055/how-do-i-order-an-arraylist-of-objects-by-one-of-the-objects-attributes
    class ScoreComparer : IComparer
    {
        /// <summary>
        /// 0:  equal
        /// 1:  x > y
        /// -1: y > x
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>
        /// 0:  equal
        /// 1:  x > y
        /// -1: y > x
        /// </returns>
        int IComparer.Compare(Object x, Object y)
        {


            ///If x and y are empty return equal
            ///if x is empty and y not return y greater than x
            if (x == null)
            {
                return (y == null) ? 0 : 1;
            }

            //if y is empty return x is greater than y
            if (y == null)
            {
                return -1;
            }

            //If none are empty compare the number of guesses
            //Retype imput objects as score
            Score sx = x as Score;
            Score sy = y as Score;

            if (sx.Guess == sy.Guess)
            {
                return 0;
            }

            return (sx.Guess > sy.Guess) ? 1 : -1;

        }
    }
}
