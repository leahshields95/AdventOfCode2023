using AdventOfCode2023.Day2;

namespace AdventOfCode2023.Test.Day2;

public class DrawTest
{
    private Draw _draw;

    [Test]
    public void ShouldReturnCorrectNumberOfCubes()
    {
        _draw = new Draw(TestHelper.CreateADraw(3, 4, 6));

        Assert.That(_draw.GetNumberCubesOfColour(Colour.Green), Is.EqualTo(4));
        Assert.That(_draw.GetNumberCubesOfColour(Colour.Red), Is.EqualTo(3));
        Assert.That(_draw.GetNumberCubesOfColour(Colour.Blue), Is.EqualTo(6));
    }
    
}