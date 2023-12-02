using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Test.Day2;

using AdventOfCode2023.Day2;

public class Tests
{
    Day2 _day2;

    [SetUp]
    public void SetUp()
    {
        var input = Constants.BasePath + "day2_example.txt";
        _day2 = new Day2(input);
        _day2.MaxPossible = new Draw(12, 13, 14);
    }

    #region Part1

    [Test]
    public void ShouldReturnTrueIfGamePossible()
    {
        Draw firstDraw = new Draw(3, 4, 1);
        Draw secondDraw = new Draw(2, 6, 2);
        Assert.IsTrue(_day2.IsGamePossible(new Game(1, firstDraw, secondDraw)));
    }

    [Test]
    public void ShouldReturnFalseIfGameImpossible()
    {
        Draw firstDraw = new Draw(1, 3, 6);
        Draw secondDraw = new Draw(2, 6, 0);
        Draw thirdDraw = new Draw(3, 15, 14);
        Assert.IsFalse(_day2.IsGamePossible(new Game(4, firstDraw, secondDraw, thirdDraw)));
    }

    [Test]
    public void ShouldGetSingleDigitId()
    {
        Assert.That(_day2.GetIdFromGameString("Game 2: "), Is.EqualTo(2));
    }

    [Test]
    public void ShouldGetDoubleDigitId()
    {
        Assert.That(_day2.GetIdFromGameString("Game 12: "), Is.EqualTo(12));
    }

    [Test]
    public void ShouldGetDrawFromGameString()
    {
        var expected = new Draw(4, 1, 3);
        var result = _day2.GetDrawFromDrawString("1 green, 3 blue, 4 red");

        Assert.That(result.GreenCubes, Is.EqualTo(expected.GreenCubes));
        Assert.That(result.RedCubes, Is.EqualTo(expected.RedCubes));
        Assert.That(result.BlueCubes, Is.EqualTo(expected.BlueCubes));
    }

    [Test]
    public void ShouldGetDrawFromGameStringWhenOneValue0()
    {
        var expected = new Draw(4, 1, 0);
        var result = _day2.GetDrawFromDrawString("1 green, 0 blue, 4 red");

        Assert.That(result.GreenCubes, Is.EqualTo(expected.GreenCubes));
        Assert.That(result.RedCubes, Is.EqualTo(expected.RedCubes));
        Assert.That(result.BlueCubes, Is.EqualTo(expected.BlueCubes));
    }
    
    [Test]
    public void ShouldGetAllDrawsFromGameString()
    {
        var result = _day2.GetDrawsFromGameString("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red");

        Assert.That(result.Length, Is.EqualTo(3));
        
        Assert.That(result[0].GreenCubes, Is.EqualTo(1));
        Assert.That(result[0].RedCubes, Is.EqualTo(3));
        Assert.That(result[0].BlueCubes, Is.EqualTo(6));
        
        Assert.That(result[1].GreenCubes, Is.EqualTo(3));
        Assert.That(result[1].RedCubes, Is.EqualTo(6));
        Assert.That(result[1].BlueCubes, Is.EqualTo(0));
        
        Assert.That(result[2].GreenCubes, Is.EqualTo(3));
        Assert.That(result[2].RedCubes, Is.EqualTo(14));
        Assert.That(result[2].BlueCubes, Is.EqualTo(15));
    }

    [Test]
    public void ShouldGetNumberOfBlues()
    {
        Assert.That(_day2.GetCountOfColour("blue", "3 blue"), Is.EqualTo(3));
    }
    
    [Test]
    public void ShouldGetNumberOfGreensWhenTwoDigits()
    {
        Assert.That(_day2.GetCountOfColour("green", "13 green"), Is.EqualTo(13));
    }
    
    [Test]
    public void ShouldReturn0IfNoneOfColour()
    {
        Assert.That(_day2.GetCountOfColour("red", "3 blue"), Is.EqualTo(0));
    }

    [Test]
    public void ShouldSumAllPossibleGames()
    {
        Assert.That(_day2.Part1(), Is.EqualTo(8));
    }
    
    [Test]
    public void ShouldSumAllPossibleGamesWithPuzzleInput()
    {
        var input = Constants.BasePath + "day2_actual.txt";
        _day2 = new Day2(input);
        _day2.MaxPossible = new Draw(12, 13, 14);
        
        Assert.That(_day2.Part1(), Is.EqualTo(2528));
    }

    #endregion

    #region Part2

    [Test]
    public void ShouldGetPowerOfCubesInGame()
    {
        Game game = _day2.ReadGameFromString("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");
        Assert.That(_day2.GetPowerOfCubesInGame(game), Is.EqualTo(48));
        
        Game game2 = _day2.ReadGameFromString("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue");
        Assert.That(_day2.GetPowerOfCubesInGame(game2), Is.EqualTo(12));   
        
        Game game3 = _day2.ReadGameFromString("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red");
        Assert.That(_day2.GetPowerOfCubesInGame(game3), Is.EqualTo(1560));     
        
        Game game4 = _day2.ReadGameFromString("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red");
        Assert.That(_day2.GetPowerOfCubesInGame(game4), Is.EqualTo(630));  
        
        Game game5 = _day2.ReadGameFromString("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green");
        Assert.That(_day2.GetPowerOfCubesInGame(game5), Is.EqualTo(36));
    }
    
    [Test]
    public void ShouldFindPowerOfCubes()
    {
        Assert.That(_day2.Part2(), Is.EqualTo(2286));
    }
    
    [Test]
    public void ShouldFindPowerOfCubesFromPuzzleInput()
    {
        var input = Constants.BasePath + "day2_actual.txt";
        _day2 = new Day2(input);
        
        Assert.That(_day2.Part2(), Is.EqualTo(67363));
    }
    #endregion
}