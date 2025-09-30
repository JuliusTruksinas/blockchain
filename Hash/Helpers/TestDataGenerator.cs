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
            int fileCounter = 1;

            FileGenerator.GenerateFileWithOneCharacter(GenerateNewFilePath(newFolderPath, ref fileCounter), "a");
            FileGenerator.GenerateFileWithOneCharacter(GenerateNewFilePath(newFolderPath, ref fileCounter), "z");
            FileGenerator.GenerateFileWithOneCharacter(GenerateNewFilePath(newFolderPath, ref fileCounter), "e");
            FileGenerator.GenerateFileWithOneCharacter(GenerateNewFilePath(newFolderPath, ref fileCounter), "g");
        }

        private static void GenerateFilesWithRandomChars(string folderPath, int length)
        {
            string newFolderPath = Path.Combine(folderPath, $"files-with-{length}-random-characters");
            Directory.CreateDirectory(newFolderPath);
            int fileCounter = 1;

            FileGenerator.GenerateFileWithRandomAsciiCharacters(GenerateNewFilePath(newFolderPath, ref fileCounter), length);
            FileGenerator.GenerateFileWithRandomAsciiCharacters(GenerateNewFilePath(newFolderPath, ref fileCounter), length);
            FileGenerator.GenerateFileWithRandomAsciiCharacters(GenerateNewFilePath(newFolderPath, ref fileCounter), length);
            FileGenerator.GenerateFileWithRandomAsciiCharacters(GenerateNewFilePath(newFolderPath, ref fileCounter), length);
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
            {
                FileGenerator.GenerateEmptyFile(GenerateNewFilePath(newFolderPath, ref i));
            }
        }

        private static string GenerateNewFilePath(string folderPath, ref int fileCounter)
            => Path.Combine(folderPath, $"{fileCounter}.txt");
    }
}
