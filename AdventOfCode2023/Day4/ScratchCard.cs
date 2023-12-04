namespace AdventOfCode2023.Day4;

public class ScratchCard(int id, List<int> winningNumbers, List<int> chosenNumbers)
{
    public int Id { get; } = id;

    public int GetNumberOfWinningNumbers()
    {
        return chosenNumbers.Intersect(winningNumbers).Count();
    }
    
    // TODO: Get winning cards method

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