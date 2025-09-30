using System.Text;
using Hash.Interfaces;

namespace Hash.Hashers;

public class AIHasher : IHasher
{
    public string Hash(string input)
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        byte[] bytes = Encoding.UTF8.GetBytes(input);

        // We'll generate 4 different 64-bit segments and combine them into a 256-bit hash (64 hex chars)
        ulong[] parts = new ulong[4];
        ulong seed = 0xCBF29CE484222325; // 64-bit FNV offset basis

        for (int round = 0; round < parts.Length; round++)
        {
            ulong hash = seed ^ (ulong)round * 0x9E3779B97F4A7C15UL; // change seed per round

            foreach (byte b in bytes)
            {
                // XOR, multiply, rotate, and mix bits
                hash ^= b;
                hash *= 0x100000001B3;
                hash = (hash << 13) | (hash >> 51); // rotate left 13 bits
            }

            // Final avalanche for extra diffusion
            hash ^= (hash >> 33);
            hash *= 0xff51afd7ed558ccdUL;
            hash ^= (hash >> 33);
            hash *= 0xc4ceb9fe1a85ec53UL;
            hash ^= (hash >> 33);

            parts[round] = hash;
        }

        // Combine all parts into one 64-char hex string (16 hex chars per part × 4 parts = 64)
        var sb = new StringBuilder(64);
        foreach (ulong p in parts)
        {
            sb.Append(p.ToString("X16")); // 16 hex chars per 64-bit block
        }

        return sb.ToString();
    }
}
