using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Day4
{
    public class Day4 : IChallenge
    {
        public List<char[]> _data { get; set; } = new();

        private void AddLineToList(String line)
        {
            _data.Add(line.ToCharArray());
        }

        public Day4(String input)
        {
            FileHelper.ReadFromInputFile(input, AddLineToList);
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