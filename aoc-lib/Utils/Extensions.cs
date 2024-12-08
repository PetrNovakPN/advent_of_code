namespace aoc_lib.Utils;

public static class Extensions
{
    public static T CastTo<T>(this object obj)
    {
        return (T)Convert.ChangeType(obj, typeof(T));
    }
    
    public static List<List<char>> As2DList(this string input, string lineSeparator = "\n")
    {
        return input.Split(lineSeparator)
            .Where(l => !string.IsNullOrEmpty(l))
            .Select(l => l.ToCharArray().ToList())
            .ToList();
    }
}