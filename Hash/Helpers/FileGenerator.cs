namespace Hash.Helpers
{
    public static class FileGenerator
    {
        public static void GenerateFileWithOneCharacter(string filePath, string character)
        {
            if (string.IsNullOrEmpty(character))
                throw new ArgumentNullException($"{nameof(character)} must be provided.");

            if (character.Length != 1)
                throw new ArgumentException($"{nameof(character)} must be a single character.");

            GenerateFile(filePath, character);
        }

        public static void GenerateFileWithRandomAsciiCharacters(string filePath, int length)
        {
            if (length < 1)
                throw new ArgumentException($"{nameof(length)} must be >= 1.");

            GenerateFile(filePath, TextGenerator.GenerateRandomAsciiLetters(length));
        }

        public static void GenerateFilesWithOneDifferentCharacter(string folderPath, int numberOfFiles, int length)
        {
            if (length > TextGenerator.AsciiLetters.Length)
                throw new ArgumentException($"Max {nameof(length)} is {TextGenerator.AsciiLetters.Length}.");

            List<char> unusedChars = [.. TextGenerator.AsciiLetters];

            int firstPartLength = (length - 1) / 2;
            int secondPartLength = length - firstPartLength;

            string firstPart = TextGenerator.GenerateRandomAsciiLetters(firstPartLength);
            string secondPart = TextGenerator.GenerateRandomAsciiLetters(secondPartLength);

            for (int i = 0; i < length; i++)
            {
                int last = unusedChars.Count - 1;
                char c = unusedChars[last];
                unusedChars.RemoveAt(last);

                string fileName = $"{Guid.NewGuid().ToString("N")}.txt";

                GenerateFile(Path.Combine(folderPath, fileName), firstPart + c + secondPart);
            }
        }

        public static void GenerateEmptyFile(string filePath)
            => GenerateFile(filePath, string.Empty);

        private static void GenerateFile(string filePath, string content)
            => File.WriteAllText(filePath, content);
    }
}
