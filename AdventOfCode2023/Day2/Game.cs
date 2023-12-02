namespace AdventOfCode2023.Day2;

public class Game(int id, params Draw[] draws)
{
    public int Id { get; } = id;
    public Draw[] Draws { get; } = draws;
}