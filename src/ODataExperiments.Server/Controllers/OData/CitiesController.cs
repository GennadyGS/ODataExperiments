using System.Collections.Generic;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataExperiments.Server.Models;
using ODataExperiments.Server.Providers;

namespace ODataExperiments.Server.Controllers.OData;

public sealed class CitiesController : ODataController
{
    [EnableQuery]
    public IReadOnlyCollection<City> GetCities() =>
        CitiesProvider.GetCities(new CityDataApiRequest()).Result;
}
