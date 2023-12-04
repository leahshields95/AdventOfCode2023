using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Test.Day4;

public class Tests
{
    AdventOfCode2023.Day4.Day4 _day4;

    [SetUp]
    public void SetUp()
    {
        var input = Constants.BasePath + "day4_example.txt";
        _day4 = new AdventOfCode2023.Day4.Day4(input);
    }

    #region Part1

    [Test]
    public void ShouldGetNumbersFromString()
    {
        List<int> expected = new() { 12, 2, 31, 4 };
        var result = _day4.GetNumbersFromString("12 2 31 4");
        
        Assert.That(result.Count(), Is.EqualTo(expected.Count));

        for (int i = 0; i < result.Count; i++)
        {
            Assert.That(result[i], Is.EqualTo(expected[i]));
        }
    }

    [Test]
    public void ShouldGetTotalScore()
    {
        Assert.That(_day4.Part1(), Is.EqualTo(13));
    }

    [Test]
    public void ShouldDoPart1ForPuzzleInput()
    {
        var input = Constants.BasePath + "day4_actual.txt";
        _day4 = new AdventOfCode2023.Day4.Day4(input);

        Assert.That(_day4.Part1(), Is.EqualTo(26218));
    }

    #endregion

    #region Part2

    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day4.Part2(), Is.EqualTo(30));
    }

    [Test]
    public void ShouldDoPart2ForPuzzleInput()
    {
        var input = Constants.BasePath + "day4_actual.txt";
        _day4 = new AdventOfCode2023.Day4.Day4(input);

        Assert.That(_day4.Part2(), Is.EqualTo(0));
    }

    #endregion
}