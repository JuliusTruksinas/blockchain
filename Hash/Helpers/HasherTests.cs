using System.Diagnostics;
using System.Text;
using Hash.Interfaces;

namespace Hash.Helpers;

public class HasherTests
{
    private readonly IHasher _hasher;
    public HasherTests(IHasher hasher)
    {
        _hasher = hasher;
    }

    /// <summary>
    /// Measures how much time does it take to hash 1,2,4,8..., n lines of a txt file
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns>A dicrionary where the keys are the number of lines that were hashed and the values the time it took in ms.</returns>
    public Dictionary<int, long> EffectivenessTest(string filePath)
    {
        Dictionary<int, long> linesHashTimeInMsMapping = [];

        int lineCount = CountLines(filePath);
        double timesToReadFile = Math.Floor(Math.Log2(lineCount));
        int linesToRead = 1;

        for(int i = 0; i < timesToReadFile; i++)
        {
            long timeInMs = MeasureLinesHashTime(filePath, linesToRead);
            linesHashTimeInMsMapping.Add(linesToRead, timeInMs);
            linesToRead *= 2;
        }

        if(linesToRead != lineCount)
        {
            long timeInMs = MeasureLinesHashTime(filePath, lineCount);
            linesHashTimeInMsMapping.Add(lineCount, timeInMs);
        }

        return linesHashTimeInMsMapping;
    }
    
    public List<(string fileName, string hash, int hashLength)> OutputSizeTest(string folderPath)
    {
        List<(string, string, int)> results = [];
        string[] filePaths = Directory.GetFiles(folderPath);

        foreach (string filePath in filePaths)
        {
            string fileName = Path.GetFileName(filePath);
            string content = File.ReadAllText(filePath);
            string hash = _hasher.Hash(content);

            results.Add((fileName, hash, hash.Length));
        }

        return results;
    }

    private long MeasureLinesHashTime(string filePath, int lineCount)
    {
        using var reader = new StreamReader(filePath);

        var sb = new StringBuilder();

        for (int i = 0; i < lineCount && !reader.EndOfStream; i++)
        {
            sb.Append(reader.ReadLine());
        }

        string linesContent = sb.ToString();

        var stopwatch = Stopwatch.StartNew();

        _hasher.Hash(linesContent);
        
        stopwatch.Stop();

        return stopwatch.ElapsedMilliseconds;
    }

    private static int CountLines(string filePath)
    {
        int lineCount = 0;
        using var reader = new StreamReader(filePath);
        
        while (reader.ReadLine() != null)
            lineCount++;
        
        return lineCount;
    }

}