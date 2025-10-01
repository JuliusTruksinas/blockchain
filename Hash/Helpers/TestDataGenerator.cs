using Hash.Constants;

namespace Hash.Helpers
{
    public static class TestDataGenerator
    {
        public static void GenerateTestData(string folderPath)
        {
            // Output size test data
            string outputSizeTestFolder = Path.Combine(folderPath, DirectoryConstants.OutputSizeTestData);
            GenerateFilesWithOneChar(outputSizeTestFolder, chars: ['a', 'b', 'c', 'd', 'e']);
            GenerateFilesWithRandomChars(outputSizeTestFolder, numberOfFiles: 5, length: 2000);
            
            // Determinism test data
            string determinismTestFolder = Path.Combine(folderPath, DirectoryConstants.DeterminismTestData);
            GenerateFilesWithOneChar(determinismTestFolder, chars: ['a', 'b', 'c', 'd', 'e']);
            GenerateFilesWithRandomChars(determinismTestFolder, numberOfFiles: 5, length: 2000);

            // Effectiveness test data
            // TODO: copy the konstitucija.txt file to the test data directory

            // Collision search test data
            string collisionSearchTestFolder = Path.Combine(folderPath, DirectoryConstants.CollisionSearchTestData);
            GenerateFilesWithStringPairs(collisionSearchTestFolder, stringLengths: [ 10, 100, 500, 1_000 ], 100_000);

            // Avalanche effect test data
            string avalancheEffectTestDatafilePath = Path.Combine(folderPath, FileConstants.AvalancheEffectTestData);
            GenerateFileWithStringPairsOneDifferentChar(avalancheEffectTestDatafilePath, 500, 100_000);

            Console.WriteLine(string.Format(MessageConstants.TestDataGenerated, folderPath));
        }

        private static void GenerateFilesWithOneChar(string folderPath, char[] chars)
        {
            for (int i = 0; i < chars.Length; i++)
                FileGenerator.GenerateFileWithOneCharacter(GenerateNewFilePath(folderPath, i + 1), chars[i]);
        }

        private static void GenerateFilesWithRandomChars(string folderPath, int numberOfFiles, int length)
        {
            for (int i = 0; i < numberOfFiles; i++)
                FileGenerator.GenerateFileWithRandomAsciiCharacters(GenerateNewFilePath(folderPath, i + 1), length);
        }

        private static void GenerateFilesWithOneDifferentChar(string folderPath, int numberOfFiles, int length)
            => FileGenerator.GenerateFilesWithOneDifferentCharacter(folderPath, numberOfFiles, length);


        private static void GenerateEmptyFiles(string folderPath, int numberOfFiles)
        {
            for (int i = 1; i <= numberOfFiles; i++)
                FileGenerator.GenerateEmptyFile(GenerateNewFilePath(folderPath, i));
        }

        private static void GenerateFilesWithStringPairs(string folderPath, int[] stringLengths, int pairCount)
        {
            for (int i = 0; i < stringLengths.Length; i++)
                FileGenerator.GenerateFileWithStringPairs(GenerateNewFilePath(folderPath, i+1), stringLengths[i], pairCount);
        }

        private static void GenerateFileWithStringPairsOneDifferentChar(string filePath, int stringLength, int pairCount)
            => FileGenerator.GenerateFileWithStringPairsOneDifferentChar(filePath, stringLength, pairCount);

        private static string GenerateNewFilePath(string folderPath, int fileCounter)
            => Path.Combine(folderPath, $"{fileCounter}.txt");
    }
}
