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
        _day2.MaxPossible = new Draw(TestHelper.CreateADraw(12, 13, 14));
    }

    #region Part1

    [Test]
    public void ShouldReturnTrueIfGamePossible()
    {
        Draw firstDraw = new Draw(TestHelper.CreateADraw(3, 4, 6));
        Draw secondDraw = new Draw(TestHelper.CreateADraw(6, 2, 2));
        Assert.IsTrue(_day2.IsGamePossible(new Game(1, firstDraw, secondDraw)));
    }

    [Test]
    public void ShouldReturnFalseIfGameImpossible()
    {
        Draw firstDraw = new Draw(TestHelper.CreateADraw(1, 3, 6));
        Draw secondDraw = new Draw(TestHelper.CreateADraw(2, 6, 0));
        Draw thirdDraw = new Draw(TestHelper.CreateADraw(3, 15, 14));
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
        var result = _day2.GetDrawFromDrawString("1 green, 3 blue, 4 red");

        Assert.That(result.GetNumberCubesOfColour(Colour.Green), Is.EqualTo(1));
        Assert.That(result.GetNumberCubesOfColour(Colour.Red), Is.EqualTo(4));
        Assert.That(result.GetNumberCubesOfColour(Colour.Blue), Is.EqualTo(3));
    }

    [Test]
    public void ShouldGetDrawFromGameStringWhenOneValue0()
    {
        var result = _day2.GetDrawFromDrawString("1 green, 0 blue, 4 red");

        Assert.That(result.GetNumberCubesOfColour(Colour.Green), Is.EqualTo(1));
        Assert.That(result.GetNumberCubesOfColour(Colour.Red), Is.EqualTo(4));
        Assert.That(result.GetNumberCubesOfColour(Colour.Blue), Is.EqualTo(0));
    }

    [Test]
    public void ShouldGetAllDrawsFromGameString()
    {
        var result =
            _day2.GetDrawsFromGameString("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red");

        Assert.That(result.Length, Is.EqualTo(3));

        Assert.That(result[0].GetNumberCubesOfColour(Colour.Green), Is.EqualTo(1));
        Assert.That(result[0].GetNumberCubesOfColour(Colour.Red), Is.EqualTo(3));
        Assert.That(result[0].GetNumberCubesOfColour(Colour.Blue), Is.EqualTo(6));

        Assert.That(result[1].GetNumberCubesOfColour(Colour.Green), Is.EqualTo(3));
        Assert.That(result[1].GetNumberCubesOfColour(Colour.Red), Is.EqualTo(6));
        Assert.That(result[1].GetNumberCubesOfColour(Colour.Blue), Is.EqualTo(0));

        Assert.That(result[2].GetNumberCubesOfColour(Colour.Green), Is.EqualTo(3));
        Assert.That(result[2].GetNumberCubesOfColour(Colour.Red), Is.EqualTo(14));
        Assert.That(result[2].GetNumberCubesOfColour(Colour.Blue), Is.EqualTo(15));
    }

    [Test]
    public void ShouldGetNumberOfBlues()
    {
        Assert.That(_day2.GetCountOfColour(Colour.Blue, "3 blue").Count, Is.EqualTo(3));
    }

    [Test]
    public void ShouldGetNumberOfGreensWhenTwoDigits()
    {
        Assert.That(_day2.GetCountOfColour(Colour.Green, "13 green").Count, Is.EqualTo(13));
    }

    [Test]
    public void ShouldReturn0IfNoneOfColour()
    {
        Assert.That(_day2.GetCountOfColour(Colour.Red, "3 blue").Count, Is.EqualTo(0));
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
        _day2.MaxPossible = new Draw(TestHelper.CreateADraw(12, 13, 14));

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

        Game game3 =
            _day2.ReadGameFromString("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red");
        Assert.That(_day2.GetPowerOfCubesInGame(game3), Is.EqualTo(1560));

        Game game4 =
            _day2.ReadGameFromString("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red");
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