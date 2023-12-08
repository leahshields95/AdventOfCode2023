using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Day6
{
    public class Day6
    {
        private readonly List<int> _times = new ();
        private readonly List<int> _distanceRecords = new ();
        private List<Race> _races = new();

        private void GetNumbersFromLine(String line)
        {
            var numbersPattern = @"(\d+)";
            var matches = Regex.Matches(line, numbersPattern, RegexOptions.IgnoreCase);

            if (_times.Count != 0)
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

        public Day6(String input)
        {
            FileHelper.ReadFromInputFileByLine(input, GetNumbersFromLine);
            
            for (int i = 0; i < _distanceRecords.Count; i++)
            {
                Race race = new Race(_times[i], _distanceRecords[i]);
                _races.Add(race);
            }
        }

        public int Part1()
        {
            int total = 1;
            foreach (var race in _races)
            {
                total *= race.GetNumberOfWaysToWin();
            }
            return total;
        }

        public int Part2()
        {

            return 0;
        }
    }
}