using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Test.Day6;

public class Tests
{
    AdventOfCode2023.Day6.Day6 _day6;

    [SetUp]
    public void SetUp()
    {
        var input = Constants.BasePath + "day6_example.txt";
        _day6 = new AdventOfCode2023.Day6.Day6(input);
    }

    [Test]
    public void ShouldDetermineNumberOfWaysToWin()
    {
        Assert.That(_day6.Part1(), Is.EqualTo(288));
    }

    #region Part1




    #endregion

    #region Part2

    [Test]
    public void ShouldDoPart2()
    {
      
    }

    [Test]
    public void ShouldDoPart2ForPuzzleInput()
    {
        var input = Constants.BasePath + "day6_actual.txt";
        _day6 = new AdventOfCode2023.Day6.Day6(input);

    }

    #endregion
}