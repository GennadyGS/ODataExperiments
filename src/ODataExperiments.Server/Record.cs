using System.ComponentModel.DataAnnotations;

public sealed class Record
{
    [Key]
    public int Id { get; init; }

    public IDictionary<string, object>? Properties { get; init; }
}
