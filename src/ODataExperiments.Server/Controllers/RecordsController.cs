using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ODataExperiments.Server.Controllers;

public sealed class RecordsController : ODataController
{
    [EnableQuery]
    public IReadOnlyCollection<Record> GetRecords() => RecordsProvider.Records;
}
