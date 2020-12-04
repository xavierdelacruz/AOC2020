using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class Day4
{
    public Day4() { }

    // PART 1. Count all valid passports just based on key validation.
    public int CountValidPassports(string path)
    {    
        var entireString = File.ReadAllText(path);
        var groups = entireString.Split(new string[] {Environment.NewLine + Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
        var processed = new string[groups.Length];
        
        for (int i = 0; i < groups.Length; i++) {
            processed[i] = groups[i].Replace(System.Environment.NewLine, " ");
        }

        var validPassports = 0;
        foreach (var str in processed) {
            var validFields = new HashSet<string>() { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid"};        
            var splitStrings = str.Split(" ");
            
            foreach (var innerStr in splitStrings) {
                var key = innerStr.Substring(0,3);
                if (validFields.Contains(key)) {
                    validFields.Remove(key);           
                } else {
                    break;
                }
                if (validFields.Count == 0) {
                    validPassports++;
                } else if (validFields.Count == 1 && validFields.Contains("cid")) {
                    validPassports++;
                    break;
                }      
            }
        }

        return validPassports;
    }

    // PART 2. Same validation with passports as Part 2, but with checks on valid values.
    public int CountValidPassportsWithStrictRegex(string path)
    {
        
        var entireString = File.ReadAllText(path);
        var groups = entireString.Split(new string[] {Environment.NewLine + Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
        var processed = new string[groups.Length];
        
        for (int i = 0; i < groups.Length; i++) {
            processed[i] = groups[i].Replace(System.Environment.NewLine, " ");
        }
        var validPassports = 0;
        

        foreach (var str in processed) {
            var validFields = new HashSet<string>() { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid"};        
            var splitStrings = str.Split(" ");
            
            foreach (var innerStr in splitStrings) {
                var key = innerStr.Substring(0,3);
                var value = innerStr.Substring(4);

                if (validFields.Contains(key)) {
                    if (ValidateValue(key, value)) {
                        validFields.Remove(key);
                    } else {
                        break;
                    }               
                } else {
                    break;
                }
                if (validFields.Count == 0) {
                    validPassports++;
                } else if (validFields.Count == 1 && validFields.Contains("cid")) {
                    validPassports++;
                    break;
                }      
            }
        }

        return validPassports;
    }

    // PART 2 HELPER. Validation helper using regex
    private bool ValidateValue(string key, string value) {

        switch (key) {
            case "byr":
                var byrRgx = new Regex(@"^(19[2-8][0-9]|199[0-9]|200[0-2])$");
                return byrRgx.IsMatch(value);
            case "iyr":
                var iyrRgx = new Regex(@"^(201[0-9]|2020)$");
                return iyrRgx.IsMatch(value);
            case "eyr":
                var eyrRgx = new Regex(@"^(202[0-9]|2030)$");
                return eyrRgx.IsMatch(value);
            case "hgt":
                var hgtRgxCm = new Regex(@"^(1[5-8][0-9]|19[0-3])cm$");
                var hgtRgxIn = new Regex(@"^(59|6[0-9]|7[0-6])in$");
                return hgtRgxCm.IsMatch(value) || hgtRgxIn.IsMatch(value);
            case "hcl":
                var hclRgx = new Regex(@"^#([a-fA-F0-9]{6})$");
                return hclRgx.IsMatch(value);
            case "ecl":
                var eyeColours = new HashSet<string>() {"amb", "blu", "brn", "gry","grn", "hzl", "oth"};
                return eyeColours.Contains(value);
            case "pid":
                var pidRgx = new Regex(@"^\d{9}$");
                return pidRgx.IsMatch(value);
            case "cid": 
                return true;
            default:
                return false;
        }
    }
}
