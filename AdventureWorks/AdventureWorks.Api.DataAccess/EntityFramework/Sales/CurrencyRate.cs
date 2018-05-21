using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("CurrencyRate", Schema="Sales")]
	public partial class CurrencyRate: AbstractEntityFrameworkPOCO
	{
		public CurrencyRate()
		{}

		public void SetProperties(
			int currencyRateID,
			decimal averageRate,
			DateTime currencyRateDate,
			decimal endOfDayRate,
			string fromCurrencyCode,
			DateTime modifiedDate,
			string toCurrencyCode)
		{
			this.AverageRate = averageRate.ToDecimal();
			this.CurrencyRateDate = currencyRateDate.ToDateTime();
			this.CurrencyRateID = currencyRateID.ToInt();
			this.EndOfDayRate = endOfDayRate.ToDecimal();
			this.FromCurrencyCode = fromCurrencyCode;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ToCurrencyCode = toCurrencyCode;
		}

		[Column("AverageRate", TypeName="money")]
		public decimal AverageRate { get; set; }

		[Column("CurrencyRateDate", TypeName="datetime")]
		public DateTime CurrencyRateDate { get; set; }

		[Key]
		[Column("CurrencyRateID", TypeName="int")]
		public int CurrencyRateID { get; set; }

		[Column("EndOfDayRate", TypeName="money")]
		public decimal EndOfDayRate { get; set; }

		[Column("FromCurrencyCode", TypeName="nchar(3)")]
		public string FromCurrencyCode { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("ToCurrencyCode", TypeName="nchar(3)")]
		public string ToCurrencyCode { get; set; }

		[ForeignKey("FromCurrencyCode")]
		public virtual Currency Currency { get; set; }

		[ForeignKey("ToCurrencyCode")]
		public virtual Currency Currency1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>81967c05baa36f7fcf6c533c20e88d94</Hash>
</Codenesium>*/