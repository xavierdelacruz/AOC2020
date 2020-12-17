using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Day16
{

    public Day16()
    {

    }

    // PART 1: Find the sum of all numbers per ticket that do not fall within the interval.
    public int FindErrorRate(string[] input)
    {
        bool startedYour = false;
        bool startedNearby = false;
        var intervals = new List<int[]>();
        var errorRate = 0;

        // Disgusting O(n2)-ish
        foreach (var line in input)
        {
            if (line.Contains("nearby tickets"))
            {
                startedNearby = true;
                continue;
            }
            else if (line.Contains("your ticket"))
            {
                startedYour = true;
                continue;
            }
            else if (!startedNearby && !startedYour && (!line.Contains("nearby tickets") || !line.Contains("your ticket")))
            {
                var firstSplit = line.Split(":");
                var secondSplit = firstSplit[1].Split("or");
                foreach (var range in secondSplit)
                {
                    var split = range.Split("-");
                    var interval = new int[2];
                    interval[0] = Int32.Parse(split[0]);
                    interval[1] = Int32.Parse(split[1]);
                    intervals.Add(interval);
                }
            }

            if (startedNearby)
            {
                var nearTicket = line.Split(",").Select(Int32.Parse).ToList();
                var result = nearTicket.Where(r => intervals.Any(i => i[0] <= r && i[1] >= r)).ToList();

                // Gets the list of numbers that did not quality for the interval
                var diffList = nearTicket.Except(result);
                var sum = diffList.Sum();
                errorRate += sum;

            }
        }
        return errorRate;
    }

    public long Part2(string[] input)
    {

        var myTix = new List<int>();
        var nearbyTix = new List<List<int>>();
        var intervals = new Dictionary<string, List<int>>();

        SetupDataStructures(myTix, nearbyTix, intervals, input);
        
        // currently reworkign this.
        return 0;
    }

    private void SetupDataStructures(List<int> myTix, List<List<int>> nearbyTix, Dictionary<string, List<int>> intervals, string[] input)
    {
        bool startedYour = false;
        bool startedNearby = false;
        // Disgusting O(n2)-ish
        foreach (var line in input)
        {
            if (line.Contains("nearby tickets"))
            {
                startedNearby = true;
                continue;
            }
            else if (line.Contains("your ticket"))
            {
                startedYour = true;
                continue;
            }
            else if (!startedNearby && !startedYour && (!line.Contains("nearby tickets") || !line.Contains("your ticket")))
            {
                var firstSplit = line.Split(":");
                var secondSplit = firstSplit[1].Split("or");
                var intervalList = new List<int>();
                foreach (var range in secondSplit)
                {
                    var split = range.Split("-");
                    var interval = new List<int>() { Int32.Parse(split[0]), Int32.Parse(split[1]) };
                    if (intervals.ContainsKey(firstSplit[0]))
                    {
                        intervals[firstSplit[0]].AddRange(interval);
                    }
                    else
                    {
                        intervalList.AddRange(interval);
                        // Stores the field with teh associated intervals.
                        intervals.Add(firstSplit[0], intervalList);
                    }
                }
            }

            if (startedNearby)
            {
                var nearTicket = line.Split(",").Select(Int32.Parse).ToList();
                nearbyTix.Add(nearTicket);
            }

            // It is made up of a single line. Immediately set it to false after.
            if (startedYour)
            {
                myTix.AddRange(line.Split(",").Select(Int32.Parse).ToList());
                startedYour = false;
            }
        }
        return;
    }
}