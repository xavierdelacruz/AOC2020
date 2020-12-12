using System;
using System.Linq;
using System.Collections.Generic;

public class Day11
{

    public Day11()
    {

    }

    // Cleanup process. Needs some debugging. I messed something up during clean up. Earlier solution solved
    // Note to self: commit working solution before cleaning up :(
    public int Part1(string[] input)
    {

        char[][] seats = input.Select(x => x.ToCharArray()).ToArray();
        HashSet<(int x, int y)> visited = new HashSet<(int x, int y)>();
        while (true)
        {
            var changes = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                for (int j = 0; j < seats[i].Length; j++)
                {
                    if (seats[i][j] == '.')
                    {
                        continue;
                    }
                    // If a seat is occupied, check if we can remove them based on threshold
                    if (seats[i][j] == '#' && CanRemove(seats, i, j))
                    {
                        seats[i][j] = 'L';
                        changes++;
                        // If a seat is empty, check if we can actually sit
                    }
                    else if (seats[i][j] == 'L' && CanSit(seats, i, j))
                    {
                        seats[i][j] = '#';
                        changes++;
                    }
                }
            }

            if (changes == 0)
            {
                Console.WriteLine("Really done");
                break;
            }
        }

        // Finally, scan the whole thing. I could probably do this more efficiently.
        int occupied = 0;
        for (int i = 0; i < seats.Length; i++)
        {
            for (int j = 0; j < seats[i].Length; j++)
            {
                Console.Write(seats[i][j] + " ");
                if (seats[i][j] == '#')
                {

                    occupied++;
                }
            }
            Console.WriteLine();
        }
        return occupied;
    }

    private bool CanSit(char[][] seats, int x, int y)
    {
        var dirs = new List<(int x, int y)>() { (0, 1), (0, -1), (1, 0), (-1, 0), (1, 1), (1, -1), (-1, 1), (-1, -1) };
        foreach (var dir in dirs)
        {
            var newX = dir.x + x;
            var newY = dir.y + y;

            if (newX < 0 || newX >= seats.Length || newY < 0 || newY >= seats[newX].Length || seats[newX][newY] == '.')
            {
                continue;
            }

            if (seats[newX][newY] == '#')
            {
                return false;
            }
        }
        return true;
    }

    private bool CanRemove(char[][] seats, int x, int y)
    {
        var dirs = new List<(int x, int y)>() { (0, 1), (0, -1), (1, 0), (-1, 0), (1, 1), (1, -1), (-1, 1), (-1, -1) };
        var adjCount = 0;
        foreach (var dir in dirs)
        {
            var newX = dir.x + x;
            var newY = dir.y + y;

            if (newX < 0 || newX >= seats.Length || newY < 0 || newY >= seats[newX].Length || seats[newX][newY] == '.')
            {
                continue;
            }

            if (seats[newX][newY] == '#')
            {
                adjCount++;
            }

            if (adjCount == 4)
            {
                return true;
            }
        }
        return false;
    }

    public int Part2(string[] input)
    {

        char[][] seats = input.Select(x => x.ToCharArray()).ToArray();
        HashSet<(int x, int y)> visited = new HashSet<(int x, int y)>();
        while (true)
        {
            var changes = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                for (int j = 0; j < seats[i].Length; j++)
                {
                    if (seats[i][j] == '.')
                    {
                        continue;
                    }
                    // If a seat is occupied, check if we can remove them based on threshold
                    if (seats[i][j] == '#' && CanRemove(seats, i, j))
                    {
                        seats[i][j] = 'L';
                        changes++;
                        // If a seat is empty, check if we can actually sit
                    }
                    else if (seats[i][j] == 'L' && CanSit(seats, i, j))
                    {
                        seats[i][j] = '#';
                        changes++;
                    }
                }
            }

            if (changes == 0)
            {
                Console.WriteLine("Really done");
                break;
            }
        }

        // Finally, scan the whole thing. I could probably do this more efficiently.
        int occupied = 0;
        for (int i = 0; i < seats.Length; i++)
        {
            for (int j = 0; j < seats[i].Length; j++)
            {
                Console.Write(seats[i][j] + " ");
                if (seats[i][j] == '#')
                {

                    occupied++;
                }
            }
            Console.WriteLine();
        }
        return occupied;
    }

    private bool CanSit2(char[][] seats, int x, int y)
    {
        var dirs = new List<(int x, int y)>() { (0, 1), (0, -1), (1, 0), (-1, 0), (1, 1), (1, -1), (-1, 1), (-1, -1) };
        foreach (var dir in dirs)
        {
            var newX = dir.x + x;
            var newY = dir.y + y;

            if (newX < 0 || newX >= seats.Length || newY < 0 || newY >= seats[newX].Length || seats[newX][newY] == '.')
            {
                continue;
            }

            if (seats[newX][newY] == '#')
            {
                return false;
            }
        }
        return true;
    }

    private bool CanRemove2(char[][] seats, int x, int y)
    {
        var dirs = new List<(int x, int y)>() { (0, 1), (0, -1), (1, 0), (-1, 0), (1, 1), (1, -1), (-1, 1), (-1, -1) };
        var adjCount = 0;
        foreach (var dir in dirs)
        {
            var newX = dir.x + x;
            var newY = dir.y + y;

            if (newX < 0 || newX >= seats.Length || newY < 0 || newY >= seats[newX].Length || seats[newX][newY] == '.')
            {
                continue;
            }

            if (seats[newX][newY] == '#')
            {
                adjCount++;
            }

            if (adjCount == 4)
            {
                return true;
            }
        }
        return false;
    }

}