using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;


public class Day7
{

    public Day7() { }

    // This is how we will define our graph of bags
    protected class BagNode {
        public String Color {get; set;}
        public Dictionary<BagNode, int> ChildrenBags = new Dictionary<BagNode, int>();
    }

    // Part 1. Graph theory. Use dictionary to link objects together. We must create bag object that have children of other bags.
    public long FindBagsThatContainGoldBag(string path)
    {
        var bagRules = new Dictionary<string, BagNode>();
        var lines = File.ReadAllLines(path);

        var goldCounter = 0;
        foreach (var line in lines) {

            var initialBags = line.Split("bags contain");          
            var mainBagColour = initialBags[0].TrimEnd();
            var mainBagChildren = initialBags[1].Split(",").Select(x => x.TrimEnd('.').Replace("bags", "").Replace("bag", "").TrimStart(' '));

            // If this bag is gold.
            if (mainBagColour == "shiny gold") {
                goldCounter++;
            }

            // Initializes the main bag we are currently in, and adds it to the dict if we have not already added it.
            var mainBag = new BagNode();
            mainBag.Color = mainBagColour;

            if (!bagRules.ContainsKey(mainBagColour)) {
                bagRules.Add(mainBagColour, mainBag);
            }
            
            var childrenDict = mainBag.ChildrenBags;
            foreach (var mainBagChild in mainBagChildren) {
                var bagChildCount = mainBagChild[0];
                var bagChildColour = mainBagChild.Substring(2, mainBagChild.Length-2);
                Console.WriteLine("Count: " + bagChildCount + " Colour: " + bagChildColour);

                // if (!childrenDict.ContainsKey())
            }



            // if (!bagRules.ContainsKey(bagColour)) {

                
            // }
        }
        
        return 0;

    }
}