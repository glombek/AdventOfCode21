namespace Day6
{
    public class Shoal
    {
        public Shoal(string name)
        {
            Fish = Inputs.Read<string>(name).First().Split(',').Select(x =>byte.Parse(x)).ToList();
        }

        public List<byte> Fish { get; set; }

        public void Age()
        {
            int babyCount = 0;
            int count = Fish.Count();
            for (int i = 0; i < count; i++)
            {
                switch (Fish[i])
                {
                    case 0:
                        babyCount++;
                        Fish[i] = 6;
                        break;
                    default:
                        Fish[i]--;
                        break;
                }
            }

            for (int i = count; i < count + babyCount; i++)
            {
                Fish.Add(8);
            }
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