using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Day10 {

    public Day10() {
    
    }

    // PART 1: DP-like approach with linear-scan and storing previous result.
    public int CountGroupDifference(string[] input) {
        List<int> adapters = input.Select(Int32.Parse).ToList();
        adapters.Sort();

        var prev = 0;
        var diff1 = 0;
        // Counts your own device
        var diff3 = 1;
        for (int i = 0; i < adapters.Count; i++) {
            // Get the difference from the current number and previous
            var diff = adapters[i] - prev;

            // If the diff is 3, then we have something that counts as diff3
            if (diff == 3) {
                diff3++;
            }
            
            // If the difference is 1, then we have something that counts as a diff1
            if (diff == 1) {
                diff1++;
            }
            // Change the previous number now.
            prev = adapters[i];
        }
        return (diff1 * diff3);
    }

    // PART 2: DP-like approach. Trillions expected, long is possibly the end result.
    // We want to generate as many possiblities as possible.
    public long CountAllPossibleWays(string[] input) {
   
        // LINQ!
        List<int> adapters = input.Select(Int32.Parse).ToList();
        var max = adapters.Max();
        var device = max + 3;

        // Prime for DP, add a 0th
        adapters.Add(0);

        // Add the largest number (your own device)
        adapters.Add(device);

        // Now sort (or kith)
        adapters.Sort();
        adapters.Reverse();

        var dp = new Dictionary<int, long>();
        dp.Add(device, 1);

        foreach (var adapter in adapters) {
           
            // CURRENTLY REWORKING it.
            // Note that for each adapter, there is a way, using previous results.
        }

        return dp[adapters.Count-1];

    }

}