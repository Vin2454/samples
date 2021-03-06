using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IPhoneNumberTypeRepository
	{
		Task<PhoneNumberType> Create(PhoneNumberType item);

		Task Update(PhoneNumberType item);

		Task Delete(int phoneNumberTypeID);

		Task<PhoneNumberType> Get(int phoneNumberTypeID);

		Task<List<PhoneNumberType>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<PersonPhone>> PersonPhonesByPhoneNumberTypeID(int phoneNumberTypeID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>495fbe0ebe8c25954912c66fa2a079ab</Hash>
</Codenesium>*/