using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ESPIOTNS.Api.DataAccess
{
	[Table("DeviceAction", Schema="dbo")]
	public partial class DeviceAction : AbstractEntity
	{
		public DeviceAction()
		{
		}

		public virtual void SetProperties(
			int deviceId,
			int id,
			string name,
			string @value)
		{
			this.DeviceId = deviceId;
			this.Id = id;
			this.Name = name;
			this.@Value = @value;
		}

		[Column("deviceId")]
		public int DeviceId { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(90)]
		[Column("name")]
		public string Name { get; private set; }

		[MaxLength(4000)]
		[Column("value")]
		public string @Value { get; private set; }

		[ForeignKey("DeviceId")]
		public virtual Device DeviceNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6bc067bd358615d5414780f3ca860c6a</Hash>
</Codenesium>*/