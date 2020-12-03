using System;
using System.IO;

namespace AOC2020
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] initialInput = File.ReadAllLines(@"C:\Users\xdela\Documents\Git\AOC2020\Input Day3.txt");
            char[][] processedInput = new char[initialInput.Length][];

            for (int i = 0; i < initialInput.Length; i++)
            {
                var charArr = initialInput[i].ToCharArray();
                processedInput[i] = charArr;
            }

            var day3 = new Day3();
            var res1 = day3.TraverseToBottom(processedInput, (1, 1));
            var res2 = day3.TraverseToBottom(processedInput, (1, 3));
            var res3 = day3.TraverseToBottom(processedInput, (1, 5));
            var res4 = day3.TraverseToBottom(processedInput, (1, 7));
            var res5 = day3.TraverseToBottom(processedInput, (2, 1));
            Console.WriteLine(res1 * res2 * res3 * res4 * res5);
        }
    }
}
