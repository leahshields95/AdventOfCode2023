namespace AdventOfCode2023.Day5;

public class Map
{
    private List<long> _sourceIds = new();
    private List<long> _destinationIds = new();
    private List<long> _numbers = new();

    public void Add(long sourceId, long destinationId, long number)
    {
        _sourceIds.Add(sourceId);
        _destinationIds.Add(destinationId);
        _numbers.Add(number);
    }

    public long GetDestinationIdFromSourceId(long sourceId)
    {
        // Don't bother with loops if there's no chance it's in the map
        if (sourceId >= _sourceIds.Min() && sourceId <= _sourceIds.Max() + _numbers.Max())
        {
            // Calculate from values
            for (int entry = 0; entry < _sourceIds.Count; entry++)
            {
                long currentSourceId = _sourceIds[entry];
                long currentNumber = _numbers[entry];

                if (sourceId >= currentSourceId && sourceId <= currentSourceId + currentNumber)
                {
                    // Is in entry, calculate destination
                    for (long i = currentSourceId; i <= currentSourceId + currentNumber; i++)
                    {
                        if (sourceId == i)
                        {
                            return _destinationIds[entry] + (i - currentSourceId);
                        }
                    }
                }
            }
        }

        return sourceId;
    }
}