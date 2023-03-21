using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal static class IntExtentions
    {

        // Extension Method:
        //must class be static and methode static with this parametr


        public static int Reverse(this int Num)
        {
            int reversedNum =0, reminder;
            while (Num != 0)
            {
                reminder = Num % 10;
                reversedNum = reversedNum * 10 + reminder;
                Num /= 10;
            }
            return reversedNum;
        }
    }
}
