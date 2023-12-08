namespace AdventOfCode2023.Day6;

public class Boat
{
    // mm per ms
    private int speed = 0;

    public long GetDistanceTravelled(int buttonHeldTime, long time)
    {
        speed = 0;
        for (int i = 0; i < buttonHeldTime; i++)
        {
            speed ++;
            if (time > 0) time--;
        }
        return speed * time;
    }
}