using Hash.Constants;
using Hash.Enums;
using Hash.Hashers;
using Hash.Helpers;
using Hash.InputProviders;
using Hash.Interfaces;
using Hash.Models;

namespace Blockchain;

public class Program
{
    static int Main(string[] args)
    {
        if(args.Length == 2 && args[0] == "generateTestData" && Directory.Exists(args[1]))
        {
            TestDataGenerator.GenerateTestData(args[1]);
            return 0;
        }

        if(args.Length == 4 && args[0] == "generateTestsResults")
        {
            if(!Enum.TryParse(args[1], ignoreCase: true, out HashAlgorithm hashAlgorithm))
            {
                Console.WriteLine(string.Format(MessageConstants.Errors.UnsupportedAlgorithm, string.Join(", ", Enum.GetNames<HashAlgorithm>())));
                return 1;
            }

            if(!Directory.Exists(args[2]))
            {
                Console.WriteLine(string.Format(MessageConstants.Errors.FolderDoesNotExist, args[2]));
                return 1;
            }

            if (!Directory.Exists(args[3]))
            {
                Console.WriteLine(string.Format(MessageConstants.Errors.FolderDoesNotExist, args[3]));
                return 1;
            }

            HasherTestResultsGenerator.GenerateTestResults(GetHasher(hashAlgorithm), args[2], args[3]);
            return 0;
        }

        IHashInputProvider inputProvider = GetInputProvider(args);
        if (!inputProvider.TryGetInput(out HashInput? input, out string? errorMessage))
        {
            Console.WriteLine(errorMessage);
            return 1;
        }

        IHasher hasher = GetHasher(input!.HashAlgorithm);
        string hashedContent = hasher.Hash(input.Content);

        Console.WriteLine($"Hashed content: {hashedContent}");

        return 0;
    }

    private static IHashInputProvider GetInputProvider(string[] args)
    {
        if (args.Length != 0)
            return new CommandLineInputProvider(args);

        return new ConsoleInputProvider();
    }

    private static IHasher GetHasher(HashAlgorithm hashAlgorithm)
    {
        if (hashAlgorithm == HashAlgorithm.Custom)
            return new CustomHasher();

        if(hashAlgorithm == HashAlgorithm.AI)
            return new AIHasher();

        return new Sha256Hasher();
    }
}