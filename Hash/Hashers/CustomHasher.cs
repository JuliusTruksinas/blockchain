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
        ulong state1 = START_CONST1;
        ulong state2 = START_CONST2;
        ulong state3 = START_CONST3;
        ulong state4 = START_CONST4;

        return "hashed value";
    }

    private static ulong RotateLeft(ulong x, int n)
    {
        return (x << n) | (x >> (64 - n));
    }
}
