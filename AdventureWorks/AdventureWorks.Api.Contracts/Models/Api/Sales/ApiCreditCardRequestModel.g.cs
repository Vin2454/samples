using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiCreditCardRequestModel : AbstractApiRequestModel
	{
		public ApiCreditCardRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string cardNumber,
			string cardType,
			int expMonth,
			short expYear,
			DateTime modifiedDate)
		{
			this.CardNumber = cardNumber;
			this.CardType = cardType;
			this.ExpMonth = expMonth;
			this.ExpYear = expYear;
			this.ModifiedDate = modifiedDate;
		}

		[Required]
		[JsonProperty]
		public string CardNumber { get; private set; }

		[Required]
		[JsonProperty]
		public string CardType { get; private set; }

		[Required]
		[JsonProperty]
		public int ExpMonth { get; private set; }

		[Required]
		[JsonProperty]
		public short ExpYear { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5a5ec1b5fa84b507cb605d48301f41b0</Hash>
</Codenesium>*/