using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class DALAbstractLocationMapper
	{
		public virtual Location MapBOToEF(
			BOLocation bo)
		{
			Location efLocation = new Location();
			efLocation.SetProperties(
				bo.GpsLat,
				bo.GpsLong,
				bo.LocationId,
				bo.LocationName);
			return efLocation;
		}

		public virtual BOLocation MapEFToBO(
			Location ef)
		{
			var bo = new BOLocation();

			bo.SetProperties(
				ef.LocationId,
				ef.GpsLat,
				ef.GpsLong,
				ef.LocationName);
			return bo;
		}

		public virtual List<BOLocation> MapEFToBO(
			List<Location> records)
		{
			List<BOLocation> response = new List<BOLocation>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>311b4c4594aa073e422aa416f77edb18</Hash>
</Codenesium>*/