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
        boat.HoldButton(0);
        
        Assert.That(boat.GetDistanceTravelled(7), Is.EqualTo(0));
    }
    
    [Test]
    public void BoatShouldMoveIfButtonHeld()
    {
        boat.HoldButton(1);
        
        Assert.That(boat.GetDistanceTravelled(7), Is.EqualTo(6));
        
        boat.HoldButton(2);
        Assert.That(boat.GetDistanceTravelled(7), Is.EqualTo(10));
    }
    
    [Test]
    public void BoatShouldNotMoveIfButtonHeldTooLong()
    {
        boat.HoldButton(8);
        
        Assert.That(boat.GetDistanceTravelled(7), Is.EqualTo(0));
    }
}