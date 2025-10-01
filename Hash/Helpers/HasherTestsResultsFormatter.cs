using System.Text;

namespace Hash.Helpers
{
    public static class HasherTestsResultsFormatter
    {
        public static string FormatEffectivenessResults(Dictionary<int, long> results)
        {
            var sb = new StringBuilder();

            AddTableHeading(sb, "Line count", "Time (ms)");

            foreach (var kvp in results)
                AddDataRow(sb, kvp.Key.ToString(), kvp.Value.ToString());

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

        private static void AddTableHeading(StringBuilder sb, params string[] columns)
        {
            sb.AppendLine("| " + string.Join(" | ", columns) + " |");
            sb.AppendLine("| " + string.Join(" | ", columns.Select(_ => "---")) + " |");
        }

        private static void AddDataRow(StringBuilder sb, params string[] dataRow)
            => sb.AppendLine("| " + string.Join(" | ", dataRow) + " |");
    }
}
