using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using ODataExperiments.Server.Models;

namespace ODataExperiments.Server.Generators;

internal static class RecordsGenerator
{
    private const int MaxStringLength = 31;

    private const int Seed = 6734345;

    static RecordsGenerator() =>
        Randomizer.Seed = new Random(Seed);

    public static IReadOnlyCollection<Record> GenerateRecords(
        int recordCount, int fieldCount) =>
        new Faker<Record>()
            .CustomInstantiator(faker => GenerateRecord(faker, fieldCount))
            .Generate(recordCount);

    private static Record GenerateRecord(Faker faker, int fieldCount) =>
        new()
        {
            Id = faker.IndexFaker,
            Properties = GenerateProperties(faker, fieldCount),
        };

    private static IDictionary<string, object> GenerateProperties(
        Faker faker, int fieldCount) =>
        Enumerable.Range(0, fieldCount)
            .ToDictionary(
                i => $"Field_{i:D3}",
                _ => GeneratePropertyValue(faker));

    private static object GeneratePropertyValue(Faker faker) =>
        faker.Random.Enum<FieldType>() switch
        {
            FieldType.Bool => faker.Random.Bool(),
            FieldType.Char => faker.Random.Char('0', '9'),
            FieldType.String => faker.Random.AlphaNumeric(faker.Random.Int(0, MaxStringLength)),
            FieldType.Decimal => faker.Random.Decimal(),
            _ => throw new InvalidOperationException("Unknown type"),
        };

    private enum FieldType
    {
        Bool,
        Char,
        String,
        Decimal,
    }

}
