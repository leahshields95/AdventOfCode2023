using System.Text.RegularExpressions;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Day5
{
    public class Day5 : IChallenge
    {
        public List<int> SeedIds { get; set; } = new();
        public Dictionary<int, int> SeedToSoil = new();
        public Dictionary<int, int> SoilToFertilizer = new();
        public Dictionary<int, int> FertilizerToWater = new();
        public Dictionary<int, int> WaterToLight = new();
        public Dictionary<int, int> LightToTemperature = new();
        public Dictionary<int, int> TemperatureToHumidity = new();
        public Dictionary<int, int> HumidityToLocation = new();

        private void AddLineToList(String line)
        {
            var seedsPattern = @"(?<=\:)(.*?)(?=$)";
            var matches = Regex.Matches(line, seedsPattern, RegexOptions.IgnoreCase);
            if (matches.Count > 0)
                AddSeedIds(matches.Single().ToString());
            
            
            
        }

        public Day5(String input)
        {
            FileHelper.ReadFromInputFileByLine(input, AddLineToList);
        }

        public int Part1()
        {
            return 0;
        }

        public int Part2()
        {
            return 0;
        }

        public void AddSeedIds(string line)
        {
            var getAllNumbersPattern = @"(\d+)";
            var matches = Regex.Matches(line, getAllNumbersPattern, RegexOptions.IgnoreCase);
            foreach (Match match in matches)
            {
                SeedIds.Add(Int32.Parse(match.ToString()));
            }
        }
    }
}