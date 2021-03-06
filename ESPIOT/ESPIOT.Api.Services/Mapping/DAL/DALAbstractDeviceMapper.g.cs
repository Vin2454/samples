using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public abstract class DALAbstractDeviceMapper
	{
		public virtual Device MapBOToEF(
			BODevice bo)
		{
			Device efDevice = new Device();
			efDevice.SetProperties(
				bo.Id,
				bo.Name,
				bo.PublicId);
			return efDevice;
		}

		public virtual BODevice MapEFToBO(
			Device ef)
		{
			var bo = new BODevice();

			bo.SetProperties(
				ef.Id,
				ef.Name,
				ef.PublicId);
			return bo;
		}

		public virtual List<BODevice> MapEFToBO(
			List<Device> records)
		{
			List<BODevice> response = new List<BODevice>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8a3c9ca865347b32bf1f1665c00b9bad</Hash>
</Codenesium>*/