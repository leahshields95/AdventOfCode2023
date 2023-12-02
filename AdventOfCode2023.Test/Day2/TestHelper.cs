using AdventOfCode2023.Day2;

namespace AdventOfCode2023.Test.Day2;

public static class TestHelper
{
    public static ColouredCubes[] CreateADraw(int numberOfRed, int numberofGreen, int numberOfBlue)
    {
        var redCubes = new ColouredCubes(Colour.Red, numberOfRed);
        var greenCubes = new ColouredCubes(Colour.Green, numberofGreen);
        var blueCubes = new ColouredCubes(Colour.Blue, numberOfBlue);

        return new[] { redCubes, greenCubes, blueCubes };
    }
}