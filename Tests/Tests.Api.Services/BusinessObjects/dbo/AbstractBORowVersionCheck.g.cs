using Codenesium.DataConversionExtensions;
using System;

namespace TestsNS.Api.Services
{
        public abstract class AbstractBORowVersionCheck : AbstractBusinessObject
        {
                public AbstractBORowVersionCheck()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  string name,
                                                  Guid rowVersion)
                {
                        this.Id = id;
                        this.Name = name;
                        this.RowVersion = rowVersion;
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public Guid RowVersion { get; private set; }
        }
}

/*<Codenesium>
    <Hash>bd1c5962aca08b88be8cf6e8b71d2b74</Hash>
</Codenesium>*/