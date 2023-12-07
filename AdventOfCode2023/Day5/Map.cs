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
        // Calculate from values
        for (int entry = 0; entry < _sourceIds.Count; entry++)
        {
            if (sourceId >= _sourceIds[entry] && sourceId <= _sourceIds[entry] + _numbers[entry])
            {
                // Is in entry, calculate destination
                for (long i = _sourceIds[entry]; i <= _sourceIds[entry] + _numbers[entry]; i++)
                {
                    if (sourceId == i)
                    {
                        return _destinationIds[entry] + (i - _sourceIds[entry]);
                    }
                }
            }
        }

        return sourceId;
    }
}