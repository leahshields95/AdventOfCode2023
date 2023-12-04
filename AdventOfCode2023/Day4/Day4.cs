using System.Text.RegularExpressions;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Day4
{
    public class Day4 : IChallenge
    {
        public List<ScratchCard> ScratchCards { get; set; } = new();

        private void AddLineToList(String line)
        {
            var regex = @"(?<=\:)(.*?)(?=\|)|(?<=\|)(.*?)(?=$)";
            var matches = Regex.Matches(line, regex, RegexOptions.IgnoreCase);

            var count = 0;
            List<int> winningNumbers = new();
            List<int> chosenNumbers = new();
            foreach (Match match in matches)
            {
                List<int> numbers = GetNumbersFromString(match.ToString());
                if (count == 0)
                {
                    winningNumbers = numbers;
                }
                else if (count == 1)
                {
                    chosenNumbers = numbers;
                }

                count++;
            }

            ScratchCard scratchCard = new ScratchCard(winningNumbers, chosenNumbers);
            ScratchCards.Add(scratchCard);
        }

        public List<int> GetNumbersFromString(string numbers)
        {
            List<int> numbersList = new();
            var regex = @"(\d+)";
            var matches = Regex.Matches(numbers, regex, RegexOptions.IgnoreCase);
            foreach (Match match in matches)
            {
                numbersList.Add(Int32.Parse(match.ToString()));
            }

            return numbersList;
        }

        public Day4(String input)
        {
            FileHelper.ReadFromInputFile(input, AddLineToList);
        }

        public int Part1()
        {
            int total = 0;
            foreach (var card in ScratchCards)
            {
                total += card.GetPointsScore();
            }
            return total;
        }

        public int Part2()
        {
            throw new NotImplementedException();
        }
    }
}