using System.ComponentModel.DataAnnotations;

namespace ODataExperiments.Server.Models;

public sealed record City
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}
