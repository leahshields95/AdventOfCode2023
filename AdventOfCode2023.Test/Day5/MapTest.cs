using AdventOfCode2023.Day5;

namespace AdventOfCode2023.Test.Day5;

public class MapTest
{
    [Test]
    public void ShouldAddIdsToDictionary()
    {
        Map map = new Map();
        map.Add(2,3, 2);
        
        Assert.That(map.GetDestinationIdFromSourceId(2), Is.EqualTo(3));
        Assert.That(map.GetDestinationIdFromSourceId(4), Is.EqualTo(5));
    }

}