using System.Text.RegularExpressions;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Day5
{
    public class Day5 : IChallenge
    {
        public List<int> SeedIds { get; set; } = new();

        private void AddLineToList(String line)
        {
            var regex = @"(?<=\:)(.*?)(?=\|)|(?<=\|)(.*?)(?=$)";
            var matches = Regex.Matches(line, regex, RegexOptions.IgnoreCase);

            var listCount = 0;
            List<int> winningNumbers = new();
            List<int> chosenNumbers = new();
            foreach (Match match in matches)
            {
                
            }
            
        }

        public Day5(String input)
        {
            FileHelper.ReadFromInputFile(input, AddLineToList);
        }

        public int Part1()
        {
            return 0;
        }

        public int Part2()
        {
            return 0;
        }

    }
}