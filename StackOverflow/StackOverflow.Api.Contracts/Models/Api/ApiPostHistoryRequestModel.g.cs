using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
	public partial class ApiPostHistoryRequestModel : AbstractApiRequestModel
	{
		public ApiPostHistoryRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string comment,
			DateTime creationDate,
			int postHistoryTypeId,
			int postId,
			string revisionGUID,
			string text,
			string userDisplayName,
			int? userId)
		{
			this.Comment = comment;
			this.CreationDate = creationDate;
			this.PostHistoryTypeId = postHistoryTypeId;
			this.PostId = postId;
			this.RevisionGUID = revisionGUID;
			this.Text = text;
			this.UserDisplayName = userDisplayName;
			this.UserId = userId;
		}

		[JsonProperty]
		public string Comment { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime CreationDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public int PostHistoryTypeId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int PostId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string RevisionGUID { get; private set; } = default(string);

		[JsonProperty]
		public string Text { get; private set; } = default(string);

		[JsonProperty]
		public string UserDisplayName { get; private set; } = default(string);

		[JsonProperty]
		public int? UserId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>6fa538572e2168c675a7c71fd3409653</Hash>
</Codenesium>*/