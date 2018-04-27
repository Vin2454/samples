using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("EmployeeDepartmentHistory", Schema="HumanResources")]
	public partial class EFEmployeeDepartmentHistory: AbstractEntityFrameworkPOCO
	{
		public EFEmployeeDepartmentHistory()
		{}

		public void SetProperties(
			int businessEntityID,
			short departmentID,
			Nullable<DateTime> endDate,
			DateTime modifiedDate,
			int shiftID,
			DateTime startDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.DepartmentID = departmentID;
			this.EndDate = endDate.ToNullableDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ShiftID = shiftID.ToInt();
			this.StartDate = startDate.ToDateTime();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("DepartmentID", TypeName="smallint")]
		public short DepartmentID { get; set; }

		[Column("EndDate", TypeName="date")]
		public Nullable<DateTime> EndDate { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("ShiftID", TypeName="tinyint")]
		public int ShiftID { get; set; }

		[Column("StartDate", TypeName="date")]
		public DateTime StartDate { get; set; }

		[ForeignKey("BusinessEntityID")]
		public virtual EFEmployee Employee { get; set; }

		[ForeignKey("DepartmentID")]
		public virtual EFDepartment Department { get; set; }

		[ForeignKey("ShiftID")]
		public virtual EFShift Shift { get; set; }
	}
}

/*<Codenesium>
    <Hash>7604478bf1688b0153f4c8199c5a5458</Hash>
</Codenesium>*/