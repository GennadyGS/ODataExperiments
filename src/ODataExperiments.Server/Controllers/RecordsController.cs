using Bogus;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ODataExperiments.Server.Controllers;

public class RecordsController : ODataController
{
    private const int RecordCount = 1000;
    private const int FieldCount = 200;
    private const int Seed = 6734345;
    private const int MaxStringLength = 31;

    static RecordsController() =>
        Randomizer.Seed = new Random(Seed);

    private static IReadOnlyCollection<Record> Records { get; } = 
        GenerateRecords();

    [EnableQuery]
    public IReadOnlyCollection<Record> GetRecords() => Records;

    private static IReadOnlyCollection<Record> GenerateRecords() =>
        new Faker<Record>()
            .CustomInstantiator(GenerateRecord)
            .Generate(RecordCount);

    private static Record GenerateRecord(Faker faker) =>
        new()
        {
            Id = faker.IndexFaker,
            Properties = GenerateProperties(faker),
        };

    private static IDictionary<string, object> GenerateProperties(Faker faker) =>
        Enumerable.Range(0, FieldCount)
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
