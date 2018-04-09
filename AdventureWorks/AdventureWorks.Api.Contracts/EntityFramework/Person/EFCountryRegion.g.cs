using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("CountryRegion", Schema="Person")]
	public partial class EFCountryRegion
	{
		public EFCountryRegion()
		{}

		public void SetProperties(string countryRegionCode,
		                          string name,
		                          DateTime modifiedDate)
		{
			this.CountryRegionCode = countryRegionCode;
			this.Name = name;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("CountryRegionCode", TypeName="nvarchar(3)")]
		public string CountryRegionCode {get; set;}

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>44791399f82aaed40645a44a5099664c</Hash>
</Codenesium>*/