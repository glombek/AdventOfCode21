public static class Day1
{
    public static readonly int[] Example = Inputs.Read<int>("Day1\\example").ToArray();
    public static readonly int[] Input = Inputs.Read<int>("Day1\\input").ToArray();

    public static void Part1(int[] input)
    {
        var increases = 0;

        for (var i = 1; i < input.Length; i++)
        {
            var prev = input[i - 1];
            var curr = input[i];

            increases += prev < curr ? 1 : 0;
        }

        Console.WriteLine(increases);
    }

    public static void Part2(int[] input)
    {
        var increases = 0;

        for (var i = 3; i < input.Length; i++)
        {
            var a = input[i - 3];
            var b = input[i - 2];
            var c = input[i - 1];
            var prev = a + b + c;

            var d = input[i - 2];
            var e = input[i - 1];
            var f = input[i];
            var curr = d + e + f;

            increases += prev < curr ? 1 : 0;
        }

        Console.WriteLine(increases);
    }
}
