using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Test.Day1;

using AdventOfCode2023.Day1;

public class Tests
{
    Day1 day1;

    [SetUp]
    public void SetUp()
    {
        var input = Constants.BasePath + "day1_example.txt";
        day1 = new Day1(input);
    }

    [Test]
    public void ShouldReturnFirstAndLastDigit()
    {
        Assert.That(day1.GetCalibrationValue("1abc2"), Is.EqualTo(12));
    }
    
    [Test]
    public void ShouldReturn27()
    {
        Assert.That(day1.GetCalibrationValue("ioufd2dsfijoidsfji7dsfjkahkdfjh"), Is.EqualTo(27));
    }    
    
    [Test]
    public void ShouldReturn15()
    {
        Assert.That(day1.GetCalibrationValue("a1b2c3d4e5f"), Is.EqualTo(15));
    }    
    
    [Test]
    public void ShouldReturnSameDigitTwiceIfOnlyOne()
    {
        Assert.That(day1.GetCalibrationValue("treb7uchet"), Is.EqualTo(77));
    }

    [Test]
    public void ShouldSumAllCalibrationValues()
    {
        Assert.That(day1.Part1(), Is.EqualTo(142));
    }
    
    [Test]
    public void ShouldSumAllForPuzzleInput()
    {
        var input = Constants.BasePath + "day1_actual.txt";
        day1 = new Day1(input);
        
        Assert.That(day1.Part1(), Is.EqualTo(54605));
    }
}