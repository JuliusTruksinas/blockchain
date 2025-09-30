namespace Hash.Constants {
    public static class MessageConstants {
        public const string GeneralCLIArgumentsError = """
                Error: missing or invalid arguments.

                The CLI arguments that must be specified: <hash> <file_path>.
                <hash> - "Custom" or "AI".
                <file_path> - the path to a .txt file
                """;

        public const string FileDoesNotExist = "File does not exist in the specified path: \"{0}\".";

        public const string UnsupportedAlgorithm = "Unsupported algorithm! Supported algorithms: {0}.";

        public const string UnsupportedFileExtention = "Only .txt files are supported.";
    }
}
