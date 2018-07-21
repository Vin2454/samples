using Moq;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services.Tests
{
        public class BOLMapperMockFactory
        {
                public IBOLPersonMapper BOLPersonMapperMock { get; set; } = new BOLPersonMapper();

                public IBOLRowVersionCheckMapper BOLRowVersionCheckMapperMock { get; set; } = new BOLRowVersionCheckMapper();

                public IBOLSelfReferenceMapper BOLSelfReferenceMapperMock { get; set; } = new BOLSelfReferenceMapper();

                public IBOLTableMapper BOLTableMapperMock { get; set; } = new BOLTableMapper();

                public IBOLTestAllFieldTypeMapper BOLTestAllFieldTypeMapperMock { get; set; } = new BOLTestAllFieldTypeMapper();

                public IBOLTestAllFieldTypesNullableMapper BOLTestAllFieldTypesNullableMapperMock { get; set; } = new BOLTestAllFieldTypesNullableMapper();

                public IBOLTimestampCheckMapper BOLTimestampCheckMapperMock { get; set; } = new BOLTimestampCheckMapper();

                public IBOLSchemaAPersonMapper BOLSchemaAPersonMapperMock { get; set; } = new BOLSchemaAPersonMapper();

                public IBOLSchemaBPersonMapper BOLSchemaBPersonMapperMock { get; set; } = new BOLSchemaBPersonMapper();

                public IBOLPersonRefMapper BOLPersonRefMapperMock { get; set; } = new BOLPersonRefMapper();

                public BOLMapperMockFactory()
                {
                }
        }
}

/*<Codenesium>
    <Hash>1e4d1457feb9238b9b9de2e719799408</Hash>
</Codenesium>*/