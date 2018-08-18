using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBOClient : AbstractBusinessObject
	{
		public AbstractBOClient()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string email,
		                                  string firstName,
		                                  string lastName,
		                                  string notes,
		                                  string phone)
		{
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id;
			this.LastName = lastName;
			this.Notes = notes;
			this.Phone = phone;
		}

		public string Email { get; private set; }

		public string FirstName { get; private set; }

		public int Id { get; private set; }

		public string LastName { get; private set; }

		public string Notes { get; private set; }

		public string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0ae92529e0ff788f480f1278355acc47</Hash>
</Codenesium>*/