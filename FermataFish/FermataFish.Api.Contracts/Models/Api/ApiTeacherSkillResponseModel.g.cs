using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiTeacherSkillResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			int studioId)
		{
			this.Id = id;
			this.Name = name;
			this.StudioId = studioId;

			this.StudioIdEntity = nameof(ApiResponse.Studios);
		}

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public int StudioId { get; private set; }

		[JsonProperty]
		public string StudioIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>89e2bd3f7dc262d73f5a7ceab6274ff2</Hash>
</Codenesium>*/