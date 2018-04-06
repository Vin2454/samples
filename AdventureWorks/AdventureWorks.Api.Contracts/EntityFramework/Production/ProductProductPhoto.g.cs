using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductProductPhoto", Schema="Production")]
	public partial class EFProductProductPhoto
	{
		public EFProductProductPhoto()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductID", TypeName="int")]
		public int ProductID {get; set;}
		[Column("ProductPhotoID", TypeName="int")]
		public int ProductPhotoID {get; set;}
		[Column("Primary", TypeName="bit")]
		public bool Primary {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductID")]
		public virtual EFProduct ProductRef { get; set; }
		[ForeignKey("ProductPhotoID")]
		public virtual EFProductPhoto ProductPhotoRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>b5e865e9bfb936eb85dee6f03f244231</Hash>
</Codenesium>*/