using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class DALAbstractAirlineMapper
	{
		public virtual Airline MapBOToEF(
			BOAirline bo)
		{
			Airline efAirline = new Airline();
			efAirline.SetProperties(
				bo.Id,
				bo.Name);
			return efAirline;
		}

		public virtual BOAirline MapEFToBO(
			Airline ef)
		{
			var bo = new BOAirline();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOAirline> MapEFToBO(
			List<Airline> records)
		{
			List<BOAirline> response = new List<BOAirline>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8259a4bd29ff4781d71471bf13958ffa</Hash>
</Codenesium>*/