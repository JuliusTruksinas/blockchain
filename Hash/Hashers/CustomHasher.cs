using System.Text;
using Hash.Interfaces;

namespace Hash.Hashers;

public class CustomHasher : IHasher
{
    private const ulong START_CONST1 = 0x243F6A8885A308D3;
    private const ulong START_CONST2 = 0x13198A2E03707344;
    private const ulong START_CONST3 = 0xA4093822299F31D0;
    private const ulong START_CONST4 = 0x082EFA98EC4E6C89;

    public string Hash(string input)
    {
        return "hashed value";
    }
}
