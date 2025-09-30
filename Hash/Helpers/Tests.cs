using System.Diagnostics;
using System.Text;
using Hash.Interfaces;

namespace Hash.Helpers;

public class Tests
{
    private readonly IHasher _hasher;
    public Tests(IHasher hasher)
    {
        _hasher = hasher;
    }

    public Dictionary<int, long> MeasureIncreasingLinesHashTime(string filePath)
    {
        int lineCount = CountLines(filePath);
        Math.Floor(Math.Log2(lineCount));
    }

    public long MeasureLinesHashTime(string filePath, int lineCount)
    {
        using var reader = new StreamReader(filePath);

        var sb = new StringBuilder();

        for (int i = 0; i < lineCount && !reader.EndOfStream; i++)
        {
            sb.Append(reader.ReadLine());
        }

        var stopwatch = Stopwatch.StartNew();

        _hasher.Hash(sb.ToString());

        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    static int CountLines(string filePath)
    {
        int lineCount = 0;
        using var reader = new StreamReader(filePath);
        
        while (reader.ReadLine() != null)
            lineCount++;
        
        return lineCount;
    }

}