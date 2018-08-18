using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractNuGetPackageMapper
	{
		public virtual NuGetPackage MapBOToEF(
			BONuGetPackage bo)
		{
			NuGetPackage efNuGetPackage = new NuGetPackage();
			efNuGetPackage.SetProperties(
				bo.Id,
				bo.JSON,
				bo.PackageId,
				bo.Version,
				bo.VersionBuild,
				bo.VersionMajor,
				bo.VersionMinor,
				bo.VersionRevision,
				bo.VersionSpecial);
			return efNuGetPackage;
		}

		public virtual BONuGetPackage MapEFToBO(
			NuGetPackage ef)
		{
			var bo = new BONuGetPackage();

			bo.SetProperties(
				ef.Id,
				ef.JSON,
				ef.PackageId,
				ef.Version,
				ef.VersionBuild,
				ef.VersionMajor,
				ef.VersionMinor,
				ef.VersionRevision,
				ef.VersionSpecial);
			return bo;
		}

		public virtual List<BONuGetPackage> MapEFToBO(
			List<NuGetPackage> records)
		{
			List<BONuGetPackage> response = new List<BONuGetPackage>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1d0848690b6a98348785b37b78a72958</Hash>
</Codenesium>*/