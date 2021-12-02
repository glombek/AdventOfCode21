namespace Day2
{
    public class Submarine
    {
        public int Forward { get; set; }
        public int Depth { get; set; }
        public IEnumerable<Instruction> Instructions { get; set; }

        public Submarine(string name)
        {
            Instructions = Inputs.Read<string>(name).Select(x=> new Instruction(x));
            Forward = 0;
            Depth = 0;
        }

        public void Run() {
            foreach (var instruction in Instructions)
            {
                switch (instruction.Vector) {
                    case Direction.up:
                        Depth -= instruction.Magnitude;
                        break;
                    case Direction.down:
                        Depth += instruction.Magnitude;
                        break;
                    case Direction.forward:
                        Forward += instruction.Magnitude;
                        break;
                }
            }
        }

        public int Result => Forward * Depth;
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