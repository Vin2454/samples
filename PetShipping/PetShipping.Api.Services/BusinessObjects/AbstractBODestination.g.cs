using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBODestination : AbstractBusinessObject
	{
		public AbstractBODestination()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int countryId,
		                                  string name,
		                                  int order)
		{
			this.CountryId = countryId;
			this.Id = id;
			this.Name = name;
			this.Order = order;
		}

		public int CountryId { get; private set; }

		public int Id { get; private set; }

		public string Name { get; private set; }

		public int Order { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0128ad7591d05eba5fea9f15de82c9a0</Hash>
</Codenesium>*/