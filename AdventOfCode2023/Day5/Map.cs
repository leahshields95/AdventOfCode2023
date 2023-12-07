namespace AdventOfCode2023.Day5;

public class Map
{
    public Dictionary<int, int> MappedIds = new();

    public void Add(int sourceId, int destinationId)
    {
        MappedIds.Add(sourceId, destinationId);
    }

    public int GetDestinationIdFromSourceId(int sourceId)
    {
        if (!MappedIds.ContainsValue(sourceId))
        {
            return sourceId;
        }
        return MappedIds.GetValueOrDefault(sourceId);
    }
}