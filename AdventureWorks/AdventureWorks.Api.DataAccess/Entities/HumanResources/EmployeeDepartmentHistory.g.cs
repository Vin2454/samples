using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("EmployeeDepartmentHistory", Schema="HumanResources")]
	public partial class EmployeeDepartmentHistory : AbstractEntity
	{
		public EmployeeDepartmentHistory()
		{
		}

		public virtual void SetProperties(
			int businessEntityID,
			short departmentID,
			DateTime? endDate,
			DateTime modifiedDate,
			int shiftID,
			DateTime startDate)
		{
			this.BusinessEntityID = businessEntityID;
			this.DepartmentID = departmentID;
			this.EndDate = endDate;
			this.ModifiedDate = modifiedDate;
			this.ShiftID = shiftID;
			this.StartDate = startDate;
		}

		[Key]
		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; private set; }

		[Key]
		[Column("DepartmentID")]
		public short DepartmentID { get; private set; }

		[Column("EndDate")]
		public DateTime? EndDate { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("ShiftID")]
		public int ShiftID { get; private set; }

		[Key]
		[Column("StartDate")]
		public DateTime StartDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>af86757a97f08b1b95c726dbfd2ff6f3</Hash>
</Codenesium>*/