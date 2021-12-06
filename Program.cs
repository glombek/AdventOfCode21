// Day1.Part1(Day1.Example);
// Day1.Part1(Day1.Input);

// Day1.Part2(Day1.Example);
// Day1.Part2(Day1.Input);

// Day2.Submarine sub = new Day2.Submarine("Day2\\input");
// sub.Run();
// Console.WriteLine(sub.Depth);
// Console.WriteLine(sub.HorizontalPosition);
// Console.WriteLine(sub.Result);

// var day3 = new Day3.Part2("Day3/input");
// day3.O2();

// day3.CO2();
// System.Console.WriteLine($"O2: {day3.O2GenRating}");
// System.Console.WriteLine($"CO2: {day3.CO2ScrubRating}");

// System.Console.WriteLine($"Answer: {day3.CO2ScrubRating * day3.O2GenRating}");

// var day4 = new Day4.BingoGame("Day4\\input");
// System.Console.WriteLine(day4.Play());

// var day5 = new Day5.Day5("Day5\\input");
// var n = day5.PlotVents();
// System.Console.WriteLine($"{n} dangerous points");

var shoal = new Day6.Shoal("Day6\\example");
var count = shoal.SimulateDays(256, false);
System.Console.WriteLine(count);