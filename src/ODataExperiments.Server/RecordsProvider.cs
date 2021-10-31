namespace ODataExperiments.Server
{
    internal static class RecordsProvider
    {
        private const int RecordCount = 1000;
        private const int FieldCount = 200;

        public static IReadOnlyCollection<Record> Records { get; } =
            RecordsGenerator.GenerateRecords(RecordCount, FieldCount);
    }
}
