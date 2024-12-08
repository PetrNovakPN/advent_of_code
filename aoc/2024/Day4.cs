using System.Collections.Generic;
using aoc_lib.Base;
using aoc_lib.Utils;

namespace aoc._2024;

public class Day4(string sessionKey) : AocBase<string>(2024, 4, sessionKey, true)
{
    public override object SolveTask1()
    {
        var input = Input.RawData.As2DList();
        int count = 0;
        for (int y = 0; y < input.Count; y++)
        {
            for (int x = 0; x < input[y].Count; x++)
            {
                if(input[y][x] != 'X') continue;

                //UP
                if (y - 3 >= 0)
                {
                    if(input[y - 1][x] == 'M' && input[y - 2][x] == 'A' && input[y - 3][x] == 'S')
                    {
                        count++;
                    }
                }
                //DOWN
                if (y + 3 < input.Count)
                {
                    if(input[y + 1][x] == 'M' && input[y + 2][x] == 'A' && input[y + 3][x] == 'S')
                    {
                        count++;
                    }
                }
                //LEFT
                if (x - 3 >= 0)
                {
                    if(input[y][x - 1] == 'M' && input[y][x - 2] == 'A' && input[y][x - 3] == 'S')
                    {
                        count++;
                    }
                }
                //RIGHT
                if (x + 3 < input[y].Count)
                {
                    if(input[y][x + 1] == 'M' && input[y][x + 2] == 'A' && input[y][x + 3] == 'S')
                    {
                        count++;
                    }
                }
                //UP LEFT
                if (y - 3 >= 0 && x - 3 >= 0)
                {
                    if(input[y - 1][x - 1] == 'M' && input[y - 2][x - 2] == 'A' && input[y - 3][x - 3] == 'S')
                    {
                        count++;
                    }
                }
                //UP RIGHT
                if (y - 3 >= 0 && x + 3 < input[y].Count)
                {
                    if(input[y - 1][x + 1] == 'M' && input[y - 2][x + 2] == 'A' && input[y - 3][x + 3] == 'S')
                    {
                        count++;
                    }
                }
                //DOWN LEFT
                if (y + 3 < input.Count && x - 3 >= 0)
                {
                    if(input[y + 1][x - 1] == 'M' && input[y + 2][x - 2] == 'A' && input[y + 3][x - 3] == 'S')
                    {
                        count++;
                    }
                }
                //DOWN RIGHT
                if (y + 3 < input.Count && x + 3 < input[y].Count)
                {
                    if(input[y + 1][x + 1] == 'M' && input[y + 2][x + 2] == 'A' && input[y + 3][x + 3] == 'S')
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }

    public override object SolveTask2()
    {
        var input = Input.RawData.As2DList();
        int count = 0;
        for (int y = 0; y < input.Count; y++)
        {
            for (int x = 0; x < input[y].Count; x++)
            {
                if(input[y][x] != 'A') continue;
                
                if(y-1 >= 0 && x-1 >= 0 && y+1 < input.Count && x+1 < input[y].Count)
                {
                    //Ms on top
                    if(input[y-1][x-1] == 'M' && input[y+1][x+1] == 'S' && input[y-1][x+1] == 'M' && input[y+1][x-1] == 'S')
                    {
                        count++;
                    }
                    //Ms on bottom
                    else if(input[y+1][x+1] == 'M' && input[y-1][x-1] == 'S' && input[y+1][x-1] == 'M' && input[y-1][x+1] == 'S')
                    {
                        count++;
                    }
                    //Ms on left
                    else if(input[y-1][x-1] == 'M' && input[y+1][x+1] == 'S' && input[y+1][x-1] == 'M' && input[y-1][x+1] == 'S')
                    {
                        count++;
                    }
                    //Ms on right
                    else if(input[y-1][x+1] == 'M' && input[y+1][x-1] == 'S' && input[y+1][x+1] == 'M' && input[y-1][x-1] == 'S')
                    {
                        count++;
                    }
                    
                    
                    
                }
            }
        }
        return count;
    }
}