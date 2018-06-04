using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALShiftMapper
	{
		Shift MapBOToEF(
			BOShift bo);

		BOShift MapEFToBO(
			Shift efShift);

		List<BOShift> MapEFToBO(
			List<Shift> records);
	}
}

/*<Codenesium>
    <Hash>81fe365162f1270f62c030b379550bc8</Hash>
</Codenesium>*/