using Microsoft.AspNetCore.Mvc;
using ODataExperiments.Server.Models;
using ODataExperiments.Server.Providers;

namespace ODataExperiments.Server.Controllers.Api;

[Route("[controller]")]
public sealed class CitiesController : Controller
{
    [HttpGet]
    public DataApiResponse<City> GetCities([FromQuery]CityDataApiRequest request) =>
        CitiesProvider.GetCities(request);
}