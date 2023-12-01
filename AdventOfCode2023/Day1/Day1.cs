using System;
using System.Text;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Day1
{
    public class Day1 : Challenge
    {
        public string Input;

        public Day1(String input)
        {
            Input = input;
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(input))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
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
