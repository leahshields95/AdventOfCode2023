namespace AdventOfCode2023.Day6;

public class Race(int raceLength, int raceRecord)
{
    public int GetNumberOfWaysToWin()
    {
        Boat boat = new Boat();
        int total = 0;

        for (int i = 1; i < raceLength; i++)
        {
            boat.HoldButton(i);
            if (boat.GetDistanceTravelled(raceLength) > raceRecord)
            {
                total++;
            }
        }

        return total;
    }

}