using Hash.Enums;
using Hash.Hashers;
using Hash.Helpers;
using Hash.InputProviders;
using Hash.Interfaces;

namespace Blockchain;

public class Program
{
    static int Main(string[] args)
    {
        FileGenerator.GenerateFileWithOneCharacter('a');
        return 0;

        //IHashInputProvider inputProvider = GetInputProvider(args);
        //if (!inputProvider.TryGetInput(out HashInput? input, out string? errorMessage))
        //{
        //    Console.WriteLine(errorMessage);
        //    return 1;
        //}

        //IHasher hasher = GetHasher(input!.HashAlgorithm);
        //string hashedContent = hasher.Hash(input.Content);

        //Console.WriteLine($"Hashed content: {hashedContent}");

        //return 0;
    }

    private static IHashInputProvider GetInputProvider(string[] args)
    {
        if (args.Length != 0)
            return new CommandLineInputProvider(args);

        return new ConsoleInputProvider();
    }

    private static IHasher GetHasher(HashAlgorithm hashAlgorithm)
    {
        return new CustomHasher();
    }
}