using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Day3
{
    public class Day3 : IChallenge
    {
        public List<char[]> _data { get; set; } = new();

        private void AddLineToList(String line)
        {
            _data.Add(line.ToCharArray());
        }

        public Day3(String input)
        {
            FileHelper.ReadFromInputFile(input, AddLineToList);
        }

        public int Part1()
        {
            List<string> partNumbers = GetAllPartNumbers();

            return partNumbers.Sum(Int32.Parse);
        }

        public string GetNumberFromChars(int index, char[] line)
        {
            for (int i = index; i >= 0; i--)
            {
                if (!char.IsNumber(line[i]))
                {
                    return GetNumberFromCharsFromStart(i + 1, line);
                }
            }

            return GetNumberFromCharsFromStart(0, line);
        }

        private string GetNumberFromCharsFromStart(int index, char[] line)
        {
            var number = line[index].ToString();

            for (int i = index + 1; i < line.Length; i++)
            {
                if (char.IsNumber(line[i]))
                {
                    number += line[i];
                }
                else
                {
                    break;
                }
            }

            return number;
        }

        private List<string> GetAllPartNumbers()
        {
            List<string> partNumbers = new();
            for (int i = 0; i < _data.Count; i++)
            {
                var line = _data[i];
                var isFirstLine = i == 0;
                var isLastLine = i == _data.Count - 1;

                for (int j = 0; j < line.Length; j++)
                {
                    var digit = line[j];
                    if (char.IsNumber(digit))
                    {
                        string number = GetNumberFromChars(j, line);

                        List<char[]> adjacentLines = new();
                        if (!isFirstLine) adjacentLines.Add(_data[i - 1]);
                        if (!isLastLine) adjacentLines.Add(_data[i + 1]);

                        if (IsPartNumber(new[] { j, j + number.Length - 1 }, line, adjacentLines.ToArray()))
                        {
                            partNumbers.Add(number);
                        }

                        j += number.Length - 1;
                    }
                }
            }

            return partNumbers;
        }

        public int Part2()
        {
            List<int> gearRatios = new();
            for (int i = 0; i < _data.Count; i++)
            {
                var line = _data[i];
                if (line.Contains('*'))
                {
                    for (int j = 0; j < line.Length; j++)
                    {
                        var digit = line[j];
                        if (digit.Equals('*'))
                        {
                            gearRatios.Add(GetGearRatio(j, i));
                        }
                    }
                }
            }

            return gearRatios.Sum();
        }

        public bool IsPartNumber(int[] indices, char[] line, params char[][] adjacentLines)
        {
            // If adjacent on same line
            var firstIndex = indices[0];

            var isStartOfLine = firstIndex == 0;
            if (!isStartOfLine && IsSymbol(line[firstIndex - 1]))
            {
                return true;
            }

            var lastIndex = indices[^1];
            var isEndOfLine = lastIndex == line.Length - 1;

            if (!isEndOfLine && IsSymbol(line[lastIndex + 1]))
            {
                return true;
            }

            foreach (var adjacentLine in adjacentLines)
            {
                // Check diagonals
                if (!isStartOfLine && IsSymbol(adjacentLine[firstIndex - 1]))
                {
                    return true;
                }

                if (!isEndOfLine && IsSymbol(adjacentLine[lastIndex + 1]))
                {
                    return true;
                }

                for (int i = indices[0]; i <= indices[^1]; i++)
                {
                    if (IsSymbol(adjacentLine[i]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsSymbol(char character)
        {
            return !char.IsNumber(character) && !char.IsLetter(character) && !character.Equals('.');
        }

        public int GetGearRatio(int charIndex, int lineIndex)
        {
            List<string> adjacentPartNumbers = new();

            var isStartOfLine = charIndex == 0;
            var isEndOfLine = charIndex == _data[0].Length;

            List<char[]> adjacentLines = new();
            if (lineIndex != 0) adjacentLines.Add(_data[lineIndex - 1]);
            if (lineIndex != _data.Count - 1) adjacentLines.Add(_data[lineIndex + 1]);

            if (!isStartOfLine)
            {
                CheckIfPartNumber(charIndex - 1, lineIndex, adjacentLines, adjacentPartNumbers);
            }

            if (!isEndOfLine)
            {
                CheckIfPartNumber(charIndex + 1, lineIndex, adjacentLines, adjacentPartNumbers, true);
            }

            for (int adjacentLineIndex = lineIndex - 1; adjacentLineIndex <= lineIndex + 1; adjacentLineIndex += 2)
            {
                if (adjacentLineIndex >= 0 && adjacentLineIndex < _data.Count())
                {
                    List<char[]> adjacentLineAdjacentLines = new();
                    if (adjacentLineIndex != 0) adjacentLineAdjacentLines.Add(_data[adjacentLineIndex - 1]);
                    if (adjacentLineIndex != _data.Count - 1)
                        adjacentLineAdjacentLines.Add(_data[adjacentLineIndex + 1]);

                    if (!isStartOfLine)
                    {
                        CheckIfPartNumber(charIndex - 1, adjacentLineIndex, adjacentLineAdjacentLines,
                            adjacentPartNumbers);
                    }

                    if (!isEndOfLine)
                    {
                        CheckIfPartNumber(charIndex + 1, adjacentLineIndex, adjacentLineAdjacentLines,
                            adjacentPartNumbers, true);
                    }

                    CheckIfPartNumber(charIndex, adjacentLineIndex, adjacentLineAdjacentLines, adjacentPartNumbers);
                }
            }

            if (adjacentPartNumbers.Count == 2)
            {
                return Int32.Parse(adjacentPartNumbers[0]) * Int32.Parse(adjacentPartNumbers[1]);
            }

            return 0;
        }

        private void CheckIfPartNumber(int digitIndex, int lineIndex, List<char[]> adjacentLines,
            List<string> adjacentPartNumbers, bool isStartOfNumber = false)
        {
            if (char.IsNumber(_data[lineIndex][digitIndex]))
            {
                var adjacentNumber = GetNumberFromChars(digitIndex, _data[lineIndex]);
                int startIndex;
                int endIndex;
                if (isStartOfNumber)
                {
                    startIndex = digitIndex;
                    endIndex = digitIndex + adjacentNumber.Length - 1;
                }
                else
                {
                    startIndex = digitIndex - adjacentNumber.Length + 1;
                    endIndex = digitIndex;
                }

                if (IsPartNumber(new[] { startIndex, endIndex },
                        _data[lineIndex], adjacentLines.ToArray()))
                {
                    AddToList(adjacentPartNumbers, adjacentNumber);
                }
            }
        }

        private void AddToList(List<string> list, string itemToAdd)
        {
            if (!list.Contains(itemToAdd))
            {
                list.Add(itemToAdd);
            }
        }
    }
}