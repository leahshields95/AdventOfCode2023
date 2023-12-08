namespace AdventOfCode2023.Day6;

public class Boat
{
    // mm per ms
    private long speed = 0;

    public long GetDistanceTravelled(long buttonHeldTime, long time)
    {
        speed = 0;
        speed += buttonHeldTime;

        time -= speed;

        if (time < 0) time = 0;
        return speed * time;
    }
}