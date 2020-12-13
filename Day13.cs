using System;
using System.Linq;
using System.Collections.Generic;

public class Day13
{

    public Day13()
    {

    }

    // PART 1: Find the earliest bus * its wait time.
    // Using mod, we find patterns.
    public long FindEarliestBusTimesWaitTime(string[] input)
    {

        var line = Int32.Parse(input[0]);
        var buses = input[1].Split(",").Where(x => x != "x").Select(Int32.Parse).ToArray();

        var earliestDeparture = Int32.MaxValue;
        var fastBus = 0;
        var waitTime = 0;

        foreach (var bus in buses)
        {

            var firstMod = line % bus;
            var difference = Math.Abs(bus - firstMod);
            var nextTime = Math.Abs(line + difference);
            var to = nextTime % bus;

            if (earliestDeparture > nextTime)
            {
                fastBus = bus;
                earliestDeparture = nextTime;
                waitTime = difference;
            }
        }

        return fastBus * waitTime;
    }

    // PART 2: Find the earliest time where all buses are sequential from where they are listed.
    public long FindEarliestSequential(string[] input)
    {
        var buses = input[1].Split(",");

        // Pair the bus lines with their index.
        var busesDict = new Dictionary<string, int>();
        for (int i = 0; i < buses.Length; i++)
        {
            if (!busesDict.ContainsKey(buses[i]) && buses[i] != "x")
            {
                busesDict.Add(buses[i], i);
            }
        }
        
        long time = 0;
        int index = 0;     
        long incrementor = 1;

        foreach (var bus in busesDict)
        {
            index = bus.Value;
            while (true)
            {
                // Increment it by incrementor steps
                // We need to i
                time += incrementor;
                long busLine = long.Parse(bus.Key);

                // If we find it match the index.. check the next bus.
                // Get out of this loop and check the next bus - it MUST be a multiple. so update incrementor
                if ((time + (long) index) % busLine == 0)
                {
                    break;
                }
            }
            // At this point, we want to update it with the next bus.
            // Our incrementor - but we want them to be sequential, and using mod means they need to be multiples.
            incrementor *= long.Parse(bus.Key);
        }
        return time;
    }
}