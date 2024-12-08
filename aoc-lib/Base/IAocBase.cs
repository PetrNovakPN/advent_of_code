namespace aoc_lib.Base;

public interface IAocBase
{
    Task LoadInput();
    object SolveTask1();
    object SolveTask2();
    (string Solution1, string Solution2) Solve();
}