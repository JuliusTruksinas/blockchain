namespace Hash.Helpers
{
    public static class HasherTestResultsGenerator
    {
        public static void GenerateEffectivenessResults(string folderPath, Dictionary<int, double> results)
        {
            string filePath = Path.Join(folderPath, "effectivenessResult.md");
            File.WriteAllText(filePath, HasherTestsResultsFormatter.FormatEffectivenessResults(results));
        }
    }
}
