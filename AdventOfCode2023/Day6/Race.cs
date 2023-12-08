namespace AdventOfCode2023.Day6;

public class Race(long raceLength, long raceRecord)
{
    public long GetNumberOfWaysToWin()
    {
        Boat boat = new Boat();

        long min = 0;
        long max = 0;

        for (long i = 1; i < raceLength; i++)
        {
            if (boat.GetDistanceTravelled(i, raceLength) > raceRecord)
            {
               min = i;
               break;
            }
        }
        for (long i = raceLength -1; i > min; i--)
        {
            if (boat.GetDistanceTravelled(i, raceLength) > raceRecord)
            {
                max = i;
                break;
            }
        }

        return max - min + 1;
    }

}