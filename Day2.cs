using System;

public class Day2
{
    public Day2() { }

    // PART 1. Check if a policy is fulfilled based on occurence.
    // For example, if its 1-3 h: hhhhhhhhhhhhh, then we must have at most, max 3 instances of h, and at least 1. 
    public int TotalValidPolicies(string[] input)
    {

        var validCounter = 0;
        foreach (var str in input)
        {

            var splitItems = str.Split(new char[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
            var min = Int32.Parse(splitItems[0].ToString());
            var max = Int32.Parse(splitItems[1].ToString());
            char target = splitItems[2][0];

            string checkThis = splitItems[3];

            var counter = 0;
            for (int i = 0; i < checkThis.Length; i++)
            {
                if (checkThis[i] == target)
                {
                    counter++;
                }

                if (counter > max)
                {
                    break;
                }
            }

            if (counter >= min && counter <= max)
            {
                validCounter++;
            }
        }

        return validCounter;
    }

    // PART 2. New policy where if a character position matches the target, the other cannot be.
    // If that basic requirement is fulfilled, increment valid count. Otherwise, continue searching.
    // For example, if its 1-3 h: hhhhhhhhhhhhh - for it to be valid, position 1 (index 0) and position 3 (index 2) cannot be both h, but one must be h.
    public int ValidatePositions(string[] input)
    {

        var validCounter = 0;
        foreach (var str in input)
        {

            var splitItems = str.Split(new char[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
            var pos1 = Int32.Parse(splitItems[0].ToString()) - 1;
            var pos2 = Int32.Parse(splitItems[1].ToString()) - 1;
            char target = splitItems[2][0];

            string checkThis = splitItems[3];

            if ((checkThis[pos1] == checkThis[pos2]) || (checkThis[pos1] == target && checkThis[pos2] == target))
            {
                continue;
            }

            if (checkThis[pos1] == target && checkThis[pos2] != checkThis[pos1])
            {
                validCounter++;
                continue;
            }

            if (checkThis[pos2] == target && checkThis[pos2] != checkThis[pos1])
            {
                validCounter++;
                continue;
            }
        }
        return validCounter;
    }
}
