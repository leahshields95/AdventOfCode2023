using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Day1
{
    public class Day1 : IChallenge
    {
        private List<string> _data = new();

        public Day1(String input)
        {
            FileHelper.ReadFromInputFileByLine(input, (line) => _data.Add(line));
        }

        public int ConvertStringToDigit(String writtenNumber)
        {
            switch (writtenNumber.ToLower())
            {
                case "one": return 1;
                case "two": return 2;
                case "three": return 3;
                case "four": return 4;
                case "five": return 5;
                case "six": return 6;
                case "seven": return 7;
                case "eight": return 8;
                case "nine": return 9;
                default: return 0;
            }
        }

        public char[] GetAllDigitsFromString(String input)
        {
            var regex = @"(?=(\d|one|two|three|four|five|six|seven|eight|nine))";

            var matches = Regex.Matches(input, regex, RegexOptions.IgnoreCase);
            var digits = new char[matches.Count];
            var count = 0;
            foreach (Match match in matches)
            {
                var matchName = match.Groups[1].ToString();
                int i;
                digits[count] = Convert.ToChar(Int32.TryParse(matchName, out i) ? i.ToString() : ConvertStringToDigit(matchName).ToString());
                count++;
            }
            return digits;
        }

        public int GetCalibrationValue(String line, bool spellingsCount = false)
        {
            char[] digits = spellingsCount
                ? GetAllDigitsFromString(line)
                : string.Concat(line.Where(Char.IsDigit)).ToCharArray();

            var calibrationValue = digits[0].ToString() + digits[^1];

            return Int32.Parse(calibrationValue);
        }

        public int Part1()
        {
            return _data.Sum(d => GetCalibrationValue(d));
        }

        public int Part2()
        {
            return _data.Sum(d => GetCalibrationValue(d, true));
        }
    }
}