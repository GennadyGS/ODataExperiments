using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ODataExperiments.Server.Controllers;

public class RecordsController : ODataController
{
    private const int RecordCount = 1000;
    private const int FieldCount = 200;

    private static IReadOnlyCollection<Record> Records { get; } = 
        RecordsGenerator.GenerateRecords(RecordCount, FieldCount);

    [EnableQuery]
    public IReadOnlyCollection<Record> GetRecords() => Records;

}
