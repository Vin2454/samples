using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ApiLinkStatusResponseModel: AbstractApiResponseModel
	{
		public ApiLinkStatusResponseModel() : base()
		{}

		public void SetProperties(
			int id,
			string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		public int Id { get; private set; }
		public string Name { get; private set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>b0de379df7e23d16df56ed65cf5db5e9</Hash>
</Codenesium>*/