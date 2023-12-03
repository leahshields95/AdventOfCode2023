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
    public void ShouldReturnTrueForSymbols()
    {
        Assert.True(_day3.IsSymbol('$'));
        Assert.True(_day3.IsSymbol('*'));
        Assert.True(_day3.IsSymbol('&'));
        Assert.True(_day3.IsSymbol('!'));
        Assert.True(_day3.IsSymbol('#'));
        Assert.True(_day3.IsSymbol('/'));
        Assert.True(_day3.IsSymbol('='));
        Assert.True(_day3.IsSymbol('@'));
    }

    [Test]
    public void ShouldReturnFalseForFullStopAndDigits()
    {
        Assert.False(_day3.IsSymbol('.'));
        Assert.False(_day3.IsSymbol('2'));
    }

    [Test]
    public void ShouldReturnTrueIfNumberAdjacentToSymbol()
    {
        var firstLine = new[] { '1', '*', '.' };
        var secondLine = new[] { '2', '3', '4' };

        var result = _day3.IsPartNumber(new[] { 0 }, firstLine, secondLine);
        Assert.True(result);
    }

    [Test]
    public void ShouldReturnTrueIfNumberAdjacentToSymbolDirectlyBelow()
    {
        var firstLine = new[] { '1', '2', '3' };
        var secondLine = new[] { '.', '*', '.' };

        var result = _day3.IsPartNumber(new[] { 0, 1, 2 }, firstLine, secondLine);
        Assert.True(result);
    }

    [Test]
    public void ShouldReturnTrueIfNumberAdjacentToSymbolDiagonallyBelow()
    {
        var firstLine = new[] { '1', '.', '.' };
        var secondLine = new[] { '.', '$', '.' };

        var result = _day3.IsPartNumber(new[] { 0 }, firstLine, secondLine);
        Assert.True(result);
    }

    [Test]
    public void ShouldReturnTrueIfNumberAdjacentToSymbolDirectlyAbove()
    {
        var firstLine = new[] { '.', '!', '.' };
        var secondLine = new[] { '.', '1', '.' };

        var result = _day3.IsPartNumber(new[] { 1 }, secondLine, firstLine);
        Assert.True(result);
    }

    [Test]
    public void ShouldReturnTrueIfNumberAdjacentToSymbolDiagonallyAbove()
    {
        var firstLine = new[] { '!', '.', '.' };
        var secondLine = new[] { '.', '1', '.' };

        var result = _day3.IsPartNumber(new[] { 1 }, secondLine, firstLine);
        Assert.True(result);
    }

    [Test]
    public void ShouldReturnTrueIfThreeDigitNumberAdjacentToSymbol()
    {
        var firstLine = new[] { '1', '2', '3' };
        var secondLine = new[] { '.', '&', '.' };

        var result = _day3.IsPartNumber(new[] { 0 }, firstLine, secondLine);
        Assert.True(result);
    }

    [Test]
    public void ShouldReturnFalseIfNumberNotAdjacentToSymbol()
    {
        var firstLine = new[] { '1', '.', '.' };
        var secondLine = new[] { '2', '3', '4' };

        var result = _day3.IsPartNumber(new[] { 0 }, firstLine, secondLine);
        Assert.False(result);
    }

    [Test]
    public void ShouldReturnFalseIfNumberNotAdjacentToSymbolMultipleLines()
    {
        var firstLine = new[] { '1', '.', '.' };
        var secondLine = new[] { '2', '3', '4' };
        var thirdLine = new[] { '2', '3', '4' };

        var result = _day3.IsPartNumber(new[] { 0, 1, 2 }, secondLine, firstLine, thirdLine);

        Assert.False(result);
    }

    [Test]
    public void ShouldReturnThreeDigitNumber()
    {
        var line = new[] { '.', '.', '2', '3', '2', '.', '5' };

        var result = _day3.GetNumberFromChars(2, line);
        Assert.That(result, Is.EqualTo("232"));
    }

    [Test]
    public void ShouldGetSumOfAllPartNumbers()
    {
        Assert.That(_day3.Part1(), Is.EqualTo(4361));
    }

    [Test]
    public void ShouldSumAllPartNumbersInPuzzleInput()
    {
        var input = Constants.BasePath + "day3_actual.txt";
        _day3 = new Day3(input);

        Assert.That(_day3.Part1(), Is.EqualTo(509115));
    }

    #endregion

    #region Part2

    [Test]
    public void ShouldGetNumberWhenStartUnknown()
    {
        var firstLine = new[] { '.', '.', '2', '3', '5', '.', '5' };
        var secondLine = new[] { '4', '6', '7', '.', '.', '1' };

        Assert.That(_day3.GetNumberFromChars(3, firstLine), Is.EqualTo("235"));
        Assert.That(_day3.GetNumberFromChars(2, secondLine), Is.EqualTo("467"));
    }

    [Test]
    public void ShouldReturnGearRatioSingleNumbers()
    {
        var firstLine = new[] { '4', '*', '7', '.' };

        _day3._data = new List<char[]> { firstLine };

        var gearRatios = _day3.GetGearRatio(1, 0);
        Assert.That(gearRatios, Is.EqualTo(28));
    }

    [Test]
    public void ShouldReturnGearRatio()
    {
        var firstLine = new[] { '4', '6', '7', '.', '.', '1' };
        var secondLine = new[] { '.', '.', '.', '*', '.', '.' };
        var thirdLine = new[] { '.', '.', '3', '5', '.', '.' };

        _day3._data = new List<char[]>() { firstLine, secondLine, thirdLine };
        var gearRatios = _day3.GetGearRatio(3, 1);
        Assert.That(gearRatios, Is.EqualTo(16345));
    }
    
    [Test]
    public void ShouldSumAllGearRatios()
    {
        Assert.That(_day3.Part2(), Is.EqualTo(467835));
    }

    [Test]
    public void ShouldSumAllGearRatiosFromPuzzleInput()
    {
        var input = Constants.BasePath + "day3_actual.txt";
        _day3 = new Day3(input);

        Assert.That(_day3.Part2(), Is.EqualTo(75220503));
    }

    #endregion
}