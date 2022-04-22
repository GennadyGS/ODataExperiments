using System;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.OData.Edm;

namespace ODataExperiments.Server
{
    public sealed class AddTypeAnnotationSerializerProvider : ODataSerializerProvider
    {
        public AddTypeAnnotationSerializerProvider(IServiceProvider sp) : base(sp) { }

        public override IODataEdmTypeSerializer GetEdmTypeSerializer(IEdmTypeReference edmType)
        {
            if (edmType.IsEntity() || edmType.IsComplex())
            {
                return new AddTypeAnnotationResourceSerializer(this);
            }

            return base.GetEdmTypeSerializer(edmType);
        }
    }
}
