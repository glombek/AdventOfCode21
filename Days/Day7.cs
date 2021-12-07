namespace Day7
{
    public class Day7
    {

        public Day7(string name)
        {
            Crabs = Inputs.ReadCsv<int>(name).ToArray();
        }
        public int Run()
        {
            //var meetingPoint = Crabs.IntegerMean();//Crabs.Median();
            var max = Crabs.Max();
            var min = Crabs.Min();

            int leastFuel = int.MaxValue;
            for (int i = min; i <= max; i++)
            {
                var fuel = CalculateFuel(i);
                if(fuel < leastFuel) leastFuel = fuel;
            }

            return leastFuel;
        }

        public int[] Crabs { get; set; }

        public int CalculateFuel(int meetingPoint)
        {
            int fuel = 0;
            foreach (var crab in Crabs)
            {
                var steps = 0;
                if (crab < meetingPoint)
                {
                    steps += meetingPoint - crab;
                }
                else
                {
                    steps += crab - meetingPoint;
                }
                for (int i = 1; i <= steps; i++)
                {
                    fuel += i;
                }
            }
            return fuel;
        }
    }
}


