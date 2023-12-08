using AdventOfCode2023.Day6;

namespace AdventOfCode2023.Test.Day6;

public class BoatTest
{
    private Boat boat;

    [SetUp]
    public void SetUp()
    {
        boat = new Boat();
    }

    [Test]
    public void BoatShouldNotMoveIfButtonNotHeld()
    {
        Assert.That(boat.GetDistanceTravelled(0, 7), Is.EqualTo(0));
    }
    
    [Test]
    public void BoatShouldMoveIfButtonHeld()
    {
        Assert.That(boat.GetDistanceTravelled(1,7), Is.EqualTo(6));
        Assert.That(boat.GetDistanceTravelled(2,7), Is.EqualTo(10));
    }
    
    [Test]
    public void BoatShouldNotMoveIfButtonHeldTooLong()
    {
        Assert.That(boat.GetDistanceTravelled(8,7), Is.EqualTo(0));
    }
}