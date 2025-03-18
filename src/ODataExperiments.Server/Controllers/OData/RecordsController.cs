using System.Collections.Generic;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataExperiments.Server.Models;
using ODataExperiments.Server.Providers;

namespace ODataExperiments.Server.Controllers.OData;

public sealed class RecordsController : ODataController
{
    [EnableQuery]
    public IReadOnlyCollection<Record> GetRecords() => RecordsProvider.Records;
}
