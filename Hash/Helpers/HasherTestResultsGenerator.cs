using Hash.Constants;
using Hash.Interfaces;

namespace Hash.Helpers
{
    public static class HasherTestResultsGenerator
    {
        public static void GenerateTestResults(IHasher hasher, string inputFolderPath, string outputFolderPath)
        {
            GenerateEffectivenessResults(hasher, inputFolderPath, outputFolderPath);
            GenerateOutputSizeResults(hasher, inputFolderPath, outputFolderPath);
            GenerateDeterminismResults(hasher, inputFolderPath, outputFolderPath);
            GenerateCollisionSearchResults(hasher, inputFolderPath, outputFolderPath);
            GenerateAvalancheEffectResults(hasher, inputFolderPath, outputFolderPath);

            Console.WriteLine($"Successfully generated the test results, path: {outputFolderPath}");
        }

        public static void GenerateEffectivenessResults(IHasher hasher, string inputFolderPath, string outputFolderPath)
        {
            var testRunner = new HasherTests(hasher);
            var results = testRunner.EffectivenessTest(Path.Join(inputFolderPath, FileConstants.Input.EffectivenessTestData));

            string resultsFilePath = Path.Join(outputFolderPath, FileConstants.Results.Effectiveness);
            File.WriteAllText(resultsFilePath, HasherTestsResultsFormatter.FormatEffectivenessResults(results));
        }

        public static void GenerateOutputSizeResults(IHasher hasher, string inputFolderPath, string outputFolderPath)
        {
            var testRunner = new HasherTests(hasher);
            var outputSizeTestDataFolderPath = Path.Join(inputFolderPath, DirectoryConstants.OutputSizeTestData);

            var results = testRunner.OutputSizeTest(outputSizeTestDataFolderPath);

            string filePath = Path.Join(outputFolderPath, FileConstants.Results.OutputSize);
            File.WriteAllText(filePath, HasherTestsResultsFormatter.FormatOutputSizeResults(results));
        }

        public static void GenerateDeterminismResults(IHasher hasher, string inputFolderPath, string outputFolderPath)
        {
            var testRunner = new HasherTests(hasher);
            var determinismTestDataFolderPath = Path.Join(inputFolderPath, DirectoryConstants.DeterminismTestData);

            var results = testRunner.DeterminismTest(determinismTestDataFolderPath, timesToRun: 5);

            string filePath = Path.Join(outputFolderPath, FileConstants.Results.Determinism);
            File.WriteAllText(filePath, HasherTestsResultsFormatter.FormatDeterminismTestRetults(results));
        }

        public static void GenerateCollisionSearchResults(IHasher hasher, string inputFolderPath, string outputFolderPath)
        {
            var testRunner = new HasherTests(hasher);
            var collisionSearchTestDataFolderPath = Path.Join(inputFolderPath, DirectoryConstants.CollisionSearchTestData);

            var results = testRunner.CollisionSearchTest(collisionSearchTestDataFolderPath);

            string filePath = Path.Join(outputFolderPath, FileConstants.Results.CollisionSearch);
            File.WriteAllText(filePath, HasherTestsResultsFormatter.FormatCollisionSearchTestResults(results));
        }

        public static void GenerateAvalancheEffectResults(IHasher hasher, string inputFolderPath, string outputFolderPath)
        {
            var testRunner = new HasherTests(hasher);
            var results = testRunner.AvalancheEffectTest(Path.Join(inputFolderPath, FileConstants.Input.AvalancheEffectTestData));

            string filePath = Path.Join(outputFolderPath, FileConstants.Results.AvalancheEffect);
            File.WriteAllText(filePath, HasherTestsResultsFormatter.FormatAvalancheEffectTestResults(results));
        }
    }
}
