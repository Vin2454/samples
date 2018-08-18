using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
	public partial class ApiBadgesResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime date,
			string name,
			int userId)
		{
			this.Id = id;
			this.Date = date;
			this.Name = name;
			this.UserId = userId;
		}

		[Required]
		[JsonProperty]
		public DateTime Date { get; private set; }

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public int UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1e0c951dbbc0388a8086522f6e46675d</Hash>
</Codenesium>*/