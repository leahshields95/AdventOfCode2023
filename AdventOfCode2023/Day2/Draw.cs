namespace AdventOfCode2023.Day2;

/*
 * A collection of cubes that the elf has drawn. Red, green and blue
 */
public class Draw(ColouredCubes[] colouredCubes)
{
    public readonly ColouredCubes[] AllCubesDrawn = colouredCubes;

    public int GetNumberCubesOfColour(Colour colour)
    {
        int totalNumber = 0;
        foreach (var colouredCubes in AllCubesDrawn)
        {
            if (colouredCubes.Colour == colour)
            {
                totalNumber += colouredCubes.Count;
            }
        }

        return totalNumber;
    }
}