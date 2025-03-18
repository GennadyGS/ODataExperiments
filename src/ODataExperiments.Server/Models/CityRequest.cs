namespace ODataExperiments.Server.Models;

public sealed record CityDataApiRequest : DataApiRequestBase
{
    public string? State { get; init; }
}