using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day5
{
    public class Day5
    {
        public List<long> SeedIds { get; } = new();
        public Map SeedToSoil = new();
        public Map SoilToFertilizer = new();
        public Map FertilizerToWater = new();
        public Map WaterToLight = new();
        public Map LightToTemperature = new();
        public Map TemperatureToHumidity = new();
        public Map HumidityToLocation = new();
        private Map[] mapsArray;

        private void GetSeedsFromLine(String line)
        {
            var seedsPattern = @"(\d+)";
            var matches = Regex.Matches(line, seedsPattern, RegexOptions.IgnoreCase);

            foreach (Match match in matches)
            {
                SeedIds.Add(Int64.Parse(match.ToString()));
            }
        }

        private void GetNumbersFromLine(MatchCollection matches, Map map)
        {
            var destinationId = Int64.Parse(matches[0].ToString());
            var sourceId = Int64.Parse(matches[1].ToString());
            var numberOf = Int64.Parse(matches[2].ToString());

            for (int i = 0; i < numberOf; i++)
            {
                map.Add(sourceId + i, destinationId + i);
            }
        }

        public void ReadFromFile(String input)
        {
            mapsArray = new[]
            {
                SeedToSoil, SoilToFertilizer, FertilizerToWater, WaterToLight, LightToTemperature,
                TemperatureToHumidity, HumidityToLocation
            };
            using (var fileStream = File.OpenRead(input))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true))
            {
                GetSeedsFromLine(streamReader.ReadLine());
                String line;
                int mapNumber = -1;
                var newMapPattern = @"(.*-.* map:)";
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (Regex.IsMatch(line, newMapPattern))
                    {
                        mapNumber++;
                    }

                    var seedsPattern = @"(\d+)";
                    var matches = Regex.Matches(line, seedsPattern, RegexOptions.IgnoreCase);
                    if (matches.Count > 0)
                    {
                        GetNumbersFromLine(matches, mapsArray[mapNumber]);
                    }
                }
            }
        }

        public Day5(String input)
        {
            ReadFromFile(input);
        }

        public long Part1()
        {
            List<long> locationIds = new();
            foreach (var seedId in SeedIds)
            {
                var sourceId = seedId;
                foreach (var map in mapsArray)
                {
                    sourceId = map.GetDestinationIdFromSourceId(sourceId);
                }
                locationIds.Add(sourceId);
            }

            return locationIds.Min();
        }

        public int Part2()
        {
            return 0;
        }
    }
}