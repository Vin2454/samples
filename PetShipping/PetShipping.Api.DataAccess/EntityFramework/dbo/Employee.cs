using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Employee", Schema="dbo")]
	public partial class Employee: AbstractEntityFrameworkPOCO
	{
		public Employee()
		{}

		public void SetProperties(
			int id,
			string firstName,
			bool isSalesPerson,
			bool isShipper,
			string lastName)
		{
			this.FirstName = firstName;
			this.Id = id.ToInt();
			this.IsSalesPerson = isSalesPerson.ToBoolean();
			this.IsShipper = isShipper.ToBoolean();
			this.LastName = lastName;
		}

		[Column("firstName", TypeName="varchar(128)")]
		public string FirstName { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("isSalesPerson", TypeName="bit")]
		public bool IsSalesPerson { get; set; }

		[Column("isShipper", TypeName="bit")]
		public bool IsShipper { get; set; }

		[Column("lastName", TypeName="varchar(128)")]
		public string LastName { get; set; }
	}
}

/*<Codenesium>
    <Hash>487df6517a209786443eea8161857cd5</Hash>
</Codenesium>*/