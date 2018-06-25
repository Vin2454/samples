using Codenesium.DataConversionExtensions;
using System;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractBOTicketStatus : AbstractBusinessObject
        {
                public AbstractBOTicketStatus()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  string name)
                {
                        this.Id = id;
                        this.Name = name;
                }

                public int Id { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e5f7868add9a244c19b60be9f88e802e</Hash>
</Codenesium>*/