namespace ODataExperiments.Server.Models;

public record DataApiRequestBase
{
    public string? Search { get; init; }

    public int? Skip { get; init; }

    public int? Take { get; init; }
}
