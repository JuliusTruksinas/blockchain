namespace Hash.Helpers
{
    public static class FileGenerator
    {
        public static void GenerateFileWithRandomAsciiCharacters(string filePath, int length)
        {
            if (length < 1)
                throw new ArgumentException($"{nameof(length)} must be >= 1.");

            GenerateFile(filePath, TextGenerator.GenerateRandomAsciiLetters(length));
        }

        public static void GenerateFilesWithOneDifferentCharacter(string folderPath, int numberOfFiles, int length)
        {
            if (numberOfFiles > TextGenerator.AsciiLetters.Length)
                throw new ArgumentException($"Max {nameof(numberOfFiles)} is {TextGenerator.AsciiLetters.Length}.");

            List<char> unusedChars = [.. TextGenerator.AsciiLetters];

            int firstPartLength = (length - 1) / 2;
            int secondPartLength = length - firstPartLength;

            string firstPart = TextGenerator.GenerateRandomAsciiLetters(firstPartLength);
            string secondPart = TextGenerator.GenerateRandomAsciiLetters(secondPartLength);

            for (int i = 0; i < numberOfFiles; i++)
            {
                int last = unusedChars.Count - 1;
                char c = unusedChars[last];
                unusedChars.RemoveAt(last);

                string fileName = $"{i+1}.txt";

                GenerateFile(Path.Combine(folderPath, fileName), firstPart + c + secondPart);
            }
        }

        public static void GenerateFileWithStringPairs(string filePath, int stringLength, int pairCount)
        {
            using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            using var writer = new StreamWriter(stream);

            for (int i = 0; i < pairCount; i++)
            {
                string firstPart = TextGenerator.GenerateRandomAsciiLetters(stringLength);
                string secondPart = TextGenerator.GenerateRandomAsciiLetters(stringLength);

                writer.WriteLine($"{firstPart} {secondPart}");
            }
        }

        public static void GenerateFileWithStringPairsOneDifferentChar(string filePath, int stringLength, int pairCount)
        {
            using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            using var writer = new StreamWriter(stream);

            for (int i = 0; i < pairCount; i++)
            {
                string randomString = TextGenerator.GenerateRandomAsciiLetters(stringLength - 1);
                string firstPart =  randomString + "a";
                string secondPart = randomString + "b";

                writer.WriteLine($"{firstPart} {secondPart}");
            }
        }

        public static void GenerateFileWithOneCharacter(string filePath, char character)
            => GenerateFile(filePath, character);

        public static void GenerateEmptyFile(string filePath)
            => GenerateFile(filePath, string.Empty);
        private static void GenerateFile(string filePath, char content)
            => GenerateFile(filePath, content.ToString());

        private static void GenerateFile(string filePath, string content)
            => File.WriteAllText(filePath, content);
    }
}
