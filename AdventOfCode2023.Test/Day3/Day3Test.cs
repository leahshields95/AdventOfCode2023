using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Test.Day3;

using AdventOfCode2023.Day3;

public class Tests
{
    Day3 _day3;

    [SetUp]
    public void SetUp()
    {
        var input = Constants.BasePath + "day3_example.txt";
        _day3 = new Day3(input);
    }

    #region Part1
    [Test]
    public void ShouldDoSomethingWithPuzzleInput()
    {
        var input = Constants.BasePath + "day3_actual.txt";
        _day3 = new Day3(input);

        Assert.That(_day3.Part1(), Is.EqualTo(0));
    }

    #endregion

    #region Part2
    

    [Test]
    public void ShouldFindPowerOfCubesFromPuzzleInput()
    {
        var input = Constants.BasePath + "day3_actual.txt";
        _day3 = new Day3(input);

        Assert.That(_day3.Part2(), Is.EqualTo(0));
    }

    #endregion
}