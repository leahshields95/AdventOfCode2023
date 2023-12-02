namespace AdventOfCode2023.Day2;

public enum Colour
{
    Red,
    Green,
    Blue
}

public static class ColourHelper
{
    public static Array GetAllColours()
    {
        return Enum.GetValues(typeof(Colour));
    }
}