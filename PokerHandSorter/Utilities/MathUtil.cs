using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandSorter.Utilities
{
    public static class MathUtil
    {
        /// <summary>
        /// Arithmetic Series
        /// https://en.wikipedia.org/wiki/Arithmetic_progression#:~:text=In%20mathematics,%20an%20arithmetic%20progression%20(AP)%20or%20arithmetic,sequence%205,%207,%209,%2011,%2013,%2015,%20.
        /// </summary>
        /// <param name="n">number of member in the sequence</param>
        /// <param name="a">first number of the sequence</param>
        /// <param name="d">common difference of successive members</param>
        /// <returns></returns>
        public static int ArithmeticSeries(int n, int a, int d)
        {
            return n / 2 * (2*a + (n - 1)*d);
        }
    }
}
