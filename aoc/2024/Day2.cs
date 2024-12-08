using System;
using System.Linq;
using aoc_lib.Base;

namespace aoc._2024;

public class Day2(string sessionKey) : AocBase<int>(2024, 2, sessionKey)
{
    public override object SolveTask1()
    {

        var result = 0;
        foreach (var row in Input.Rows)
        {
            var rowList = row.ToList();
            if(!(rowList.SequenceEqual(rowList.OrderBy(x => x)) || rowList.SequenceEqual(rowList.OrderByDescending(x => x))))
            {
                continue;
            }
            
            bool meetsRequirements = true;
            for (int i = 0; i < rowList.Count - 1; i++)
            {
                var diff = Math.Abs(rowList[i] - rowList[i + 1]);
                if (diff is < 1 or > 3)
                {
                    meetsRequirements = false;
                }
                
            }
            if (meetsRequirements)
            {
                result++;
            }
        }
        return result;
    }

    

    public override object SolveTask2()
    {
        var result = 0;

        foreach (var rows in Input.Rows)
        {
            var meetsRequirements = false;
            for (int i = 0; i < rows.Count(); i++)
            {
                var row = rows.ToList();
                meetsRequirements = true;
                row.RemoveAt(i);
                if (row.SequenceEqual(row.OrderBy(x => x)) || row.SequenceEqual(row.OrderByDescending(x => x)))
                {
                    for (int j = 0; j < row.Count - 1; j++)
                    {
                        var diff = Math.Abs(row[j] - row[j + 1]);
                        if (diff is < 1 or > 3)
                        {
                            meetsRequirements = false;
                        }
                    }
                    
                }
                else
                {
                    meetsRequirements = false;
                }
                if (meetsRequirements)
                {
                    break;
                }
            }

            if (meetsRequirements)
            {
                result++;
            }
        }
        
        return result;
    }

    
    //This is the old try for solution 2 it doesn't have to loop through all the rows at worst n-times, but only once
    /*
     private enum State
    {
        NaN,
        Ascending,
        Descending
    }

    private enum Failsafe
    {
        None,
        First,
        Second,
        Third,
        Fail
    }
     public override object SolveTask2()
    {
        var result = 0;
        
        foreach (var row in Input.Rows)
        {
            var rowList = row.ToList();
            var failsafe = Failsafe.None;
            var rowState = State.NaN;
            bool meetsRequirements = true;
            var edge = false;
            
            for (int i = 0; i < rowList.Count - 1; i++)
            {
                var testedNumber = rowList[i];
                var nextNumber = rowList[i + 1];
                if((failsafe != Failsafe.None) && edge)
                {
                    meetsRequirements = false;
                    break;
                }

                if (failsafe == Failsafe.First)
                {
                    if (rowList[i] == rowList.Count - 1) continue;
                    testedNumber = rowList[i - 1];
                }
                else if(failsafe == Failsafe.Second)
                {
                    if (rowList[i] == rowList.Count - 1) continue;
                    
                    testedNumber = rowList[i - 3];
                    nextNumber = rowList[i - 1];
                }
                else if (failsafe == Failsafe.Third)
                {
                    testedNumber = rowList[i - 2];
                    nextNumber = rowList[i - 1];
                }
                /*if (skip)
                {
                    i--;
                    failsafe = Failsafe.First;
                }
                else if (failsafe == Failsafe.First)
                {
                    testedNumber = rowList[i]
                }#1#
                
                
                if (rowState == State.NaN)
                {
                    rowState = nextNumber > testedNumber ? State.Ascending : State.Descending;
                }
                else if ((rowState == State.Ascending && nextNumber < testedNumber) ||
                         (rowState == State.Descending && nextNumber > testedNumber))
                {
                    failsafe = switchFailsafe(failsafe);
                    if (failsafe == Failsafe.Fail)
                    {
                        meetsRequirements = false;
                        break;
                    }

                    continue;

                }
                if (!MeetsDiffReq(testedNumber, nextNumber))
                {
                    failsafe = switchFailsafe(failsafe);
                    if (failsafe != Failsafe.Fail) continue;
                    meetsRequirements = false;
                    break;
                }
                if (failsafe == Failsafe.Third)
                {
                    i -= 2;
                }
                if (failsafe != Failsafe.None)
                {
                    edge = true;
                }
                
                
            }
            if (meetsRequirements)
            {
                result++;
                failsafe = Failsafe.None;
                
            }

            
        }
        return result;
        
        Failsafe switchFailsafe(Failsafe failsafe)
        {
            switch (failsafe)
            {
                case Failsafe.None:
                    failsafe = Failsafe.First;
                    break;
                case Failsafe.First:
                    failsafe = Failsafe.Second;
                    break;
                case Failsafe.Second:
                    failsafe = Failsafe.Third;
                    break;
                case Failsafe.Third:
                    failsafe = Failsafe.Fail;
                    break;
            }

            return failsafe;
        }
    }

    private bool MeetsDiffReq(int a, int b)
    {
        var diff = Math.Abs(a-b);
        return !(diff is < 1 or > 3);
    }
    */

    

    
}