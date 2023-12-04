namespace AdventOfCode2023.Day4;

public class ScratchCards(List<ScratchCard> scratchCards)
{
    public int GetTotalScratchCardsAfterWinnings()
    {
        Dictionary<int, int> wonCopies = new();
        foreach (var card in scratchCards)
        {
            // For number of times won, from card after current one, to number won
            for (int copyCardId = card.Id + 1; copyCardId <= card.Id + card.GetNumberOfWinningNumbers(); copyCardId++)
            {
                AddToCopies(copyCardId, GetNumberOfCopies(card.Id, wonCopies) + 1, wonCopies);
            }
        }
        
        return scratchCards.Count + wonCopies.Values.Sum();
    }

    private void AddToCopies(int copyCardId, int numberOfCopies, Dictionary<int,int> wonCopies)
    {
        if (wonCopies.ContainsKey(copyCardId))
        {
            wonCopies[copyCardId] += numberOfCopies;
        }
        else
        {
            wonCopies.Add(copyCardId, numberOfCopies);
        }
    }
    
    private int GetNumberOfCopies(int cardId, Dictionary<int, int> copies)
    {
        Console.WriteLine( copies.TryGetValue(cardId, out var copy2) ? copy2 : 0);
        return copies.TryGetValue(cardId, out var copy) ? copy : 0;
    }
}