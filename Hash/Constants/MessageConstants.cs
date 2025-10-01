namespace Hash.Constants
{
    public static class MessageConstants
    {
        public const string TestDataGenerated = "successfully generated the test data in folder: {0}";

        public static class Prompts
        {
            public const string Algorithm = "Enter the algorithm you would like to use (possible options - {0}):";
            public const string Content = "Enter text you would like to hash:";
        }

        public static class Errors
        {
            public const string GeneralCLIArgumentsError = """
                    Error: missing or invalid arguments.

                    The CLI arguments that must be specified: <hash> <file_path>.
                    <hash> - "Custom", "AI", "sha256".
                    <file_path> - the path to a .txt file
                    """;

            public const string FileDoesNotExist = "File does not exist in the specified path: \"{0}\".";

            public const string FolderDoesNotExist = "Folder does not exist in the specified path: \"{0}\".";

            public const string UnsupportedAlgorithm = "Unsupported algorithm! Supported algorithms: {0}.";

            public const string UnsupportedFileExtention = "Only .txt files are supported.";
        }
    }
}
