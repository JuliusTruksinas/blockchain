namespace Hash.Helpers
{
    public static class TextGenerator
    {
        public const string AsciiLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public static char GenerateRandomAsciiLetter()
            => AsciiLetters[Random.Shared.Next(AsciiLetters.Length)];

        public static string GenerateRandomAsciiLetters(int length)
        {
            var chars = new char[length];

            for (int i = 0; i < length; i++)
                chars[i] = GenerateRandomAsciiLetter();

            return new string(chars);
        }
    }
}
