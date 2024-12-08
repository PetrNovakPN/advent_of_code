using System;
using System.Collections.Generic;
using aoc_lib.Base;

namespace aoc._2024;

public class Day1(string sessionKey) : AocBase<int>(2024, 1, sessionKey)
{
    public override object SolveTask1()
    {
        List<int> list1 = Input.Column(0);
        List<int> list2 = Input.Column(1);
        
        list1.Sort();
        list2.Sort();
        
        int result = 0;
        for (int i = 0; i < list1.Count; i++)
        {
            result += Math.Abs(list1[i] - list2[i]);
        }
        return result;
    }
    public override object SolveTask2()
    {
        List<int> list1 = Input.Column(0);
        List<int> list2 = Input.Column(1);

        
        int result = 0;
        
        Dictionary<int, int> dict = new();
        for (int i = 0; i < list1.Count; i++)
        {
            if (!dict.TryAdd(list1[i], 1))
            {
                dict[list1[i]]++;
            }
        }

        for (int i = 0; i < list2.Count; i++)
        {
            if (dict.TryGetValue(list2[i], out int value))
            {
                result += list2[i] * value;
            }
        }
        return result;
    }

    
}