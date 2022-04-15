using System.Collections.Generic;
using System.Linq;

namespace ODataExperiments.Server
{
    internal static class RecordsProvider
    {
        private const int RecordCount = 1000;
        private const int FieldCount = 200;

        public static IReadOnlyCollection<Record> Records { get; } =
            RecordsGenerator.GenerateRecords(RecordCount, FieldCount);

        public static IReadOnlyCollection<IDictionary<string, object>> Dictionaries { get; } =
            Records
                .Select(r => 
                    new[] { KeyValuePair.Create(nameof(Record.Id), (object)r.Id) }
                        .Concat(r.Properties)
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value))
                .ToList();
    }
}
