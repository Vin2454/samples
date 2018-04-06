using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ESPIOTNS.Api.Contracts
{
	[Table("Device", Schema="dbo")]
	public partial class EFDevice
	{
		public EFDevice()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}
		[Column("publicId", TypeName="uniqueidentifier")]
		public Guid PublicId {get; set;}
		[Column("name", TypeName="varchar(90)")]
		public string Name {get; set;}
	}
}

/*<Codenesium>
    <Hash>1e08b5893269b8bfb6471c3a50487f11</Hash>
</Codenesium>*/