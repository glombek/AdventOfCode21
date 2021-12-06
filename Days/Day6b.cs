namespace Day6
{
    public static class Day6b {
        public static long DoStuff(string name, int days) {
            var input = Inputs.Read<string>(name).First().Split(',').Select(x =>byte.Parse(x)).ToList();

            var ages = new long[]
            {
                input.Count(x=> x == 0),
                input.Count(x=> x == 1),
                input.Count(x=> x == 2),
                input.Count(x=> x == 3),
                input.Count(x=> x == 4),
                input.Count(x=> x == 5),
                input.Count(x=> x == 6),
                input.Count(x=> x == 7),
                input.Count(x=> x == 8),
            };

            for (int i = 0; i < days; i++)
            {
                ages = new long[] {
                    ages[1],    //0
                    ages[2],    //1
                    ages[3],    //2
                    ages[4],    //3
                    ages[5],    //4
                    ages[6],    //5
                    ages[7] + ages[0],    //6
                    ages[8],    //7
                    ages[0]     //8
                };
            }

            return ages.Sum();
        }
    }
}