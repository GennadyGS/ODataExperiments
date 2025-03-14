using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ODataExperiments.Server.Models;

public sealed class Record
{
    [Key]
    public required int Id { get; init; }

    public required IDictionary<string, object> Properties { get; init; }
}
