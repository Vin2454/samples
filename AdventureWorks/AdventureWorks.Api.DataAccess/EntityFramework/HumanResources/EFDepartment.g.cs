using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Department", Schema="HumanResources")]
	public partial class EFDepartment
	{
		public EFDepartment()
		{}

		public void SetProperties(
			short departmentID,
			string name,
			string groupName,
			DateTime modifiedDate)
		{
			this.DepartmentID = departmentID;
			this.Name = name.ToString();
			this.GroupName = groupName.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("DepartmentID", TypeName="smallint")]
		public short DepartmentID { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("GroupName", TypeName="nvarchar(50)")]
		public string GroupName { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>50e8da75e5a9bf5efde3cd105f7829ea</Hash>
</Codenesium>*/