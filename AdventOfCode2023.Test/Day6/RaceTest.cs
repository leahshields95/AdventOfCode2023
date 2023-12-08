using AdventOfCode2023.Day6;

namespace AdventOfCode2023.Test.Day6;

public class RaceTest
{
    [Test]
    public void ShouldReturn4WaysToWin()
    {
        Race race = new Race(7, 9);

        Assert.That(race.GetNumberOfWaysToWin(), Is.EqualTo(4));
    }
}