using System;
using System.Collections.Generic;

public class Day3
{
    public Day3() { }

    // PART 1 & 2. Starting at the top-left corner of some input and some slope
    // We must end at the bottom row (any) - but count how many trees we encounter.
    public int TraverseToBottom(char[][] input, (int down, int right) slope)
    {
        var treesEncountered = 0;
        var queue = new Queue<(int row, int col)>();
        queue.Enqueue((0, 0));

        while (queue.Count != 0)
        {

            var curr = queue.Dequeue();
            if (input[curr.row][curr.col] == '#')
            {
                treesEncountered++;
            }

            var newRow = curr.row + slope.down;
            var newCol = curr.col + slope.right;

            if (newRow < input.Length && newCol < input[newRow].Length)
            {
                queue.Enqueue((newRow, newCol));
            }
            else if (newRow < input.Length && newCol >= input[newRow].Length)
            {
                newCol = Math.Abs(newCol - (input[newRow].Length));
                queue.Enqueue((newRow, newCol));
            }
        }
        return treesEncountered;
    }
}
