using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class Day6
{
    public Day6() { }

    // PART 1. Valid questions from all groups. ASCII array approach.
    // Any latter that is part of the list counts as a question that has been answered as "yes"
    public int CountValidQuestions(string path)
    {    
        var entireString = File.ReadAllText(path);
        var groups = entireString.Split(new string[] {Environment.NewLine + Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
        var processed = new string[groups.Length];
        for (int i = 0; i < groups.Length; i++) {
            processed[i] = groups[i].Replace(Environment.NewLine, "").ToLower();
        }

        var totalQuestions = 0;
        foreach (var str in processed) {
            // Ascii array, subtract 97.
            var questions = new int[26];   
            var charArr = str.ToCharArray();
            var localCounter = 0;
            foreach (var singleChar in charArr) {
                if (questions[singleChar-97] == 0) {
                    questions[singleChar-97] = 1;
                    localCounter++;
                }
            }
            totalQuestions += localCounter;          
        }
        return totalQuestions;
    }

    // PART 2. Only count the ones that have been answered as a group. 
    // For example, for each group, if member 1 and 2 both answered a, it counts as 1.
    // On the other hand, if member 1 and 2 anwered b and c - then it counts as 0.
    public int CountValidGroupConcensus(string path)
    {    
        var entireString = File.ReadAllText(path);
        var groups = entireString.Split(new string[] {Environment.NewLine + Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
        var totalCount = 0;

        // O(n3), could be better
        foreach (var group in groups) {
            var localCount = 0;
            var letterCount = new int[26];
            var members = group.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            var memberCount = members.Length;
            var questions = new int[26];   
            
            foreach (var member in members) {
                var answers = member.ToCharArray();
                
                foreach (var answer in answers) {
                    letterCount[answer-97]++;

                    if (letterCount[answer-97] == memberCount) {
                        localCount++;
                    }
                }
            }
            totalCount += localCount;
        }
        return totalCount;
    }

}
