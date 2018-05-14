using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public interface IBOVersionInfo
	{
		Task<CreateResponse<POCOVersionInfo>> Create(
			ApiVersionInfoModel model);

		Task<ActionResponse> Update(long version,
		                            ApiVersionInfoModel model);

		Task<ActionResponse> Delete(long version);

		POCOVersionInfo Get(long version);

		List<POCOVersionInfo> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOVersionInfo Version(long version);
	}
}

/*<Codenesium>
    <Hash>9dc01cc9f7dfe1f720699074628ed490</Hash>
</Codenesium>*/