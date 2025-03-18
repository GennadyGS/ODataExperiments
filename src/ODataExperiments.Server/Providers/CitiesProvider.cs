using System.Linq;
using ODataExperiments.Server.Extensions;
using ODataExperiments.Server.Generators;
using ODataExperiments.Server.Models;

namespace ODataExperiments.Server.Providers;

internal static class CitiesProvider
{
    private const int Count = 1000;

    public static DataApiResponse<City> GetCities(CityDataApiRequest request) =>
        CitiesGenerator.GenerateCities(Count)
            .Where(x => request.Search is null || x.Name.StartsWithIgnoreCase(request.Search))
            .Where(x => request.State is null || x.State.EqualsIgnoreCase(request.State))
            .CreateDataApiResponse(request);
}