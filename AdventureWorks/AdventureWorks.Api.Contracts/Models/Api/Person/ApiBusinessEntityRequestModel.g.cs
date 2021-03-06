using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiBusinessEntityRequestModel : AbstractApiRequestModel
	{
		public ApiBusinessEntityRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.ModifiedDate = modifiedDate;
			this.Rowguid = rowguid;
		}

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>281b93a8f02b61e67e1f5811a3926613</Hash>
</Codenesium>*/