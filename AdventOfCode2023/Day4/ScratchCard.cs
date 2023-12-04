namespace AdventOfCode2023.Day4;

public class ScratchCard(List<int> winningNumbers, List<int> chosenNumbers)
{
    public int GetNumberOfWinningNumbers()
    {
        return chosenNumbers.Intersect(winningNumbers).Count();
    }

    public int GetPointsScore()
    {
        var totalScoreForCard = 0;
        for (int i = 0; i < GetNumberOfWinningNumbers(); i++)
        {
            totalScoreForCard = totalScoreForCard == 0 ? totalScoreForCard + 1 : totalScoreForCard * 2;
        }

        return totalScoreForCard;
    }
}