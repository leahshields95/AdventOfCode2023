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

            var listCount = 0;
            List<int> winningNumbers = new();
            List<int> chosenNumbers = new();
            foreach (Match match in matches)
            {
                List<int> numbers = GetNumbersFromString(match.ToString());
                if (listCount == 0)
                {
                    winningNumbers = numbers;
                }
                else if (listCount == 1)
                {
                    chosenNumbers = numbers;
                }

                listCount++;
            }

            var scratchCard = new ScratchCard(GetIdFromCardString(line), winningNumbers, chosenNumbers);
            ScratchCards.Add(scratchCard);
        }
        
        public int GetIdFromCardString(String line)
        {
            var idRegex = @"Card\s+(\d+):";
            var match = Regex.Matches(line, idRegex, RegexOptions.IgnoreCase).Single();
            return Int32.Parse(match.Groups[1].ToString());
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
            return ScratchCards.Sum(card => card.GetPointsScore());
        }

        public int Part2()
        {
            ScratchCards allScratchCards = new ScratchCards(ScratchCards);
            return allScratchCards.GetTotalScratchCardsAfterWinnings();
        }
    }
}