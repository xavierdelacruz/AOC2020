using System;
using System.Collections.Generic;

public class Day19
{

    public Day19()
    {

    }

    public int CountInstances(string[] input)
    {

        var rules = new Dictionary<string, string>();
        var candidates = new HashSet<string>();
        foreach (var line in input)
        {

            if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            if (!line.StartsWith("a") && !line.StartsWith("b") && !string.IsNullOrEmpty(line))
            {
                var rule = line.Split(":");
                rules.Add(rule[0], rule[1].TrimStart().TrimEnd());
                Console.WriteLine(rule[0] + " " + rule[1].TrimStart().TrimEnd());
            }
            else
            {
                candidates.Add(line);
            }
        }

        var rule0 = rules["0"].Split(" ");

        LookUpValid(candidates, rules, "0", "");




        return candidates.Count;
    }

    private string LookUpValid(HashSet<string> candidates, Dictionary<string, string> rules, string nextRule, string currString)
    {
        if (!rules.ContainsKey(nextRule))
        {
            return currString;
        }

        if (rules[nextRule].Contains("|"))
        {
            foreach (var half in rules[nextRule].Split("|"))
            {
                // If its an empty string
                if (string.IsNullOrEmpty(half))
                {
                    continue;
                }

                // If the parsed things are actuals strings that comprise of "a" or "b"
                if (half.Contains("a") || half.Contains("b"))
                {
                    currString += half;
                    Console.WriteLine(currString);
                }
                else
                {
                    // Otherwise, we have strings that contain numbers
                    var numRules = half.Split(" ");
                    foreach (var numRule in numRules)
                    {
                        if (numRule == string.Empty)
                        {
                            continue;
                        }

                        currString += LookUpValid(candidates, rules, numRule, currString);
                        Console.WriteLine(currString);
                    }
                }

                candidates.Remove(currString);
            }
        } else {
            foreach (var number in rules[nextRule].Split(" "))
            {
                // If its an empty string
                if (string.IsNullOrEmpty(number))
                {
                    continue;
                }

                // If the parsed things are actuals strings that comprise of "a" or "b"
                if (number.Contains("a") || number.Contains("b"))
                {
                    currString += number;
                    Console.WriteLine(currString);
                }
                else
                {
                    currString += LookUpValid(candidates, rules, number, currString);
                    Console.WriteLine(currString);
                } 
            }
             candidates.Remove(currString);
        }
        return currString;
    }

    public void LookUpValidWithLoop(string[] input) {
        var rules = new Dictionary<string, string>();
        var candidates = new HashSet<string>();
        foreach (var line in input)
        {
            if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            if (!line.StartsWith("a") && !line.StartsWith("b") && !string.IsNullOrEmpty(line))
            {
                var rule = line.Split(":");             
                if (!rules.ContainsKey("8") && rule[0] == "8") {
                    rules.Add("8", "42 | 42 8");
                } else if (!rules.ContainsKey("11") && rule[0] == "11") {
                    rules.Add(rule[0], "42 31 | 42 11 31");
                } else {
                    rules.Add(rule[0], rule[1].TrimStart().TrimEnd());
                }
            }
            else
            {
                candidates.Add(line);
            }
        }
        var valid = new HashSet<string>();
        while (true) {
            var hasBeenAdded = false;

            foreach (var kvp in rules) {
                if (kvp.Value.StartsWith("\""));
                
            }
        }
    }
}
