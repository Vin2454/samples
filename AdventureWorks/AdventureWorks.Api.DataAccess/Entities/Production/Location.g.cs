using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Location", Schema="Production")]
	public partial class Location : AbstractEntity
	{
		public Location()
		{
		}

		public virtual void SetProperties(
			double availability,
			decimal costRate,
			short locationID,
			DateTime modifiedDate,
			string name)
		{
			this.Availability = availability;
			this.CostRate = costRate;
			this.LocationID = locationID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[Column("Availability")]
		public double Availability { get; private set; }

		[Column("CostRate")]
		public decimal CostRate { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("LocationID")]
		public short LocationID { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>39e7fa9df62f547b27cceef6bb4ffbf8</Hash>
</Codenesium>*/