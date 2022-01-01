using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rounding
{
    static class RoundingClass
    {
        public static int Round(double number)
        {
            number = Math.Round(number);
            return (int)number;
        }

        public static int Ceil(double number)
        {
            number = Math.Ceiling(number);
            return (int)number;
        }

        public static int Floor(double number)
        {
            number = Math.Floor(number);
            return (int)number;
        }
    }
}
