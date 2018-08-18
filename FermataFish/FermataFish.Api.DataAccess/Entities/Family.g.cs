using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Family", Schema="dbo")]
	public partial class Family : AbstractEntity
	{
		public Family()
		{
		}

		public virtual void SetProperties(
			int id,
			string notes,
			string pcEmail,
			string pcFirstName,
			string pcLastName,
			string pcPhone,
			int studioId)
		{
			this.Id = id;
			this.Notes = notes;
			this.PcEmail = pcEmail;
			this.PcFirstName = pcFirstName;
			this.PcLastName = pcLastName;
			this.PcPhone = pcPhone;
			this.StudioId = studioId;
		}

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(2147483647)]
		[Column("notes")]
		public string Notes { get; private set; }

		[MaxLength(128)]
		[Column("pcEmail")]
		public string PcEmail { get; private set; }

		[MaxLength(128)]
		[Column("pcFirstName")]
		public string PcFirstName { get; private set; }

		[MaxLength(128)]
		[Column("pcLastName")]
		public string PcLastName { get; private set; }

		[MaxLength(128)]
		[Column("pcPhone")]
		public string PcPhone { get; private set; }

		[Column("studioId")]
		public int StudioId { get; private set; }

		[ForeignKey("Id")]
		public virtual Studio StudioNavigation { get; private set; }

		[ForeignKey("StudioId")]
		public virtual Studio Studio1Navigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ad6d5cb07483966a6f2f6128c71fecca</Hash>
</Codenesium>*/