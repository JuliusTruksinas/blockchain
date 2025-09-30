using Hash.Constants;

namespace Hash.Helpers
{
    public static class TestDataGenerator
    {
        public static void GenerateTestData(string folderPath)
        {
            GenerateFilesWithOneChar(folderPath);
            GenerateFilesWithRandomChars(folderPath, length: 2000);
            GenerateFilesWithOneDifferentChar(folderPath, numberOfFiles: 5, length: 2000);
            GenerateEmptyFiles(folderPath, numberOfFiles: 5);
            GenerateFilesWithStringPairs(folderPath, stringLengths: [10, 100, 500, 1000 ], 100_000);

            Console.WriteLine(string.Format(MessageConstants.TestDataGenerated, folderPath));
        }

        private static void GenerateFilesWithOneChar(string folderPath)
        {
            string newFolderPath = Path.Combine(folderPath, "files-with-single-character");
            Directory.CreateDirectory(newFolderPath);
            string[] chars = ["a", "z", "e", "g"];

            for (int i = 0; i < chars.Length; i++)
                FileGenerator.GenerateFileWithOneCharacter(GenerateNewFilePath(newFolderPath, i + 1), chars[i]);
        }

        private static void GenerateFilesWithRandomChars(string folderPath, int length)
        {
            string newFolderPath = Path.Combine(folderPath, $"files-with-{length}-random-characters");
            Directory.CreateDirectory(newFolderPath);

            for (int i = 0; i < 5; i++)
                FileGenerator.GenerateFileWithRandomAsciiCharacters(GenerateNewFilePath(newFolderPath, i + 1), length);
        }

        private static void GenerateFilesWithOneDifferentChar(string folderPath, int numberOfFiles, int length)
        {
            string newFolderPath = Path.Combine(folderPath, $"files-with-random-characters-one-different");
            Directory.CreateDirectory(newFolderPath);

            FileGenerator.GenerateFilesWithOneDifferentCharacter(newFolderPath, numberOfFiles, length);
        }

        private static void GenerateEmptyFiles(string folderPath, int numberOfFiles)
        {
            string newFolderPath = Path.Combine(folderPath, $"empty-files");
            Directory.CreateDirectory(newFolderPath);

            for (int i = 1; i <= numberOfFiles; i++)
                FileGenerator.GenerateEmptyFile(GenerateNewFilePath(newFolderPath, i));
        }

        private static void GenerateFilesWithStringPairs(string folderPath, int[] stringLengths, int pairCount)
        {
            string newFolderPath = Path.Combine(folderPath, $"files-with-{pairCount}-string-pairs");
            Directory.CreateDirectory(newFolderPath);

            for (int i = 0; i < stringLengths.Length; i++)
                FileGenerator.GenerateFileWithStringPairs(GenerateNewFilePath(folderPath, $"string-lengths-{stringLengths[i]}"), stringLengths[i], pairCount);
        }

        private static string GenerateNewFilePath(string folderPath, int fileCounter)
            => Path.Combine(folderPath, $"{fileCounter}.txt");

        private static string GenerateNewFilePath(string folderPath, string fileName)
            => Path.Combine(folderPath, $"{fileName}.txt");
    }
}
