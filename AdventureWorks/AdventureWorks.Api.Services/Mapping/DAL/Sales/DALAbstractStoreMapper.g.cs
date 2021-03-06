using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractStoreMapper
	{
		public virtual Store MapBOToEF(
			BOStore bo)
		{
			Store efStore = new Store();
			efStore.SetProperties(
				bo.BusinessEntityID,
				bo.Demographic,
				bo.ModifiedDate,
				bo.Name,
				bo.Rowguid,
				bo.SalesPersonID);
			return efStore;
		}

		public virtual BOStore MapEFToBO(
			Store ef)
		{
			var bo = new BOStore();

			bo.SetProperties(
				ef.BusinessEntityID,
				ef.Demographic,
				ef.ModifiedDate,
				ef.Name,
				ef.Rowguid,
				ef.SalesPersonID);
			return bo;
		}

		public virtual List<BOStore> MapEFToBO(
			List<Store> records)
		{
			List<BOStore> response = new List<BOStore>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e116c2c71cb9ebfc2599cf2a5c8957e7</Hash>
</Codenesium>*/