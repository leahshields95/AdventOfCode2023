using System;
using System.Text;
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

        public int GetCalibrationValue(String line)
        {
            char[] digits = string.Concat(line.Where(Char.IsDigit)).ToCharArray();

            var calibrationValue = new StringBuilder();
            calibrationValue.Append(digits[0]);
            calibrationValue.Append(digits[^1]);
            
            return Int32.Parse(calibrationValue.ToString());
        }

        public int Part1()
        {
            return Data.Sum(GetCalibrationValue);
        }

        public int Part2()
        {
            throw new NotImplementedException();
        }
    }
}