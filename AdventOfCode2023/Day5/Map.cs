namespace AdventOfCode2023.Day5;

public class Map
{
    public Dictionary<long, long> MappedIds = new();

    public void Add(long sourceId, long destinationId)
    {
        MappedIds.Add(sourceId, destinationId);
    }

    public long GetDestinationIdFromSourceId(long sourceId)
    {
        if (!MappedIds.ContainsValue(sourceId))
        {
            return sourceId;
        }
        return MappedIds.GetValueOrDefault(sourceId);
    }
}