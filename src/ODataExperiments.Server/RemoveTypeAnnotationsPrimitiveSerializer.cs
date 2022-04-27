using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.OData;
using Microsoft.OData.Edm;

namespace ODataExperiments.Server;

internal sealed class RemoveTypeAnnotationsPrimitiveSerializer : ODataPrimitiveSerializer
{
    public override ODataPrimitiveValue CreateODataPrimitiveValue(
        object graph, IEdmPrimitiveTypeReference primitiveType,
        ODataSerializerContext writeContext)
    {
        var result = base.CreateODataPrimitiveValue(graph, primitiveType, writeContext);
        result.TypeAnnotation ??= new ODataTypeAnnotation(null);

        return result;
    }
}