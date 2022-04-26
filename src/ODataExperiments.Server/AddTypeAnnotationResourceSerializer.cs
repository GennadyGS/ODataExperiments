using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.OData;

namespace ODataExperiments.Server;

public sealed class AddTypeAnnotationResourceSerializer : ODataResourceSerializer
{
    public AddTypeAnnotationResourceSerializer(IODataSerializerProvider provider)
        : base(provider)
    { }

    public override ODataResource CreateResource(
        SelectExpandNode selectExpandNode, ResourceContext resourceContext)
    {
        var resource = base.CreateResource(selectExpandNode, resourceContext);
        foreach (var property in resource.Properties)
        {
            property.TypeAnnotation = null;
        }

        return resource;
    }
}
