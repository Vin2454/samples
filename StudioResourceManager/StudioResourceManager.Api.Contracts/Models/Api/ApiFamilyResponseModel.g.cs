using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiFamilyResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			string note,
			string primaryContactEmail,
			string primaryContactFirstName,
			string primaryContactLastName,
			string primaryContactPhone)
		{
			this.Id = id;
			this.Note = note;
			this.PrimaryContactEmail = primaryContactEmail;
			this.PrimaryContactFirstName = primaryContactFirstName;
			this.PrimaryContactLastName = primaryContactLastName;
			this.PrimaryContactPhone = primaryContactPhone;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string Note { get; private set; }

		[Required]
		[JsonProperty]
		public string PrimaryContactEmail { get; private set; }

		[Required]
		[JsonProperty]
		public string PrimaryContactFirstName { get; private set; }

		[Required]
		[JsonProperty]
		public string PrimaryContactLastName { get; private set; }

		[JsonProperty]
		public string PrimaryContactPhone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9988b2caac6c2f2b59d05fa6bd6d0d22</Hash>
</Codenesium>*/