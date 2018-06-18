using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOTagSet: AbstractBusinessObject
        {
                public AbstractBOTagSet() : base()
                {
                }

                public virtual void SetProperties(string id,
                                                  byte[] dataVersion,
                                                  string jSON,
                                                  string name,
                                                  int sortOrder)
                {
                        this.DataVersion = dataVersion;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.SortOrder = sortOrder;
                }

                public byte[] DataVersion { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public int SortOrder { get; private set; }
        }
}

/*<Codenesium>
    <Hash>056352217851717d9ac53a0ab8378dfe</Hash>
</Codenesium>*/