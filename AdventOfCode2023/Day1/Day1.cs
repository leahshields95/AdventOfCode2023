using System;
using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Day1
{
    public class Day1 : Challenge
    {
        private List<string> Data = new();

        public Day1(String input)
        {
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(input))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Data.Add(line);
                }
            }
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
            
            List<string> digits = new();
            foreach (Match match in Regex.Matches(input, regex, RegexOptions.IgnoreCase))
            {
                digits.Add(match.Groups[1].ToString());
            }

            var result = new char[digits.Count];
            for (int i = 0; i < digits.Count; i++)
            {
                try
                {
                    result[i] = Convert.ToChar(Int32.Parse(digits[i]).ToString());
                }
                catch
                {
                    result[i] = Convert.ToChar(ConvertStringToDigit(digits[i]).ToString());
                }
            }
            return result;
        }

        public int GetCalibrationValue(String line, bool spellingsCount = false)
        {
            char[] digits = spellingsCount
                ? GetAllDigitsFromString(line)
                : string.Concat(line.Where(Char.IsDigit)).ToCharArray();

            var calibrationValue = new StringBuilder();
            calibrationValue.Append(digits[0]);
            calibrationValue.Append(digits[^1]);

            return Int32.Parse(calibrationValue.ToString());
        }

        public int Part1()
        {
            return Data.Sum(d => GetCalibrationValue(d));
        }

        public int Part2()
        {
            return Data.Sum(d => GetCalibrationValue(d, true));
        }
    }
}