namespace AdventOfCode2023.Day6;

public class Race(long raceLength, long raceRecord)
{
    public int GetNumberOfWaysToWin()
    {
        Boat boat = new Boat();
        int total = 0;

        for (int i = 1; i < raceLength; i++)
        {
            if (boat.GetDistanceTravelled(i, raceLength) > raceRecord)
            {
                total++;
            }
        }

        return total;
    }

}