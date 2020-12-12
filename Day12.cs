using System;
using System.IO;

public class Day12 {
    public Day12() {

    }

    // Part 1. Ship starts facing east. Use math to calculate the displacement when moving forward at some angle.
    // We can simplify the x and y travelled using math rather than enumerating E, W, S, N.
    public int ManhattanDistance(string[] input) {
        (int x, int y) coord = (0,0);
        var dir = 0;
        foreach (var line in input) {
            var letter = line[0];
            var value = Int32.Parse(line[1..]);

            switch (letter) {
                case 'F':
                    var radians = (Math.PI * dir) /180;
                    coord.x += (int) Math.Cos(radians) * value;
                    coord.y += (int) Math.Sin(radians) * value;
                    break;
                case 'N':
                    coord.y += value;
                    break;
                case 'S':
                    coord.y -= value;
                    break;
                case 'E':
                    coord.x += value;
                    break;
                case 'W':
                    coord.x -= value;
                    break;
                case 'L':
                    dir += value;
                    break;
                case 'R':
                    dir -= value;
                    break;
            }
        }
        return Math.Abs(coord.x) + Math.Abs(coord.y);
    }
    // PART 2: This time, we want to keep track of thigns using our waypoint.
    // Out waypoint is always 10 east and 1 north (10, 1) relative to our ship's start (0, 0)
    public int ManhattanDistance2(string[] input) {
        (int x, int y) coord = (0,0);
        (int x, int y) waypoint = (10, 1);
        foreach (var line in input) {
            var letter = line[0];
            var value = Int32.Parse(line[1..]);

            switch (letter) {
                case 'F':        
                    coord.x += waypoint.x * value;
                    coord.y += waypoint.y * value;
                    break;
                case 'N':
                    waypoint.y += value;
                    break;
                case 'S':
                    waypoint.y -= value;
                    break;
                case 'E':
                    waypoint.x += value;
                    break;
                case 'W':
                    waypoint.x -= value;
                    break;
                case 'L':
                    while (value > 0) {
                        var prevX = waypoint.x;
                        waypoint.x = waypoint.y * -1;
                        waypoint.y = prevX;
                        value = value - 90;
                    }
                    break;
                case 'R':
                     while (value > 0) {
                        var prevX = waypoint.x;
                        waypoint.x = waypoint.y;
                        waypoint.y = prevX * -1;
                        value = value - 90;
                    }
                    break;
            }
        }
        return Math.Abs(coord.x) + Math.Abs(coord.y);
    }
}
