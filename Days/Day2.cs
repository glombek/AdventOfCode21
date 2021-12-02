namespace Day2
{
    public class Submarine
    {
        public int HorizontalPosition { get; set; }
        public int Depth { get; set; }
        public int Aim { get; set; }
        public IEnumerable<Instruction> Instructions { get; set; }

        public Submarine(string name)
        {
            Instructions = Inputs.Read<string>(name).Select(x=> new Instruction(x));
            HorizontalPosition = 0;
            Depth = 0;
            Aim = 0;
        }

        public void Run() {
            foreach (var instruction in Instructions)
            {
                switch (instruction.Vector) {
                    case Direction.up:
                        Aim -= instruction.Magnitude;
                        break;
                    case Direction.down:
                        Aim += instruction.Magnitude;
                        break;
                    case Direction.forward:
                        HorizontalPosition += instruction.Magnitude;
                        Depth += (instruction.Magnitude * Aim);
                        break;
                }
            }
        }

        public int Result => HorizontalPosition * Depth;
    }

    public class Instruction
    {
        public Instruction(string instruction)
        {
            var parts = instruction.Split(' ');
            Vector = Enum.Parse<Direction>(parts[0]);
            Magnitude = int.Parse(parts[1]);
        }

        public Direction Vector { get; set; }
        public int Magnitude { get; set; }
    }

    public enum Direction
    {
        up,
        down,
        forward
    }
}