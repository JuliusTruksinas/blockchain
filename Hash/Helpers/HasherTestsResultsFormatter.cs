using System.Text;

namespace Hash.Helpers
{
    public static class HasherTestsResultsFormatter
    {
        public static string FormatEffectivenessResults(List<(int linesCount, string hash, long timeInMs)> results)
        {
            var sb = new StringBuilder();

            AddTableHeading(sb, "Line count", "Hash", "Time (ms)");

            foreach (var resultRow in results)
            {
                AddDataRow(sb, resultRow.linesCount.ToString(), resultRow.hash, resultRow.timeInMs.ToString());
            }

            return sb.ToString();
        }

        public static string FormatOutputSizeResults(List<(string fileName, string hash, int hashLength)> results)
        {
            var sb = new StringBuilder();
            AddTableHeading(sb, "File name", "Hash", "Hash length");

            foreach(var resultRow in results)
            {
                AddDataRow(sb, resultRow.fileName, resultRow.hash, resultRow.hashLength.ToString());
            }

            return sb.ToString();
        }

        public static string FormatDeterminismTestRetults(List<(string fileName, string hash, int timesRan, bool isDeterministic)> results)
        {
            var sb = new StringBuilder();
            AddTableHeading(sb, "File name", "Hash", "Times ran", "Is deterministic?");

            foreach (var resultRow in results)
            {
                AddDataRow(sb, resultRow.fileName, resultRow.hash, resultRow.timesRan.ToString(), resultRow.isDeterministic.ToString());
            }

            return sb.ToString();
        }

        public static string FormatCollisionSearchTestResults(List<(string fileName, int collisionCount)> results)
        {
            var sb = new StringBuilder();
            AddTableHeading(sb, "File name", "Collision count");

            foreach (var resultRow in results)
            {
                AddDataRow(sb, resultRow.fileName, resultRow.collisionCount.ToString());
            }

            return sb.ToString();
        }

        public static string FormatAvalancheEffectTestResults(List<(string level, double minMatch, double maxMatch, double avgMatch)> results)
        {
            var sb = new StringBuilder();

            AddTableHeading(sb, "Level", "Minimum difference%", "Maximum difference%", "Average difference%");

            foreach (var resultRow in results)
            {
                AddDataRow(
                    sb,
                    resultRow.level,
                    resultRow.minMatch.ToString("F2"),
                    resultRow.maxMatch.ToString("F2"),
                    resultRow.avgMatch.ToString("F2")
                );
            }

            return sb.ToString();
        }


        private static void AddTableHeading(StringBuilder sb, params string[] columns)
        {
            sb.AppendLine("| " + string.Join(" | ", columns) + " |");
            sb.AppendLine("| " + string.Join(" | ", columns.Select(_ => "---")) + " |");
        }

        private static void AddDataRow(StringBuilder sb, params string[] dataRow)
            => sb.AppendLine("| " + string.Join(" | ", dataRow) + " |");
    }
}
