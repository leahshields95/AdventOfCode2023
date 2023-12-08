using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Day6
{
    public class Day6
    {
        private readonly List<long> _times = new();
        private readonly List<long> _distanceRecords = new();
        private List<Race> _races = new();

        private void GetNumbersFromLine(String line)
        {
            var numbersPattern = @"(\d+)";
            var matches = Regex.Matches(line, numbersPattern, RegexOptions.IgnoreCase);

            if (_times.Count == 0)
            {
                foreach (Match match in matches)
                {
                    _times.Add(Int32.Parse(match.ToString()));
                }
            }
            else
            {
                foreach (Match match in matches)
                {
                    _distanceRecords.Add(Int32.Parse(match.ToString()));
                }
            }
        }

        public Day6()
        {
        }

        public int Part1(String input)
        {
            FileHelper.ReadFromInputFileByLine(input, GetNumbersFromLine);
            for (int i = 0; i < _distanceRecords.Count; i++)
            {
                Race race = new Race(_times[i], _distanceRecords[i]);
                _races.Add(race);
            }


            int total = 1;
            foreach (var race in _races)
            {
                total *= race.GetNumberOfWaysToWin();
            }

            return total;
        }

        private void GetNumbersAsSingleFromLine(String line)
        {
            var numbersPattern = @"(\d+)";
            var matches = Regex.Matches(line, numbersPattern, RegexOptions.IgnoreCase);
            String number = "";
            if (_times.Count == 0)
            {
                foreach (Match match in matches)
                {
                    number += match.ToString();
                }
                _times.Add(Int64.Parse(number));
            }
            else
            {
                foreach (Match match in matches)
                {
                    number += match.ToString();
                }
                _distanceRecords.Add(Int64.Parse(number));
            }
        }

        public int Part2(String input)
        {
            FileHelper.ReadFromInputFileByLine(input, GetNumbersAsSingleFromLine);
            Race race = new Race(_times[0], _distanceRecords[0]);

            _races.Add(race);

            return race.GetNumberOfWaysToWin();
        }
    }
}