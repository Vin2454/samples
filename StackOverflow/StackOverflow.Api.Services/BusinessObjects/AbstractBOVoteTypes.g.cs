using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractBOVoteTypes : AbstractBusinessObject
	{
		public AbstractBOVoteTypes()
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
    <Hash>f28f5c38beff1dead22466f6a62673d5</Hash>
</Codenesium>*/