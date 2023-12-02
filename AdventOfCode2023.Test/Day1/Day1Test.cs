using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Test.Day1;

using AdventOfCode2023.Day1;

public class Tests
{
    Day1 _day1;

    [SetUp]
    public void SetUp()
    {
        var input = Constants.BasePath + "day1_example.txt";
        _day1 = new Day1(input);
    }

    #region Part1
    [Test]
    public void ShouldReturnFirstAndLastDigit()
    {
        Assert.That(_day1.GetCalibrationValue("1abc2"), Is.EqualTo(12));
    }
    
    [Test]
    public void ShouldReturn27()
    {
        Assert.That(_day1.GetCalibrationValue("ioufd2dsfijoidsfji7dsfjkahkdfjh"), Is.EqualTo(27));
    }    
    
    [Test]
    public void ShouldReturn15()
    {
        Assert.That(_day1.GetCalibrationValue("a1b2c3d4e5f"), Is.EqualTo(15));
    }    
    
    [Test]
    public void ShouldReturnSameDigitTwiceIfOnlyOne()
    {
        Assert.That(_day1.GetCalibrationValue("treb7uchet"), Is.EqualTo(77));
    }

    [Test]
    public void ShouldSumAllCalibrationValues()
    {
        Assert.That(_day1.Part1(), Is.EqualTo(142));
    }
    
    [Test]
    public void ShouldSumAllForPuzzleInput()
    {
        var input = Constants.BasePath + "day1_actual.txt";
        _day1 = new Day1(input);
        
        Assert.That(_day1.Part1(), Is.EqualTo(54605));
    }
    #endregion

    #region Part2
    
    [Test]
    public void ShouldReturnWrittenNumberAsDigit()
    {
        Assert.That(_day1.ConvertStringToDigit("two"), Is.EqualTo(2));
    }
    
    [Test]
    public void ShouldIgnoreCase()
    {
        Assert.That(_day1.ConvertStringToDigit("THREE"), Is.EqualTo(3));
    }

    [Test]
    public void ShouldCountSpelledOutDigits()
    {
        Assert.That(_day1.GetCalibrationValue("two1nine", true), Is.EqualTo(29));
        Assert.That(_day1.GetCalibrationValue("eightwothree", true), Is.EqualTo(83));
        Assert.That(_day1.GetCalibrationValue("abcone2threexyz", true), Is.EqualTo(13));
        Assert.That(_day1.GetCalibrationValue("xtwone3four", true), Is.EqualTo(24));
        Assert.That(_day1.GetCalibrationValue("4nineeightseven2", true), Is.EqualTo(42));
        Assert.That(_day1.GetCalibrationValue("zoneight234", true), Is.EqualTo(14));
        Assert.That(_day1.GetCalibrationValue("7pqrstsixteen", true), Is.EqualTo(76));
    }
    
    [Test]
    public void ShouldCountOverlappingWords()
    {
        Assert.That(_day1.GetCalibrationValue("dgvshjgfdjgoneight", true), Is.EqualTo(18));
    }
    
    [Test] public void ShouldSumAllValuesIncludingWritten()
    {
        var input = Constants.BasePath + "day1_example2.txt";
        _day1 = new Day1(input);
        Assert.That(_day1.Part2(), Is.EqualTo(281));
    }
    
    [Test] public void ShouldSumAllValuesForPuzzleInput()
    {
        var input = Constants.BasePath + "day1_actual.txt";
        _day1 = new Day1(input);
        Assert.That(_day1.Part2(), Is.EqualTo(55429));
    }

    #endregion
}