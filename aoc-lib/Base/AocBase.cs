using aoc_lib.Models;

namespace aoc_lib.Base;

public abstract class AocBase<T>(int year, int day, string sessionKey, bool readDataAsSingleString = false) : IAocBase
{
    protected InputData<T> Input = default!;
    
    private readonly AocLib _lib = new(sessionKey);

    public async Task LoadInput()
    {
        Input = await _lib.DownloadInputData<T>(year, day, readDataAsSingleString);
    }

    public abstract object SolveTask1();

    public abstract object SolveTask2();

    public (string Solution1, string Solution2) Solve()
    {
        var res1 = AocLib.TryGetStoredSolution(year, day, 1, out var solution1)
            ? solution1
            : SolveTask1().ToString();
        
        var res2 = AocLib.TryGetStoredSolution(year, day, 2, out var solution2)
            ? solution2
            : SolveTask2().ToString();
        
        AocLib.SaveSolution(year, day, 1, res1!);
        AocLib.SaveSolution(year, day, 2, res2!);
        
        return (res1, res2)!;
    }
}