using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Day15
{

    public Day15()
    {

    }

    public long Find2020thNumber(string[] input)
    {
        var numbers = input[0].Split(',').Select(Int32.Parse).ToList();
        
        // Have to start at 1 because of turn counting and the diff calculation
        long idx = 1;

        long answer = Int32.MinValue;
        Dictionary<long, long> dict = new Dictionary<long, long>();
        foreach (var number in numbers)
        {
            answer = number;
            if (!dict.ContainsKey(number))
            {
                dict.Add(number, idx);
            }
            idx++;
        }

        // At this point, after the entire sequence, we start with 0.
        // This is also why our index is advanced by 1.
        long recent = 0;
        while (idx < 2021)
        {
            if (recent == 0)
            {              
                if (dict.ContainsKey(0)) {
                    recent = dict[0];      
                } else {
                    // It doesnt exist, so reset back to 0
                    recent = 0;
                    dict.Add(0, idx);
                }
                dict[0] = idx;
                answer = 0;         
            }
            else
            {   
                var diff = dict[answer] - recent;
                if (dict.ContainsKey(diff)) {
                    recent = dict[diff];
                    dict[diff] = idx;          
                } else {
                    // It doesnt exist, so reset back to 0
                    recent = 0;
                    dict.Add(diff, idx);
                }
                answer = diff;        
            }
            idx++;
        }
        return answer;
    }

    // PART 2: Exact same copy as part 1, except we are counting up the 30,000,000th number
    public long Find30000000thNumber(string[] input)
    {
        var numbers = input[0].Split(',').Select(Int32.Parse).ToList();
        
        // Have to start at 1 because of turn counting and the diff calculation
        long idx = 1;

        long answer = Int32.MinValue;
        Dictionary<long, long> dict = new Dictionary<long, long>();
        foreach (var number in numbers)
        {
            answer = number;
            if (!dict.ContainsKey(number))
            {
                dict.Add(number, idx);
            }
            idx++;
        }

        // At this point, after the entire sequence, we start with 0.
        long recent = 0;
        while (idx < 30000001)
        {
            if (recent == 0)
            {              
                if (dict.ContainsKey(0)) {
                    recent = dict[0];      
                } else {
                    // It doesnt exist, so reset back to 0
                    recent = 0;
                    dict.Add(0, idx);
                }
                dict[0] = idx;
                answer = 0;         
            }
            else
            {   
                var diff = dict[answer] - recent;
                if (dict.ContainsKey(diff)) {
                    recent = dict[diff];
                    dict[diff] = idx;           
                } else {
                    // It doesnt exist, so reset back to 0
                    recent = 0;
                    dict.Add(diff, idx);
                }
                answer = diff;               
            }
            idx++;
        }
        return answer;
    }
}