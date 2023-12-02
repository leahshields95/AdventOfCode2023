using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Test.Day2;

using AdventOfCode2023.Day2;

public class Tests
{
    Day2 day2;

    [SetUp]
    public void SetUp()
    {
        var input = Constants.BasePath + "day2_example.txt";
        day2 = new Day2(input);
    }

    #region Part1
    [Test]
    public void ShouldReturnTrueIfGamePossible() { 
        Assert.That(day2.IsGamePossible(), Is.EqualTo(142));
    }

    [Test]
    public void ShouldSumAllPossibleGames()
    {
        Assert.That(day2.Part1(), Is.EqualTo(8));
    }

    #endregion

    #region Part2


    #endregion
}
