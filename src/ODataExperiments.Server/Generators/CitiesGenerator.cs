using System;
using System.Collections.Generic;
using Bogus;
using ODataExperiments.Server.Models;

namespace ODataExperiments.Server.Generators;

internal static class CitiesGenerator
{
    private const int Seed = 45345378;

    static CitiesGenerator() =>
        Randomizer.Seed = new Random(Seed);

    public static IReadOnlyCollection<City> GenerateCities(int recordCount) =>
        new Faker<City>()
            .CustomInstantiator(GenerateCity)
            .Generate(recordCount);

    private static City GenerateCity(Faker faker) =>
        new()
        {
            Id = faker.IndexFaker,
            Name = faker.Address.City(),
        };
}
