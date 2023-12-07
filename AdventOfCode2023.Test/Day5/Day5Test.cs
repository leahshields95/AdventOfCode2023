using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Test.Day5;

public class Tests
{
    AdventOfCode2023.Day5.Day5 _day5;

    [SetUp]
    public void SetUp()
    {
        var input = Constants.BasePath + "day5_example.txt";
        _day5 = new AdventOfCode2023.Day5.Day5(input);
    }

    #region Part1

    [Test]
    public void ShouldGetSeedIdsFromFile()
    {
        Assert.That(_day5.SeedIds[0], Is.EqualTo(79));
        Assert.That(_day5.SeedIds[1], Is.EqualTo(14));
        Assert.That(_day5.SeedIds[2], Is.EqualTo(55));
        Assert.That(_day5.SeedIds[3], Is.EqualTo(13));
    }

    [Test]
    public void ShouldPopulateSeedToSoilMapWithIds()
    {
        Assert.That(_day5.SeedToSoil.GetDestinationIdFromSourceId(98), Is.EqualTo(50));
        Assert.That(_day5.SeedToSoil.GetDestinationIdFromSourceId(99), Is.EqualTo(51));
        Assert.That(_day5.SeedToSoil.GetDestinationIdFromSourceId(53), Is.EqualTo(55));
    }
    
    [Test]
    public void NoneMappedIdsShouldBeSame()
    {
        Assert.That(_day5.SeedToSoil.GetDestinationIdFromSourceId(48), Is.EqualTo(48));
    }
    
    [Test]
    public void ShouldPopulateHumidityToLocationMapWithIds()
    {
        Assert.That(_day5.HumidityToLocation.GetDestinationIdFromSourceId(56), Is.EqualTo(60));
        Assert.That(_day5.HumidityToLocation.GetDestinationIdFromSourceId(43), Is.EqualTo(43));
    }

    [Test]
    public void ShouldGetLowestLocation()
    {
        Assert.That(_day5.Part1(), Is.EqualTo(35));
    }

    [Test]
    public void ShouldDoPart1ForPuzzleInput()
    {
        var input = Constants.BasePath + "day5_actual.txt";
        _day5 = new AdventOfCode2023.Day5.Day5(input);
        
        Assert.That(_day5.Part1(), Is.EqualTo(88151870));
    }

    #endregion

    #region Part2

    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day5.Part2(), Is.EqualTo(46));
    }

    [Test]
    public void ShouldDoPart2ForPuzzleInput()
    {
        var input = Constants.BasePath + "day5_actual.txt";
        _day5 = new AdventOfCode2023.Day5.Day5(input);

        Assert.That(_day5.Part2(), Is.EqualTo(46));
    }

    #endregion
}