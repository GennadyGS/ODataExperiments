using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ODataExperiments.Server.Controllers;

public class RecordsController : ODataController
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [EnableQuery]
    public IReadOnlyCollection<Record> GetRecords() =>
        Enumerable.Range(1, 5)
            .Select(index =>
                new Record
                {
                    Id = index,
                    Properties =
                        new Dictionary<string, object>()
                        {
                            ["Date"] = DateTime.Now.AddDays(index),
                            ["TemperatureC"] = Random.Shared.Next(-20, 55),
                            ["Summary"] = Summaries[Random.Shared.Next(Summaries.Length)]
                        }
                })
                .ToArray();

}
