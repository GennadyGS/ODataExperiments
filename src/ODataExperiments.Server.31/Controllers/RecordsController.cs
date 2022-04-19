using System.Collections.Generic;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace ODataExperiments.Server.Controllers;

public sealed class RecordsController : ODataController
{
    [EnableQuery]
    public IReadOnlyCollection<Record> GetRecords() => RecordsProvider.Records;
}
