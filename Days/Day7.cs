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
            var meetingPoint = Crabs.Median();

            return CalculateFuel(meetingPoint);
        }

        public int[] Crabs { get; set; }

        public int CalculateFuel(int meetingPoint)
        {
            int fuel = 0;
            foreach (var crab in Crabs)
            {
                if (crab < meetingPoint)
                {
                    fuel += meetingPoint - crab;
                }
                else
                {
                    fuel += crab - meetingPoint;
                }
            }
            return fuel;
        }
    }
}