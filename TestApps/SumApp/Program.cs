using System;
using System.Linq;

namespace SumApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            double sum = 0;
            while (true)
            {
                var line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }

                var numbers = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse);
                sum += numbers.Sum();
            }

            if (args != null && args.Contains("wrong"))
            {
                sum -= 1;
            }

            Console.WriteLine(sum);
        }
    }
}