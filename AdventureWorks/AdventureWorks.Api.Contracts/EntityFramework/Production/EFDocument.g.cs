using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Document", Schema="Production")]
	public partial class EFDocument
	{
		public EFDocument()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("DocumentNode", TypeName="hierarchyid(892)")]
		public Guid DocumentNode {get; set;}

		[Column("DocumentLevel", TypeName="smallint")]
		public Nullable<short> DocumentLevel {get; set;}

		[Column("Title", TypeName="nvarchar(50)")]
		public string Title {get; set;}

		[Column("Owner", TypeName="int")]
		public int Owner {get; set;}

		[Column("FolderFlag", TypeName="bit")]
		public bool FolderFlag {get; set;}

		[Column("FileName", TypeName="nvarchar(400)")]
		public string FileName {get; set;}

		[Column("FileExtension", TypeName="nvarchar(8)")]
		public string FileExtension {get; set;}

		[Column("Revision", TypeName="nchar(5)")]
		public string Revision {get; set;}

		[Column("ChangeNumber", TypeName="int")]
		public int ChangeNumber {get; set;}

		[Column("Status", TypeName="tinyint")]
		public int Status {get; set;}

		[Column("DocumentSummary", TypeName="nvarchar(-1)")]
		public string DocumentSummary {get; set;}

		[Column("Document", TypeName="varbinary(-1)")]
		public byte[] Document1 {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("Owner")]
		public virtual EFEmployee Employee { get; set; }
	}
}

/*<Codenesium>
    <Hash>9f0cd5e4aab491f3f520912d30aed0ca</Hash>
</Codenesium>*/