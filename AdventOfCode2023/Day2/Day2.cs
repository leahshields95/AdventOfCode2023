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
            FileHelper.ReadFromInputFile(input, (line) => _games.Add(ReadGameFromString(line)));
        }

        public bool IsGamePossible(Game game)
        {
            foreach (var draw in game.Draws)
            {
                foreach (var drawnCubes in draw.AllCubesDrawn)
                {
                    foreach (var maxPossibleCubes in MaxPossible.AllCubesDrawn)
                    {
                        if (drawnCubes.Colour == maxPossibleCubes.Colour && drawnCubes.Count > maxPossibleCubes.Count)
                        {
                            return false;
                        }
                    }
                }
            }

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

        public ColouredCubes GetCountOfColour(Colour colour, String drawString)
        {
            var colourCountRegex = @"(\d*)\s" + colour;
            var match = Regex.Matches(drawString, colourCountRegex, RegexOptions.IgnoreCase).SingleOrDefault();
            var cubeCount = match != null ? Int32.Parse(match.Groups[1].ToString()) : 0;
            return new ColouredCubes(colour, cubeCount);
        }

        public Draw GetDrawFromDrawString(String drawString)
        {
            List<ColouredCubes> drawnCubes = new();
            foreach (Colour colour in Enum.GetValues(typeof(Colour)))
            {
                drawnCubes.Add(GetCountOfColour(colour, drawString));
            }

            return new Draw(drawnCubes.ToArray());
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
            var total = 1;
            foreach (Colour colour in ColourHelper.GetAllColours())
            {
                total *= GetMaximumColourInGame(colour, game);
            }

            return total;
        }

        public int GetMaximum(params int[] numbersOfColourDrawn)
        {
            return numbersOfColourDrawn.Max();
        }

        private int GetMaximumColourInGame(Colour colour, Game game)
        {
            List<int> numberOfColourDrawn = new();
            foreach (var draw in game.Draws)
            {
                numberOfColourDrawn.Add(draw.GetNumberCubesOfColour(colour));
            }

            return GetMaximum(numberOfColourDrawn.ToArray());
        }
    }
}