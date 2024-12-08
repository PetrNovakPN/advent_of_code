using aoc_lib.Models;
using aoc_lib.Utils;

namespace aoc_lib;

public class AocLib(string sessionKey)
{
    public async Task<InputData<T>> DownloadInputData<T>(int year, int day, bool readDataAsSingleString = false)
    {
        if(TryGetLocalData(year, day, out var localData))
            return new InputData<T>(localData, readDataAsSingleString);
        
        var endpoint = BuildDataEndpoint(year, day);
        var data = await AocHttpClient.GetAsync(endpoint, sessionKey);
        await SaveInputData(year, day, data);
        
        return new InputData<T>(data, readDataAsSingleString);
    }
    
    public static bool TryGetStoredSolution(int year, int day, int task, out string solution)
    {
        var path = $"./solutions/{year}/day{day}-{task}.txt";

        if (!File.Exists(path))
        {
            solution = string.Empty;
            return false;
        }

        solution = File.ReadAllText(path);
        return true;
    }
    
    public static void SaveSolution(int year, int day, int task, string solution)
    {
        var path = $"./solutions/{year}/day{day}-{task}.txt";
        var directory = Path.GetDirectoryName(path);

        if (!Directory.Exists(directory))
        {
            if (directory != null) Directory.CreateDirectory(directory);
        }
        
        File.WriteAllText(path, solution);
    }

    private static string BuildDataEndpoint(int year, int day)
    {
        return $"/{year}/day/{day}/input";
    }
    
    private static bool TryGetLocalData(int year, int day, out string data)
    {
        var path = $"./data/{year}/day{day}.txt";

        if (!File.Exists(path))
        {
            data = string.Empty;
            return false;
        }

        data = File.ReadAllText(path);
        return true;
    }

    private static async Task SaveInputData(int year, int day, string data)
    {
        var path = $"./data/{year}/day{day}.txt";
        var directory = Path.GetDirectoryName(path);

        if (!Directory.Exists(directory))
        {
            if (directory != null) Directory.CreateDirectory(directory);
        }
        
        await File.WriteAllTextAsync(path, data);
    }
}