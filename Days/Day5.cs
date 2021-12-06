namespace Day5
{
    public class Day5
    {
        public Day5(string name)
        {
            var raw = Inputs.Read<string>(name);
            Vents = raw.Select(x => new VentSeries(x));


            var maxX = Vents.Max(vent => Max(vent.Start.x, vent.End.x)) + 1;
            var maxY = Vents.Max(vent => Max(vent.Start.y, vent.End.y)) + 1;

            Map = new int[maxX, maxY];
        }
        public IEnumerable<VentSeries> Vents { get; set; }

        public int[,] Map { get; set; }

        public int PlotVents(int threshold = 2)
        {
            int count = 0;

            // for (int y = 0; y < Map.GetLength(1); y++)
            // {
            //     for (int x = 0; x < Map.GetLength(0); x++)
            //     {
            //         var n = Vents.Count(vent => vent.Intersects((x, y)));
            //         Map[x, y] = n;
            //         //Console.Write($"{n} ");

            //         if(n >= threshold) count++;
            //     }
            //     //Console.WriteLine();
            // }

            foreach (var vent in Vents)
            {
                vent.Plot(Map, ref count);
            }

            //Output
            
            // for (int y = 0; y < Map.GetLength(1); y++)
            // {
            //     for (int x = 0; x < Map.GetLength(0); x++)
            //     {
            //         var o = (Map[x, y] == 0) ? "." : Map[x, y].ToString();
            //         Console.Write($"{o} ");
            //     }
            //     Console.WriteLine();
            // }

            return count;
        }

        private int Max(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            return b;
        }


    }

    public class VentSeries
    {
        public VentSeries(string data)
        {
            var parts = data.Split(new string[] { " -> ", "," }, StringSplitOptions.None);

            Start = (int.Parse(parts[0]), int.Parse(parts[1]));
            End = (int.Parse(parts[2]), int.Parse(parts[3]));
        }
        public (int x, int y) Start { get; set; }
        public (int x, int y) End { get; set; }

        // public bool Intersects((int x, int y) point)
        // {
        //     return
        //     point.x.Between(Start.x, End.x)
        //     && point.y.Between(Start.y, End.y)
        //     && ((point.x == Start.x && point.x == End.x) || (point.y == Start.y && point.y == End.y));
        // }

        public void Plot(int[,] map, ref int count)
        {
            // if (Start.x == End.x)
            // {
            //     for (int y = Math.Min(Start.y, End.y); y <= Math.Max(Start.y, End.y); y++)
            //     {
            //         map[Start.x, y]++;
            //         if (map[Start.x, y] == 2) count++;
            //     }
            // }
            // else if (Start.y == End.y)
            // {
            //     for (int x = Math.Min(Start.x, End.x); x <= Math.Max(Start.x, End.x); x++)
            //     {
            //         map[x, Start.y]++;
            //         if (map[x, Start.y] == 2) count++;
            //     }
            // }
            // else
            // {
            var p = Start;
            do
            {
                map[p.x, p.y]++;
                if (map[p.x, p.y] == 2) count++;

                var x = p.x;
                var y = p.y;
                if (End.x < Start.x)
                {
                    x--;
                }
                else if (End.x > Start.x)
                {
                    x++;
                }

                if (End.y < Start.y)
                {
                    y--;
                }
                else if (End.y > Start.y)
                {
                    y++;
                }
                p = (x, y);
            } while (p != End);
            map[p.x, p.y]++;
            if (map[p.x, p.y] == 2) count++;
        }

        public override string ToString()
        {
            return $"{Start.x},{Start.y} => {End.x},{End.y}";
        }

    }

    public static class Extensions
    {
        public static bool Between(this int test, int a, int b)
        {
            if (a > b)
            {
                return test <= a && test >= b;
            }
            return test <= b && test >= a;
        }
    }
}