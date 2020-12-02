using System;
using System.IO;
using System.Collections.Generic;

namespace AOC2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var day1 = new Day1();

            var input = File.ReadAllLines(@"C:\Users\xdela\Documents\Git\AOC2020\Input Day2.txt");
            var day2 = new Day2();
            Console.WriteLine(day2.ValidatePositions(day2Input));
        }
    }
}
