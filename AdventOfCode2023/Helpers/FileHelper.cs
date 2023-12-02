using System.Text;

namespace AdventOfCode2023.Helpers;

public static class FileHelper
{
    public static void ReadFromInputFile(String input, Action<string> method)
    {
        using (var fileStream = File.OpenRead(input))
        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true))
        {
            String line;
            while ((line = streamReader.ReadLine()) != null)
            {
                method(line);
            }
        }
    }
}