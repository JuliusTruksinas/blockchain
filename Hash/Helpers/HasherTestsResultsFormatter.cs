using System.Text;

namespace Hash.Helpers
{
    public static class HasherTestsResultsFormatter
    {
        public static string FormatEffectivenessResults(Dictionary<int, double> results)
        {
            var sb = new StringBuilder();

            AddTableHeading(sb, "Line count", "Time (ms)");

            foreach (var kvp in results)
                AddDataRow(sb, kvp.Key.ToString(), kvp.Value.ToString());

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
