using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Day5
{
    public class Day5 : IChallenge
    {
        public List<int> SeedIds { get; } = new();
        public Dictionary<int, int> SeedToSoil = new();
        public Dictionary<int, int> SoilToFertilizer = new();
        public Dictionary<int, int> FertilizerToWater = new();
        public Dictionary<int, int> WaterToLight = new();
        public Dictionary<int, int> LightToTemperature = new();
        public Dictionary<int, int> TemperatureToHumidity = new();
        public Dictionary<int, int> HumidityToLocation = new();
        private Dictionary<int, int>[] mapsArray;

        private void GetSeedsFromLine(String line)
        {
            var seedsPattern = @"(\d+)";
            var matches = Regex.Matches(line, seedsPattern, RegexOptions.IgnoreCase);

            foreach (Match match in matches)
            {
                SeedIds.Add(Int32.Parse(match.ToString()));
            }
        }

        private void GetNumbersFromLine(MatchCollection matches, Dictionary<int, int> map)
        {
            var destinationId = Int32.Parse(matches[0].ToString());
            var sourceId = Int32.Parse(matches[1].ToString());
            var numberOf = Int32.Parse(matches[2].ToString());

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
                        // Add missing ids to map
                        if (mapNumber >= 0)
                        {
                            for (int i = 0; i < 100; i++)
                            {
                                mapsArray[mapNumber].TryAdd(i, i);
                            }
                        }

                        mapNumber++;
                    }

                    var seedsPattern = @"(\d+)";
                    var matches = Regex.Matches(line, seedsPattern, RegexOptions.IgnoreCase);
                    if (matches.Count > 0)
                    {
                        GetNumbersFromLine(matches, mapsArray[mapNumber]);
                    }
                }
                if (mapNumber >= 0)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        mapsArray[mapNumber].TryAdd(i, i);
                    }
                }
            }
        }

        public Day5(String input)
        {
            ReadFromFile(input);
        }

        public int Part1()
        {
            List<int> locationIds = new List<int>();
            foreach (var seedId in SeedIds)
            {
                var sourceId = seedId;
                foreach (var map in mapsArray)
                {
                    Console.WriteLine(sourceId + " goes to ");
                    sourceId = map.GetValueOrDefault(sourceId);
                    Console.WriteLine(sourceId);
                }
                Console.WriteLine("Adding location " + sourceId);
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