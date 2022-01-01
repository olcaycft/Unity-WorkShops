using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Rounding
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = 5.3;
            double number2 = 5.7;
            Console.WriteLine("Sayı1= {0}", number1);
            Console.WriteLine("Rounding Sonucu= {0}", RoundingClass.Round(number1));
            Console.WriteLine("Ceiling Sonucu= {0}", RoundingClass.Ceil(number1));
            Console.WriteLine("Floor Sonucu= {0}", RoundingClass.Floor(number1));

            Console.WriteLine("Sayı2= {0}", number2);
            Console.WriteLine("Rounding Sonucu= {0}", RoundingClass.Round(number2));
            Console.WriteLine("Ceiling Sonucu= {0}", RoundingClass.Ceil(number2));
            Console.WriteLine("Floor Sonucu= {0}", RoundingClass.Floor(number2));
        }
    }
}
