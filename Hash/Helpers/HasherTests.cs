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

    public List<(int linesCount, string hash, long timeInMs)> EffectivenessTest(string filePath)
    {
        List<(int, string, long)> results = [];

        int lineCount = CountLines(filePath);
        int linesToRead = 1;

        while (linesToRead <= lineCount)
        {
            (string hash, long timeInMs) = MeasureLinesHashTime(filePath, linesToRead);
            results.Add((linesToRead, hash, timeInMs));
            linesToRead *= 2;
        }

        if (lineCount != linesToRead)
        {
            (string hash, long timeInMs) = MeasureLinesHashTime(filePath, linesToRead);
            results.Add((lineCount, hash, timeInMs));
        }

        return results;
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

    public List<(string fileName, string hash, int timesRan, bool isDeterministic)> DeterminismTest(string folderPath, int timesToRun)
    {
        List<(string, string, int, bool)> results = [];
        string[] filePaths = Directory.GetFiles(folderPath);

        foreach (string filePath in filePaths)
        {
            string fileName = Path.GetFileName(filePath);
            string content = File.ReadAllText(filePath);
            string firstHash = _hasher.Hash(content);
            
            bool isDeterministic = true;

            for(int i = 0; i < timesToRun-1; i++)
            {
                string hash = _hasher.Hash(content);

                if(hash != firstHash)
                {
                    isDeterministic = false;
                    break;
                }
            }

            results.Add((fileName, firstHash, timesToRun, isDeterministic));
        }

        return results;
    }

    public List<(string fileName, int collisionCount)> CollisionSearchTest(string folderPath)
    {
        List<(string, int)> results = [];
        string[] filePaths = Directory.GetFiles(folderPath);

        foreach (string filePath in filePaths)
        {
            string fileName = Path.GetFileName(filePath);
            int collisionCount = 0;

            foreach (var line in File.ReadLines(filePath))
            {
                string[] hashPair = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstHash = _hasher.Hash(hashPair[0]);
                string secondHash = _hasher.Hash(hashPair[1]);

                if (firstHash == secondHash)
                    collisionCount++;
            }

            results.Add((fileName, collisionCount));
        }

        return results;
    }

    public List<(string level, double minMatch, double maxMatch, double avgMatch)> AvalancheEffectTest(string filePath)
    {
        double minHex = 100, maxHex = 0, sumHex = 0;
        int hexCount = 0;

        double minBits = 100, maxBits = 0, sumBits = 0;
        int bitCount = 0;

        foreach (var line in File.ReadLines(filePath))
        {
            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
                continue;

            string first = parts[0];
            string second = parts[1];

            double hexMatch = CompareByCharacters(first, second);
            sumHex += hexMatch;
            if (hexMatch < minHex) minHex = hexMatch;
            if (hexMatch > maxHex) maxHex = hexMatch;
            hexCount++;

            double bitMatch = CompareByBits(first, second);
            sumBits += bitMatch;
            if (bitMatch < minBits) minBits = bitMatch;
            if (bitMatch > maxBits) maxBits = bitMatch;
            bitCount++;
        }

        double avgHex = hexCount > 0 ? sumHex / hexCount : 0;
        double avgBits = bitCount > 0 ? sumBits / bitCount : 0;

        return [ ("Hex", minHex, maxHex, avgHex), ("Bits", minBits, maxBits, avgBits) ];
    }


    private (string hash, long timeInMs) MeasureLinesHashTime(string filePath, int lineCount)
    {
        using var reader = new StreamReader(filePath);

        var sb = new StringBuilder();

        for (int i = 0; i < lineCount && !reader.EndOfStream; i++)
        {
            sb.Append(reader.ReadLine());
        }

        string linesContent = sb.ToString();

        var stopwatch = Stopwatch.StartNew();

        string hash = _hasher.Hash(linesContent);
        
        stopwatch.Stop();

        return (hash, stopwatch.ElapsedMilliseconds);
    }

    private static int CountLines(string filePath)
    {
        int lineCount = 0;
        using var reader = new StreamReader(filePath);
        
        while (reader.ReadLine() != null)
            lineCount++;
        
        return lineCount;
    }

    public static double CompareByCharacters(string s1, string s2)
    {
        int matches = 0;

        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] == s2[i])
                matches++;
        }

        return (double)matches / s1.Length * 100.0;
    }

    public static double CompareByBits(string s1, string s2)
    {
        byte[] b1 = Encoding.Unicode.GetBytes(s1);
        byte[] b2 = Encoding.Unicode.GetBytes(s2);

        int matches = 0;
        int totalBits = b1.Length * 8;

        for (int i = 0; i < b1.Length; i++)
        {
            byte byte1 = b1[i];
            byte byte2 = b2[i];

            for (int bit = 0; bit < 8; bit++)
            {
                bool bit1 = (byte1 & (1 << bit)) != 0;
                bool bit2 = (byte2 & (1 << bit)) != 0;

                if (bit1 == bit2)
                    matches++;
            }
        }

        return (double)matches / totalBits * 100.0;
    }
}