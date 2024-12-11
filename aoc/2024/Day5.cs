using System;
using System.Collections.Generic;
using System.Linq;
using aoc_lib.Base;

namespace aoc._2024;

public class Day5(string sessionKey) : AocBase<string>(2024, 5, sessionKey)
{
    public override object SolveTask1()
    {
        var rows = Input.RawData.Split(['\n'], StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, List<string>> dict = new();
        var result = 0;

        foreach (var row in rows)
        {
            if (row.Contains('|'))
            {
                var parts = row.Split('|');
                if (!dict.ContainsKey(parts[0]))
                {
                    dict[parts[0]] = new List<string> { parts[1] };
                }
                else
                {
                    dict[parts[0]].Add(parts[1]);
                }
            }
            else
            {
                var rowList = row.Split(',').ToList();
                var alreadyChecked = new List<string>();
                var meetsRequirements = true;

                foreach (var inst in rowList)
                {
                    foreach (var x in alreadyChecked)
                    {
                        if (dict.ContainsKey(inst) && dict[inst].Contains(x))
                        {
                            meetsRequirements = false;
                            break;
                        }
                    }

                    if (!meetsRequirements) break;
                    alreadyChecked.Add(inst);
                }

                if (meetsRequirements)
                {
                    int middleIndex = rowList.Count / 2;
                    if (middleIndex < rowList.Count && int.TryParse(rowList[middleIndex], out int number))
                    {
                        result += number;
                    }
                }
            }
        }
        return result;
    }

    public override object SolveTask2()
    {
        return null;
    }
}