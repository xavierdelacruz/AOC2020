using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class Day5
{
    public Day5() { }

    // PART 1. Find the highest SeatID. 
    // PART 2. Find YOUR seat (it's not in the list, and not the very front or end). Seats +1 and -1 from yours should be in the list.
    public (int highestSeat, int mySeat) FindHighestSeatNumber(string[] input)
    {
        var maxSoFar = 0;
        var seated = new bool[1024];
        foreach (var str in input)
        {
            var seatNum = FindSeatNumber(str, 0, 7, 0, 127, 0);
            maxSoFar = Math.Max(maxSoFar, seatNum);
            seated[seatNum] = true;
        }

        var seat = 8;
        for (int i = 0; i < seated.Length - 7; i++)
        {
            if (seated[i] == false && seated[i + 1] == true && seated[i - 1] == true)
            {
                seat = i;
                break;
            }
        }
        return (maxSoFar, seat);
    }

    // Binary Search  for both col and Row
    private int FindSeatNumber(string inputStr, int lowerCol, int upperCol, int lowerRow, int upperRow, int idx)
    {

        // BASE CASE

        while (lowerRow <= upperRow && idx < inputStr.Length - 3)
        {
            var midRow = (upperRow + lowerRow) / 2;

            if (inputStr[idx] == 'F')
            {
                upperRow = midRow - 1;
            }

            if (inputStr[idx] == 'B')
            {
                lowerRow = midRow + 1;
            }
            idx++;
        }

        while (lowerCol <= upperCol && idx < inputStr.Length)
        {
            var midCol = (upperCol + lowerCol) / 2;
            if (inputStr[idx] == 'L')
            {
                upperCol = midCol - 1;
            }

            if (inputStr[idx] == 'R')
            {
                lowerCol = midCol + 1;
            }
            idx++;
        }
        return (lowerRow * 8) + lowerCol;
    }
}
