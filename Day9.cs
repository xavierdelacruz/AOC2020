using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
public class Day9 {

    public Day9() {
    
    }

    public long FindBadNumber(string path) {

        var strInput = File.ReadAllLines(path);
        var intInput = strInput.Select(long.Parse).ToList();
        var window = intInput.Take(5).ToList();
        var remaining = intInput.Skip(5).ToList();

        // Two sum idea. Get the difference of some number in remaining with the first item in window.
        // If that item exists in window, then we know it is the sum.
        foreach (var item in remaining) {
            var res = FindBadNumberHelper(window, item);
            if (res < 0) {
                return item;
            }
            window.Add(item);
            window.RemoveAt(0);  
        }
        return 0;
    }

    private long FindBadNumberHelper(List<long> window, long item) {
        for (int i = 0; i < window.Count; i++) {
            var diff = Math.Abs(item - window[i]);
            if (window.Contains(diff)) {
                return window[i];
            } else {
                return -1;
            }
        }
        return -1;
    }

    private void ShiftWindow(List<long> window, long item) {
        window.Add(item);
        window.RemoveAt(0);  

    }

    public long Part1()
        {
            var lines = File.ReadAllLines(@"C:\Users\xdela\Documents\Git\AOC2020\Input Day9.txt").ToList();
            var ints = lines.Select(long.Parse).ToList();

            var preamble = ints.Take(25).ToList();
            var others = ints.Skip(25).ToList();

            foreach (var i in others)
            {
                if (!IsSumOf(preamble, i))
                {
                    return i;
                }
                preamble.RemoveAt(0);
                preamble.Add(i);
            }
            
            return -1;
        }

        public static bool IsSumOf(List<long> preamble, long x)
        {
            foreach (var i in preamble)
            {
                if (preamble.Contains(x - i))
                {
                    return true;
                }
            }

            return false;
        }
        
        public long Part2(long target = 20874512)
        {
            var lines = File.ReadAllLines(@"C:\Users\xdela\Documents\Git\AOC2020\Input Day9.txt").ToList();

            var ints = lines.Select(long.Parse);

            var contiguousNumbers = new List<long>();
            
            foreach (var i in ints)
            {
                if (contiguousNumbers.Sum() == target && contiguousNumbers.Count > 1)
                {
                    return contiguousNumbers.Min() + contiguousNumbers.Max(); 
                }
                
                contiguousNumbers.Add(i);
                if (contiguousNumbers.Sum() == target && contiguousNumbers.Count > 1)
                {
                    break;
                }

                while (contiguousNumbers.Sum() > target)
                {
                    contiguousNumbers.RemoveAt(0);
                    if (contiguousNumbers.Sum() == target)
                    {
                        break;
                    }
                }
            }
            
            
            return contiguousNumbers.Min() + contiguousNumbers.Max();
        }

}