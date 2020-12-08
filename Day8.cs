using System;
using System.IO;
using System.Collections.Generic;

public class Day8 {

    public Day8() {}

    // PART 1. Find the accumumulator before the loop.
    public int AccBeforeLoop(string[] input) {

        // Disgusting object array
        var lineData = new (string name, int val, bool visited)[input.Length];
        // Initialiez the object array
        for (int i = 0; i < input.Length; i++) {
            var commandLine = input[i].Split(" ");
            var command = commandLine[0];
            var value = Int32.Parse(commandLine[1]);
            lineData[i] = (command, value, false);
        }

        var acc = 0;
        var currPos = 0;

        while (currPos < lineData.Length) {
            
            var cmd = lineData[currPos].name;
            var val = lineData[currPos].val;
            var isValid = lineData[currPos].visited;

            //Console.WriteLine($"Visiting {cmd}:{val}:{isValid}, acc:{acc}");

            if (isValid) {
                break;
            }

            switch (cmd) {
                case "nop":
                    lineData[currPos].visited = true;
                    currPos++;
                    break;
                case "acc":
                    lineData[currPos].visited = true;
                    acc += val;
                    currPos++;
                    break;
                case "jmp":
                    lineData[currPos].visited = true;
                    currPos = currPos + val;
                    break;
                default:
                    currPos++;
                    break;
            }
        }

        return acc;
    }

    // PART 2: Fix infite loop. Iteratively searching for the solution.
    // TODO: Find backtracking solution.
    public int AccFixLoop(string[] input) {

        // Disgusting object array
        var lineData = new (string name, int val, bool visited)[input.Length];
        // Initialiez the object array
        for (int i = 0; i < input.Length; i++) {
            var commandLine = input[i].Split(" ");
            var command = commandLine[0];
            var value = Int32.Parse(commandLine[1]);
            lineData[i] = (command, value, false);
        }

        var acc = 0;
        var currPos = 0;

        for (int i = 0; i < input.Length; i++) {   
            // Keep searching for a jmp or nop, and 'try' it out.                                  
            var prevCmd = lineData[i].name;
            if (lineData[i].name == "nop") {
                lineData[i].name = "jmp";
            } else if (lineData[i].name == "jmp") {
                lineData[i].name = "nop";
            } else {
                continue;
            }

            var keepChecking = false;
            while (currPos < lineData.Length) {
                var cmd = lineData[currPos].name;
                var val = lineData[currPos].val;
                var isValid = lineData[currPos].visited;

                if (isValid && currPos < lineData.Length) {
                    keepChecking = true;
                    break;
                }

                switch (cmd) {
                    case "nop":
                        lineData[currPos].visited = true;
                        currPos++;
                        break;
                    case "acc":
                        lineData[currPos].visited = true;
                        acc += val;
                        currPos++;
                        break;
                    case "jmp":
                        lineData[currPos].visited = true;
                        currPos = currPos + val;
                        break;
                    default:
                        currPos++;
                        break;
                }
            }

            if (!keepChecking) {
                break;
            } else {
                for (int j = 0; j < lineData.Length; j++) {
                lineData[j].visited = false;
            }
                acc = 0;
                currPos = 0;     
                lineData[i].name = prevCmd;
            }
        }
        
        return acc;
    }
}