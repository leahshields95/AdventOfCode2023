using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Day2
{
    public class Day2 : IChallenge
    {
        private List<Game> _games = new();
        public Draw MaxPossible { get; set; }

        public Day2(String input)
        {
            using (var fileStream = File.OpenRead(input))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    _games.Add(ReadGameFromString(line));
                }
            }
        }

        public bool IsGamePossible(Game game)
        {
            foreach (var draw in game.Draws)
            {
                if (draw.GreenCubes > MaxPossible.GreenCubes || draw.RedCubes > MaxPossible.RedCubes ||
                    draw.BlueCubes > MaxPossible.BlueCubes)
                {
                    Console.WriteLine("Game " + game.Id + " not possible");
                    return false;
                }
            }

            Console.WriteLine("Game " + game.Id + " possible");
            return true;
        }

        public int Part1()
        {
            int total = 0;
            foreach (var game in _games)
            {
                if (IsGamePossible(game))
                {
                    total += game.Id;
                }
            }

            return total;
        }

        public int Part2()
        {
            int total = 0;
            foreach (var game in _games)
            {
                total += GetPowerOfCubesInGame(game);
            }

            return total;
        }

        public int GetIdFromGameString(String line)
        {
            var idRegex = @"Game\s(\d+):";
            var match = Regex.Matches(line, idRegex, RegexOptions.IgnoreCase).Single();
            return Int32.Parse(match.Groups[1].ToString());
        }

        public int GetCountOfColour(String colour, String drawString)
        {
            var colourCountRegex = @"(\d*)\s" + colour;
            var match = Regex.Matches(drawString, colourCountRegex, RegexOptions.IgnoreCase).SingleOrDefault();
            return match != null ? Int32.Parse(match.Groups[1].ToString()) : 0;
        }

        public Draw GetDrawFromDrawString(String drawString)
        {
            int redCount = GetCountOfColour("red", drawString);
            int greenCount = GetCountOfColour("green", drawString);
            int blueCount = GetCountOfColour("blue", drawString);

            return new Draw(redCount, greenCount, blueCount);
        }

        public Draw[] GetDrawsFromGameString(String line)
        {
            List<Draw> draws = new();
            var drawRegex = @"(?=[:;]([^;]*)(;||$))";
            var matches = Regex.Matches(line, drawRegex, RegexOptions.IgnoreCase);
            foreach (Match draw in matches)
            {
                draws.Add(GetDrawFromDrawString(draw.Groups[1].ToString()));
            }

            return draws.ToArray();
        }

        public Game ReadGameFromString(String line)
        {
            var id = GetIdFromGameString(line);
            Draw[] draws = GetDrawsFromGameString(line);
            return new Game(id, draws);
        }

        public int GetPowerOfCubesInGame(Game game)
        {
            int minimumReds = GetMaximumRedsInGame(game);
            int minimumGreens = GetMaximumGreensInGame(game);
            int minimumBlues = GetMaximumBluesInGame(game);

            return minimumReds * minimumGreens * minimumBlues;
        }

        public int GetMaximum(params int[] numbersOfColourDrawn)
        {
            return numbersOfColourDrawn.Max();
        }

        private int GetMaximumRedsInGame(Game game)
        {
            List<int> numberOfRedsDrawn = new();
            foreach (var draw in game.Draws)
            {
                numberOfRedsDrawn.Add(draw.RedCubes);
            }

            return GetMaximum(numberOfRedsDrawn.ToArray());
        }

        private int GetMaximumGreensInGame(Game game)
        {
            List<int> numberOfGreensDrawn = new();
            foreach (var draw in game.Draws)
            {
                numberOfGreensDrawn.Add(draw.GreenCubes);
            }

            return GetMaximum(numberOfGreensDrawn.ToArray());
        }

        private int GetMaximumBluesInGame(Game game)
        {
            List<int> numberOBluesDrawn = new();
            foreach (var draw in game.Draws)
            {
                numberOBluesDrawn.Add(draw.BlueCubes);
            }

            return GetMaximum(numberOBluesDrawn.ToArray());
        }
    }
}