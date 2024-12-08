using System.Text.RegularExpressions;
using aoc_lib.Base;

namespace aoc._2024;

public class Day3(string sessionKey) : AocBase<string>(2024, 3, sessionKey, true)
{
    public override object SolveTask1()
    {
        var input = Input.RawData;
        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";        
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(input);

        var totalSum = 0;
        foreach (Match match in matches)
        {
            int n = int.Parse(match.Groups[1].Value);
            int m = int.Parse(match.Groups[2].Value);
            
            totalSum += n * m;
        }

        return totalSum;
    }

    public override object SolveTask2()
    {
        var input = Input.RawData;
        string pattern = @"do\(\)|don't\(\)|mul\((\d{1,3}),(\d{1,3})\)";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(input);

        int totalSum = 0;
        bool isMulEnabled = true;

        foreach (Match match in matches)
        {
            if (match.Value == "do()")
            {
                isMulEnabled = true;
            }
            else if (match.Value == "don't()")
            {
                isMulEnabled = false;
            }
            else if (isMulEnabled && match.Groups[1].Success && match.Groups[2].Success)
            {
                int n = int.Parse(match.Groups[1].Value);
                int m = int.Parse(match.Groups[2].Value);
                totalSum += n * m;
            }
        }

        return totalSum;
    }
}
