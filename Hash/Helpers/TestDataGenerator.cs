using Hash.Constants;

namespace Hash.Helpers
{
    public static class TestDataGenerator
    {
        public static void GenerateTestData(string folderPath)
        {
            GenerateOutputSizeTestData(folderPath);
            GenerateDeterminismTestData(folderPath);
            GenerateEffectivenessTestData(folderPath);
            GenerateCollisionSearchTestData(folderPath);
            GenerateAvalanceEffectTestData(folderPath);

            Console.WriteLine(string.Format(MessageConstants.TestDataGenerated, folderPath));
        }

        private static void GenerateOutputSizeTestData(string folderPath)
        {
            string outputSizeTestFolderPath = Path.Combine(folderPath, DirectoryConstants.OutputSizeTestData);
            Directory.CreateDirectory(outputSizeTestFolderPath);

            GenerateFilesWithOneChar(outputSizeTestFolderPath, chars: ['a', 'b', 'c', 'd', 'e']);
            GenerateFilesWithRandomChars(outputSizeTestFolderPath, numberOfFiles: 5, length: 2000);
            GenerateEmptyFiles(outputSizeTestFolderPath, numberOfFiles: 5);
        }

        private static void GenerateDeterminismTestData(string folderPath)
        {
            string determinismTestFolderPath = Path.Combine(folderPath, DirectoryConstants.DeterminismTestData);
            Directory.CreateDirectory(determinismTestFolderPath);

            GenerateFilesWithOneChar(determinismTestFolderPath, chars: ['a', 'b', 'c', 'd', 'e']);
            GenerateFilesWithRandomChars(determinismTestFolderPath, numberOfFiles: 5, length: 2000);
            GenerateEmptyFiles(determinismTestFolderPath, numberOfFiles: 5);
        }

        private static void GenerateCollisionSearchTestData(string folderPath)
        {
            string collisionSearchTestFolderPath = Path.Combine(folderPath, DirectoryConstants.CollisionSearchTestData);
            Directory.CreateDirectory(collisionSearchTestFolderPath);

            GenerateFilesWithStringPairs(collisionSearchTestFolderPath, stringLengths: [10, 100, 500, 1_000], 100_000);
        }
        
        private static void GenerateAvalanceEffectTestData(string folderPath)
        {
            string avalancheEffectTestDatafilePath = Path.Combine(folderPath, FileConstants.Input.AvalancheEffectTestData);
            GenerateFileWithStringPairsOneDifferentChar(avalancheEffectTestDatafilePath, 500, 100_000);
        }

        private static void GenerateEffectivenessTestData(string folderPath)
        {
            string filePath = Path.Join(folderPath, FileConstants.Input.EffectivenessTestData);

            using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            using var writer = new StreamWriter(stream);

            for (int i = 0; i < 10_0000; i++)
            {
                string line = TextGenerator.GenerateRandomAsciiLetters(50);

                writer.WriteLine(line);
            }

        }

        private static void GenerateFilesWithOneChar(string folderPath, char[] chars)
        {
            for (int i = 0; i < chars.Length; i++)
                FileGenerator.GenerateFileWithOneCharacter(Path.Join(folderPath, $"file-with-one-char-{i+1}.txt"), chars[i]);
        }

        private static void GenerateFilesWithRandomChars(string folderPath, int numberOfFiles, int length)
        {
            for (int i = 0; i < numberOfFiles; i++)
                FileGenerator.GenerateFileWithRandomAsciiCharacters(Path.Join(folderPath, $"file-with-random-chars-{i + 1}.txt"), length);
        }

        private static void GenerateFilesWithStringPairs(string folderPath, int[] stringLengths, int pairCount)
        {
            for (int i = 0; i < stringLengths.Length; i++)
                FileGenerator.GenerateFileWithStringPairs(Path.Join(folderPath, $"file-with-string-pairs-length-{stringLengths[i]}.txt"), stringLengths[i], pairCount);
        }

        private static void GenerateFileWithStringPairsOneDifferentChar(string filePath, int stringLength, int pairCount)
            => FileGenerator.GenerateFileWithStringPairsOneDifferentChar(filePath, stringLength, pairCount);

        private static void GenerateEmptyFiles(string folderPath, int numberOfFiles)
        {
            for (int i = 0; i < numberOfFiles; i++)
                FileGenerator.GenerateEmptyFile(Path.Join(folderPath, $"empty-file-{i+1}.txt"));
        }
    }
}
