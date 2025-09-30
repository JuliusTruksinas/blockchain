using System.Text;
using Hash.Interfaces;

namespace Hash.Hashers;

public class AIHasher : IHasher
{
    public string Hash(string input)
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        // Convert string to bytes (UTF-8)
        byte[] bytes = Encoding.UTF8.GetBytes(input);

        // Start with a non-zero seed
        uint hash = 0x811C9DC5; // FNV offset basis (just a good seed)
        const uint prime = 16777619;

        foreach (byte b in bytes)
        {
            // Mix bits: XOR, multiply by prime, and rotate bits
            hash ^= b;
            hash *= prime;
            hash = (hash << 5) | (hash >> 27); // rotate left 5 bits
        }

        // Final avalanche (extra mixing)
        hash ^= (hash >> 16);
        hash *= 0x85EBCA6B;
        hash ^= (hash >> 13);
        hash *= 0xC2B2AE35;
        hash ^= (hash >> 16);

        // Convert to hex string
        return hash.ToString("X8");
    }
}
