using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("PersonCreditCard", Schema="Sales")]
	public partial class PersonCreditCard: AbstractEntityFrameworkPOCO
	{
		public PersonCreditCard()
		{}

		public void SetProperties(
			int businessEntityID,
			int creditCardID,
			DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.CreditCardID = creditCardID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("CreditCardID", TypeName="int")]
		public int CreditCardID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("CreditCardID")]
		public virtual CreditCard CreditCard { get; set; }
	}
}

/*<Codenesium>
    <Hash>b7a0e8173a44fc2ab12881cf94dda088</Hash>
</Codenesium>*/