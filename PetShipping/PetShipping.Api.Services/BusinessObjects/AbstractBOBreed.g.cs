using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBOBreed : AbstractBusinessObject
	{
		public AbstractBOBreed()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string name,
		                                  int speciesId)
		{
			this.Id = id;
			this.Name = name;
			this.SpeciesId = speciesId;
		}

		public int Id { get; private set; }

		public string Name { get; private set; }

		public int SpeciesId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>986f4fadb9763390f3752b03277e93da</Hash>
</Codenesium>*/