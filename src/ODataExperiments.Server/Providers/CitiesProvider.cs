using System.Collections.Generic;
using ODataExperiments.Server.Generators;
using ODataExperiments.Server.Models;

namespace ODataExperiments.Server.Providers;

internal static class CitiesProvider
{
    private const int Count = 1000;

    public static IReadOnlyCollection<City> Cities { get; } =
        CitiesGenerator.GenerateCities(Count);
}