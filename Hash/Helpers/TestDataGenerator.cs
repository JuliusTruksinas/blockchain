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

            Console.WriteLine(string.Format(MessageConstants.TestDataGenerated, folderPath));
        }

        private static void GenerateFilesWithOneChar(string folderPath)
        {
            string newFolderPath = Path.Combine(folderPath, "files-with-single-character");
            Directory.CreateDirectory(newFolderPath);

            FileGenerator.GenerateFileWithOneCharacter(GenerateNewFilePath(newFolderPath), "a");
            FileGenerator.GenerateFileWithOneCharacter(GenerateNewFilePath(newFolderPath), "z");
            FileGenerator.GenerateFileWithOneCharacter(GenerateNewFilePath(newFolderPath), "e");
            FileGenerator.GenerateFileWithOneCharacter(GenerateNewFilePath(newFolderPath), "g");
        }

        private static void GenerateFilesWithRandomChars(string folderPath, int length)
        {
            string newFolderPath = Path.Combine(folderPath, $"files-with-{length}-random-characters");
            Directory.CreateDirectory(newFolderPath);

            FileGenerator.GenerateFileWithRandomAsciiCharacters(GenerateNewFilePath(newFolderPath), length);
            FileGenerator.GenerateFileWithRandomAsciiCharacters(GenerateNewFilePath(newFolderPath), length);
            FileGenerator.GenerateFileWithRandomAsciiCharacters(GenerateNewFilePath(newFolderPath), length);
            FileGenerator.GenerateFileWithRandomAsciiCharacters(GenerateNewFilePath(newFolderPath), length);
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

            for (int i = 0; i < numberOfFiles; i++)
            {
                FileGenerator.GenerateEmptyFile(GenerateNewFilePath(folderPath));
            }
        }

        private static string GenerateNewFilePath(string folderPath)
            => Path.Combine(folderPath, $"{Guid.NewGuid().ToString("N")}.txt");
    }
}
