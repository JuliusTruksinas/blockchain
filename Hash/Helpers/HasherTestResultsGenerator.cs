using Hash.Interfaces;

namespace Hash.Helpers
{
    public static class HasherTestResultsGenerator
    {
        public static void GenerateEffectivenessResults(IHasher hasher, string inputFolderPath, string outputFolderPath)
        {
            var tester = new HasherTests(hasher);
            var results = tester.EffectivenessTest(Path.Join(inputFolderPath, "konstitucija.txt"));

            string resultsFilePath = Path.Join(outputFolderPath, "effectivenessResult.md");
            File.WriteAllText(resultsFilePath, HasherTestsResultsFormatter.FormatEffectivenessResults(results));
        }

        public static void GenerateOutputSizeResults(IHasher hasher, string inputFolderPath, string outputFolderPath)
        {
            var tester = new HasherTests(hasher);
            var results = tester.OutputSizeTest(inputFolderPath);

            string filePath = Path.Join(outputFolderPath, "outputSizeResult.md");
            File.WriteAllText(filePath, HasherTestsResultsFormatter.FormatOutputSizeResults(results));
        }
    }
}
