using System.Collections;
using System.Collections.Generic;
using aoc_lib.Utils;

namespace aoc_lib.Models;

public class InputLine<T> : IEnumerable<T>
{
    public InputLine(string line)
    {
        Values = line.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries)
            .Select(v => v.CastTo<T>())
            .ToList();
    }

    public List<T> Values { get; set; }

    public IEnumerator<T> GetEnumerator()
    {
        return Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}