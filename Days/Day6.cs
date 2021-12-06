namespace Day6
{

    public class Lanternfish
    {
        public Lanternfish(int cycle)
        {
            Cycle = cycle;
        }

        public Lanternfish()
        {
            Cycle = 8;
        }

        public int Cycle { get; set; }

        public override string ToString()
        {
            return Cycle.ToString();
        }

    }

    public class Shoal
    {
        public Shoal(string name)
        {
            Fish = Inputs.Read<string>(name).First().Split(',').Select(x => new Lanternfish(int.Parse(x))).ToList();
        }

        public List<Lanternfish> Fish { get; set; }

        public void Age()
        {
            List<Lanternfish> babies = new List<Lanternfish>();

            foreach (var fish in Fish)
            {
                switch (fish.Cycle)
                {
                    case 0:
                        babies.Add(new Lanternfish());
                        fish.Cycle = 6;
                        break;
                    default:
                        fish.Cycle--;
                        break;
                }
            }

            Fish.AddRange(babies);
        }

        public int SimulateDays(int numDays = 80, bool debug = true)
        {
            if (debug) System.Console.WriteLine($"Initial state: {this.ToString()}");
            
            for (int i = 0; i < numDays; i++)
            {
                Age();
                if (debug) System.Console.WriteLine($"After {i:00} days: {this.ToString()}");
            }
            return Fish.Count();
        }

        public override string ToString()
        {
            return string.Join(',', Fish.Select(x => x.ToString()));
        }
    }
}