using System;
using System.Collections.Generic;
using System.Linq;

namespace SortApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<double>();
            while (true)
            {
                var line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }

                numbers.AddRange(line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            }

            numbers.Sort();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}