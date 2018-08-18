using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NebulaNS.Api.DataAccess
{
	[Table("MachineRefTeam", Schema="dbo")]
	public partial class MachineRefTeam : AbstractEntity
	{
		public MachineRefTeam()
		{
		}

		public virtual void SetProperties(
			int id,
			int machineId,
			int teamId)
		{
			this.Id = id;
			this.MachineId = machineId;
			this.TeamId = teamId;
		}

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[Column("machineId")]
		public int MachineId { get; private set; }

		[Column("teamId")]
		public int TeamId { get; private set; }

		[ForeignKey("MachineId")]
		public virtual Machine MachineNavigation { get; private set; }

		[ForeignKey("TeamId")]
		public virtual Team TeamNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7e72588d702989c94dbda6f78a78a319</Hash>
</Codenesium>*/