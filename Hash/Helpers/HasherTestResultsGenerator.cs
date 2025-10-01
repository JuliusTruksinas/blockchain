using Hash.Constants;
using Hash.Interfaces;

namespace Hash.Helpers
{
    public static class HasherTestResultsGenerator
    {
        public static void GenerateTestResults(IHasher hasher, string inputFolderPath, string outputFolderPath)
        {
            // GenerateEffectivenessResults(hasher, inputFolderPath, outputFolderPath);
            GenerateOutputSizeResults(hasher, inputFolderPath, outputFolderPath);
            GenerateDeterminismResults(hasher, inputFolderPath, outputFolderPath);
            GenerateCollisionSearchResults(hasher, inputFolderPath, outputFolderPath);
        }

        public static void GenerateEffectivenessResults(IHasher hasher, string inputFolderPath, string outputFolderPath)
        {
            var testRunner = new HasherTests(hasher);
            var results = testRunner.EffectivenessTest(Path.Join(inputFolderPath, "konstitucija.txt"));

            string resultsFilePath = Path.Join(outputFolderPath, "effectivenessResults.md");
            File.WriteAllText(resultsFilePath, HasherTestsResultsFormatter.FormatEffectivenessResults(results));
        }

        public static void GenerateOutputSizeResults(IHasher hasher, string inputFolderPath, string outputFolderPath)
        {
            var testRunner = new HasherTests(hasher);
            var outputSizeTestDataFolderPath = Path.Join(inputFolderPath, DirectoryConstants.OutputSizeTestData);

            var results = testRunner.OutputSizeTest(outputSizeTestDataFolderPath);

            string filePath = Path.Join(outputFolderPath, "outputSizeResults.md");
            File.WriteAllText(filePath, HasherTestsResultsFormatter.FormatOutputSizeResults(results));
        }

        public static void GenerateDeterminismResults(IHasher hasher, string inputFolderPath, string outputFolderPath)
        {
            var testRunner = new HasherTests(hasher);
            var determinismTestDataFolderPath = Path.Join(inputFolderPath, DirectoryConstants.DeterminismTestData);

            var results = testRunner.DeterminismTest(determinismTestDataFolderPath, timesToRun: 5);

            string filePath = Path.Join(outputFolderPath, "determinismResults.md");
            File.WriteAllText(filePath, HasherTestsResultsFormatter.FormatDeterminismTestRetults(results));
        }

        public static void GenerateCollisionSearchResults(IHasher hasher, string inputFolderPath, string outputFolderPath)
        {
            var testRunner = new HasherTests(hasher);
            var collisionSearchTestDataFolderPath = Path.Join(inputFolderPath, DirectoryConstants.CollisionSearchTestData);

            var results = testRunner.CollisionSearchTest(collisionSearchTestDataFolderPath);

            string filePath = Path.Join(outputFolderPath, "collisionSearchResults.md");
            File.WriteAllText(filePath, HasherTestsResultsFormatter.FormatCollisionSearchTestResults(results));
        }
    }
}
