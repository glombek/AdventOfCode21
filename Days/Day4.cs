using System.Linq;

namespace Day4
{
    public class BingoCard
    {
        public List<List<(int Value, bool Marked)>> Card { get; set; } = new List<List<(int Value, bool Marked)>>();

        public void Mark(int value)
        {
            foreach (var row in Card)
            {
                for (int i = 0; i < row.Count(); i++)
                {
                    if (row.ElementAt(i).Value == value)
                    {
                        row[i] = (value, true);
                    }
                }
            }
        }

        public bool HasWon()
        {
            var won = false;
            foreach (var row in Card)
            {
                won = row.All(x => x.Marked);
                if (won) return won;
            }

            for (int col = 0; col < Card.First().Count(); col++)
            {
                won = Card.All(x => x.ElementAt(col).Marked);
                if (won) return won;
            }

            return won;
        }

        public int Score(int currentNumber)
        {
            int score = 0;
            foreach (var row in Card)
            {
                score += row.Where(x => !x.Marked).Sum(x => x.Value);
            }
            return score * currentNumber;
        }

        public void Print()
        {
            var won = this.HasWon();
            foreach (var row in Card)
            {
                System.Console.WriteLine(string.Join(' ', row.Select(x => x.Marked ? $"[{x.Value: 00}]" : $" {x.Value: 00}")) + (won ?"\t*":""));
            }
        }
    }

    public class BingoGame
    {
        public BingoGame(string name)
        {
            var raw = Inputs.Read<string>(name);

            Numbers = raw.First().Split(',').Select(x => int.Parse(x));

            BingoCard? currentCard = null;
            for (int i = 2; i < raw.Count(); i++)
            {
                if (currentCard == null)
                {
                    currentCard = new BingoCard();
                    Cards.Add(currentCard);
                }

                var line = raw.ElementAt(i);

                if (line == string.Empty)
                {
                    currentCard = null;
                    continue;
                }

                currentCard.Card.Add(line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => (int.Parse(x), false)).ToList());
            }
        }

        public IEnumerable<int> Numbers { get; set; }
        public List<BingoCard> Cards { get; set; } = new List<BingoCard>();

        public int Play()
        {
            var round = 0;
            var number = 0;

            int? first = null;
            int? last = null;

            do
            {
                Cards = Cards.Where(x => !x.HasWon()).ToList();

                number = Numbers.ElementAt(round);

                foreach (var card in Cards)
                {
                    card.Mark(number);
                    last = card.Score(number);
                }

                if(first == null) {
                    first = Cards.FirstOrDefault(x=>x.HasWon())?.Score(number);
                }

                // Print cards
                System.Console.WriteLine($"Round {round + 1}");
                System.Console.WriteLine($"--------------");
                foreach (var card in Cards)
                {
                    card.Print();
                    System.Console.WriteLine();
                }

                round++;
            } while (Cards.Any(x => !x.HasWon())); //TODO: run the whole game

            return last.Value;
        }
    }
}