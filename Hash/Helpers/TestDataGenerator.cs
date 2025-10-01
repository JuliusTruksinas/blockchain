using Hash.Constants;

namespace Hash.Helpers
{
    public static class TestDataGenerator
    {
        public static void GenerateTestData(string folderPath)
        {
            GenerateFilesWithOneChar(folderPath, chars: ['a', 'b', 'c', 'd', 'e']);
            GenerateFilesWithRandomChars(folderPath, numberOfFiles: 5, length: 2000);
            GenerateFilesWithOneDifferentChar(folderPath, numberOfFiles: 5, length: 2000);
            GenerateEmptyFiles(folderPath, numberOfFiles: 5);
            GenerateFilesWithStringPairs(folderPath, stringLengths: [ 10, 100, 500, 1_000 ], 100_000);
            GenerateFileWithStringPairsOneDifferentChar(folderPath, 500, 100_000);

            Console.WriteLine(string.Format(MessageConstants.TestDataGenerated, folderPath));
        }

        private static void GenerateFilesWithOneChar(string folderPath, char[] chars)
        {
            string newFolderPath = Path.Combine(folderPath, DirectoryConstants.FilesWithSingleCharacter);
            Directory.CreateDirectory(newFolderPath);

            for (int i = 0; i < chars.Length; i++)
                FileGenerator.GenerateFileWithOneCharacter(GenerateNewFilePath(newFolderPath, i + 1), chars[i]);
        }

        private static void GenerateFilesWithRandomChars(string folderPath, int numberOfFiles, int length)
        {
            string newFolderPath = Path.Combine(folderPath, DirectoryConstants.FilesWithRandomCharaters);
            Directory.CreateDirectory(newFolderPath);

            for (int i = 0; i < numberOfFiles; i++)
                FileGenerator.GenerateFileWithRandomAsciiCharacters(GenerateNewFilePath(newFolderPath, i + 1), length);
        }

        private static void GenerateFilesWithOneDifferentChar(string folderPath, int numberOfFiles, int length)
        {
            string newFolderPath = Path.Combine(folderPath, DirectoryConstants.FilesWithRandomCharatersOneDifferent);
            Directory.CreateDirectory(newFolderPath);

            FileGenerator.GenerateFilesWithOneDifferentCharacter(newFolderPath, numberOfFiles, length);
        }

        private static void GenerateEmptyFiles(string folderPath, int numberOfFiles)
        {
            string newFolderPath = Path.Combine(folderPath, DirectoryConstants.EmptyFiles);
            Directory.CreateDirectory(newFolderPath);

            for (int i = 1; i <= numberOfFiles; i++)
                FileGenerator.GenerateEmptyFile(GenerateNewFilePath(newFolderPath, i));
        }

        private static void GenerateFilesWithStringPairs(string folderPath, int[] stringLengths, int pairCount)
        {
            string newFolderPath = Path.Combine(folderPath, DirectoryConstants.FilesWithStringPairs);
            Directory.CreateDirectory(newFolderPath);

            for (int i = 0; i < stringLengths.Length; i++)
                FileGenerator.GenerateFileWithStringPairs(GenerateNewFilePath(newFolderPath, i+1), stringLengths[i], pairCount);
        }

        private static void GenerateFileWithStringPairsOneDifferentChar(string folderPath, int stringLength, int pairCount)
        {
            string filePath = Path.Combine(folderPath, "stringPairs1DifferentChar.txt");
            FileGenerator.GenerateFileWithStringPairsOneDifferentChar(filePath, stringLength, pairCount);
        }

        private static string GenerateNewFilePath(string folderPath, int fileCounter)
            => Path.Combine(folderPath, $"{fileCounter}.txt");

        private static string GenerateNewFilePath(string folderPath, string fileName)
            => Path.Combine(folderPath, $"{fileName}.txt");
    }
}
