using System.ComponentModel.DataAnnotations;

namespace ODataExperiments.Server.Models;

public sealed record City
{
    [Key]
    public int Id { get; set; }

    public string State { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
}
