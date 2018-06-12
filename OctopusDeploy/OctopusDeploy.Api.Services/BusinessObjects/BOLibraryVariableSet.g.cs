using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOLibraryVariableSet: AbstractBusinessObject
        {
                public BOLibraryVariableSet() : base()
                {
                }

                public void SetProperties(string id,
                                          string contentType,
                                          string jSON,
                                          string name,
                                          string variableSetId)
                {
                        this.ContentType = contentType;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.VariableSetId = variableSetId;
                }

                public string ContentType { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public string VariableSetId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>45e693b349a8126b5fc18143cdd735ea</Hash>
</Codenesium>*/