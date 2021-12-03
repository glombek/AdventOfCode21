using System.Linq;

namespace Day3
{
    public class Part1
    {

        public Part1(string name)
        {
            var input = Inputs.Read<string>(name);
            Input = input.Select(x => x.Select(y => y == '1'));
        }

        public IEnumerable<IEnumerable<bool>> Input { get; set; }
        public int GammaRate { get; set; }
        public int EpsilonRate { get; set; }
        public int PowerConsumption => GammaRate * EpsilonRate;

        public void Run()
        {
            var rows = Input.Count();
            var columns = Input.First().Count();
            for (int i = 0; i < columns; i++)
            {
                var ones = Input.Count(x => x.ElementAt(i));
                var zeros = rows - ones;

                GammaRate += zeros > ones ? 0 : (int)(Math.Pow(2, columns - 1 - i));
                EpsilonRate += zeros < ones ? 0 : (int)(Math.Pow(2, columns - 1 - i));

                System.Console.WriteLine($"G: {Convert.ToString(GammaRate, 2)}");
                System.Console.WriteLine($"E: {Convert.ToString(EpsilonRate, 2)}");
            }
        }
    }

    public class Part2
    {
        public Part2(string name)
        {
            Input = Inputs.Read<string>(name);
        }

        public IEnumerable<string> Input { get; set; }

        public int O2GenRating { get; set; }
        public int CO2ScrubRating { get; set; }
        public void O2()
        {
            var input = Input.ToArray();

            var columns = input.First().Count();
            for (int i = 0; i < columns; i++)
            {
                var rows = input.Count();

                if (rows == 1)
                {
                    break;
                }

                var ones = input.Count(x => x[i] == '1');
                var zeros = rows - ones;
                var mostCommon = ones >= zeros ? '1' : '0';

                input = input.Where(x => x.ElementAt(i) == mostCommon).ToArray();
            }

            O2GenRating = Convert.ToInt32(input.First(), 2);
        }

        public void CO2()
        {
            var input = Input.ToArray();

            var columns = input.First().Count();
            for (int i = 0; i < columns; i++)
            {
                var rows = input.Count();

                if (rows == 1)
                {
                    break;
                }

                var ones = input.Count(x => x[i] == '1');
                var zeros = rows - ones;
                var leastCommon = ones < zeros ? '1' : '0';

                input = input.Where(x => x.ElementAt(i) == leastCommon).ToArray();
            }

            CO2ScrubRating = Convert.ToInt32(input.First(), 2);
        }
    }
}