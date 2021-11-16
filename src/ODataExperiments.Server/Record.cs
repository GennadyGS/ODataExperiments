using System.ComponentModel.DataAnnotations;

namespace ODataExperiments.Server;

public sealed class Record
{
    public Record(int id, IDictionary<string, object> properties)
    {
        Id = id;
        Properties = properties;
    }

    [Key]
    public int Id { get; init; }

    public IDictionary<string, object> Properties { get; init; }
}
