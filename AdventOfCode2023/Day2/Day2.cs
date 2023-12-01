using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Day2
{
    public class Day2 : Challenge
    {
        private List<string> Data = new();

        public Day2(String input)
        {
            using (var fileStream = File.OpenRead(input))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Data.Add(line);
                }
            }
        }
        

        public int Part1()
        {
            throw new NotImplementedException();
        }

        public int Part2()
        {
            throw new NotImplementedException();
        }
    }
}