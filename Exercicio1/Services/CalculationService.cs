using System;
using System.IO;

namespace Exercicio1.Services
{
    class CalculationService
    {
        public static double Max(double x, double y)
        {
            double max = (x > y) ? x : y;
            Console.WriteLine(max);
            return max;
        }

        public static double Sum(double x, double y)
        {
            double sum = x + y;
            Console.WriteLine(sum);
            return sum;
        }

        public static double Square(double x)
        {
            return x * x;
        }
    }
}
