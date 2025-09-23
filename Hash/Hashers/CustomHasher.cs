using System.Text;
using Hash.Interfaces;

namespace Hash.Hashers;

public class CustomHasher : IHasher
{
    public string Hash(string input)
    {
        return "hashed value";
    }
}
