using AdventOfCode2023.Day4;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Test.Day4;

public class ScratchCardTests
{
    private ScratchCard _scratchCard;
   
    [Test]
    public void ShouldGiveNumberOfWinningNumbers()
    {
        var winningNumbers = new List<int>() { 1, 2, 3, 4 };
        var chosenNumbers = new List<int>() { 1, 2, 3, 4 };
        _scratchCard = new ScratchCard(winningNumbers, chosenNumbers);
        Assert.That(_scratchCard.GetNumberOfWinningNumbers(), Is.EqualTo(4));
        
        winningNumbers = new List<int>() { 41, 48, 83, 86, 17 };
        chosenNumbers = new List<int>() { 83, 86,  6, 31, 17,  9, 48, 53 };
        _scratchCard = new ScratchCard(winningNumbers, chosenNumbers);
        Assert.That(_scratchCard.GetNumberOfWinningNumbers(), Is.EqualTo(4));    
        
        winningNumbers = new List<int>() { 87, 83, 26, 28, 32};
        chosenNumbers = new List<int>() { 88, 30, 70, 12, 93, 22, 82, 36 };
        _scratchCard = new ScratchCard(winningNumbers, chosenNumbers);
        Assert.That(_scratchCard.GetNumberOfWinningNumbers(), Is.EqualTo(0));
    }
    
    [Test]
    public void ShouldCalculateScore()
    {
        var winningNumbers = new List<int>() { 1, 2, 3, 4 };
        var chosenNumbers = new List<int>() { 6, 2, 6, 6 };
        _scratchCard = new ScratchCard(winningNumbers, chosenNumbers);
        Assert.That(_scratchCard.GetPointsScore(), Is.EqualTo(1));
        
        winningNumbers = new List<int>() { 41, 48, 83, 86, 17 };
        chosenNumbers = new List<int>() { 83, 86,  6, 31, 17,  9, 48, 53 };
        _scratchCard = new ScratchCard(winningNumbers, chosenNumbers);
        Assert.That(_scratchCard.GetPointsScore(), Is.EqualTo(8));    
        
        winningNumbers = new List<int>() { 87, 83, 26, 28, 32};
        chosenNumbers = new List<int>() { 88, 30, 70, 12, 93, 22, 82, 36 };
        _scratchCard = new ScratchCard(winningNumbers, chosenNumbers);
        Assert.That(_scratchCard.GetPointsScore(), Is.EqualTo(0));
    }
}