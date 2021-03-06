using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
	public partial class ApiCommentRequestModel : AbstractApiRequestModel
	{
		public ApiCommentRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime creationDate,
			int postId,
			int? score,
			string text,
			int? userId)
		{
			this.CreationDate = creationDate;
			this.PostId = postId;
			this.Score = score;
			this.Text = text;
			this.UserId = userId;
		}

		[Required]
		[JsonProperty]
		public DateTime CreationDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public int PostId { get; private set; } = default(int);

		[JsonProperty]
		public int? Score { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string Text { get; private set; } = default(string);

		[JsonProperty]
		public int? UserId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>4aadc9842381b7cbcb763e1ceb2dd0c7</Hash>
</Codenesium>*/