using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Test.Day6;

public class Tests
{
    AdventOfCode2023.Day6.Day6 _day6;
    private String input;

    [SetUp]
    public void SetUp()
    {
        input = Constants.BasePath + "day6_example.txt";
        _day6 = new AdventOfCode2023.Day6.Day6();
    }
    
    #region Part1
    [Test]
    public void ShouldDetermineNumberOfWaysToWin()
    {
        Assert.That(_day6.Part1(input), Is.EqualTo(288));
    }

    [Test]
    public void ShouldGetSolutionForPart1()
    {
        var input = Constants.BasePath + "day6_actual.txt";
        _day6 = new AdventOfCode2023.Day6.Day6();
        
        Assert.That(_day6.Part1(input), Is.EqualTo(771628));
    }
    #endregion

    #region Part2
    [Test]
    public void ShouldDetermineNumberOfWaysToWinForSingleRace()
    {
        Assert.That(_day6.Part2(input), Is.EqualTo(71503));
    }

    [Test]
    public void ShouldDoPart2ForPuzzleInput()
    {
        var input = Constants.BasePath + "day6_actual.txt";
        _day6 = new AdventOfCode2023.Day6.Day6();

        Assert.That(_day6.Part2(input), Is.EqualTo(27363861));
    }

    #endregion
}