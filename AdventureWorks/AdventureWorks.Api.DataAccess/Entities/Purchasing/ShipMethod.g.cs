using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ShipMethod", Schema="Purchasing")]
	public partial class ShipMethod : AbstractEntity
	{
		public ShipMethod()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			decimal shipBase,
			int shipMethodID,
			decimal shipRate)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.ShipBase = shipBase;
			this.ShipMethodID = shipMethodID;
			this.ShipRate = shipRate;
		}

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public string Name { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid")]
		public Guid Rowguid { get; private set; }

		[Column("ShipBase")]
		public decimal ShipBase { get; private set; }

		[Key]
		[Column("ShipMethodID")]
		public int ShipMethodID { get; private set; }

		[Column("ShipRate")]
		public decimal ShipRate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>eebf9133716a3546341eb55f04bf9ee2</Hash>
</Codenesium>*/