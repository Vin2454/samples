using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractScrapReasonMapper
	{
		public virtual ScrapReason MapBOToEF(
			BOScrapReason bo)
		{
			ScrapReason efScrapReason = new ScrapReason();
			efScrapReason.SetProperties(
				bo.ModifiedDate,
				bo.Name,
				bo.ScrapReasonID);
			return efScrapReason;
		}

		public virtual BOScrapReason MapEFToBO(
			ScrapReason ef)
		{
			var bo = new BOScrapReason();

			bo.SetProperties(
				ef.ScrapReasonID,
				ef.ModifiedDate,
				ef.Name);
			return bo;
		}

		public virtual List<BOScrapReason> MapEFToBO(
			List<ScrapReason> records)
		{
			List<BOScrapReason> response = new List<BOScrapReason>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>443311596b9fe4a48234b7c0e3764385</Hash>
</Codenesium>*/