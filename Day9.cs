using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
public class Day9 {

    public Day9() {
    
    }

    public long FindBadNumber(string path) {

        var strInput = File.ReadAllLines(path);
        var intInput = strInput.Select(long.Parse).ToList();
        var window = intInput.Take(5).ToList();
        var remaining = intInput.Skip(5).ToList();

        // Two sum idea. Get the difference of some number in remaining with the first item in window.
        // If that item exists in window, then we know it is the sum.
        foreach (var item in remaining) {
            var res = FindBadNumberHelper(window, item);
            if (res < 0) {
                return item;
            }
            window.Add(item);
            window.RemoveAt(0);  
        }
        return 0;
    }

    private long FindBadNumberHelper(List<long> window, long item) {
        for (int i = 0; i < window.Count; i++) {
            var diff = Math.Abs(item - window[i]);
            if (window.Contains(diff)) {
                return window[i];
            } else {
                return -1;
            }
        }
        return -1;
    }

    private void ShiftWindow(List<long> window, long item) {
        window.Add(item);
        window.RemoveAt(0);  

    }
}