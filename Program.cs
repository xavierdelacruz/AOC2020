using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020
{
    class Program
    {
        static void Main(string[] args)
        {
            // string[] initialInput = File.ReadAllLines(@"C:\Users\xdela\Documents\Git\AOC2020\Input Day3.txt");
            // char[][] processedInput = new char[initialInput.Length][];

            // for (int i = 0; i < initialInput.Length; i++)
            // {
            //     var charArr = initialInput[i].ToCharArray();
            //     processedInput[i] = charArr;
            // }

            // var day3 = new Day3();
            // var res1 = day3.TraverseToBottom(processedInput, (1, 1));
            // var res2 = day3.TraverseToBottom(processedInput, (1, 3));
            // var res3 = day3.TraverseToBottom(processedInput, (1, 5));
            // var res4 = day3.TraverseToBottom(processedInput, (1, 7));
            // var res5 = day3.TraverseToBottom(processedInput, (2, 1));
            // Console.WriteLine(res1 * res2 * res3 * res4 * res5);

            // var day4 = new Day4();
            // Console.WriteLine(day4.CountValidPassports(@"C:\Users\xdela\Documents\Git\AOC2020\Input Day4.txt"));
            // Console.WriteLine(day4.CountValidPassportsWithStrictRegex(@"C:\Users\xdela\Documents\Git\AOC2020\Input Day4.txt"));

            // var day5 = new Day5();
            // var res = day5.FindHighestSeatNumber(File.ReadAllLines(@"C:\Users\xdela\Documents\Git\AOC2020\Input Day5.txt"));
            // Console.WriteLine("Highest Seat ID: " + res.highestSeat + " My Seat: " + res.mySeat);

            // var day6 = new Day6();
            // Console.WriteLine(day6.CountValidGroupConcensus(@"C:\Users\xdela\Documents\Git\AOC2020\Input Day6.txt"));

            var day7 = new Day7();
            Console.WriteLine(day7.FindBagsThatContainGoldBag(@"C:\Users\xdela\Documents\Git\AOC2020\testinput.txt"));
        }
    }
}
