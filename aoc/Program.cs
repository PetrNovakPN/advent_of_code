using System;
using aoc._2024;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var sessionKey = configuration["SessionKey"] ?? "";

var day1 = new Day1(sessionKey);
await day1.LoadInput();
var day1Solution = day1.Solve();
Console.WriteLine("Day 1 - 1: " + day1Solution.Solution1);
Console.WriteLine("Day 1 - 2: " + day1Solution.Solution2);

var day2 = new Day2(sessionKey);
await day2.LoadInput();
var day2Solution = day2.Solve();
Console.WriteLine("Day 2 - 1: " + day2Solution.Solution1);
Console.WriteLine("Day 2 - 2: " + day2Solution.Solution2);

var day3 = new Day3(sessionKey);
await day3.LoadInput();
var day3Solution = day3.Solve();
Console.WriteLine("Day 3 - 1: " + day3Solution.Solution1);
Console.WriteLine("Day 3 - 2: " + day3Solution.Solution2);

var day4 = new Day4(sessionKey);
await day4.LoadInput();
var day4Solution = day4.Solve();
Console.WriteLine("Day 4 - 1: " + day4Solution.Solution1);
Console.WriteLine("Day 4 - 2: " + day4Solution.Solution2);

var day5 = new Day5(sessionKey);
await day5.LoadInput();
Console.WriteLine(day5.SolveTask1());
