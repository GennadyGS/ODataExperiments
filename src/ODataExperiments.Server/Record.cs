using System.ComponentModel.DataAnnotations;

public sealed class Record
{
    public Record(int rowId, IDictionary<string, object> properties)
    {
        RowId = rowId;
        Properties = properties;
    }

    [Key]
    public int RowId { get; set; }

    public IDictionary<string, object> Properties { get; }
}
