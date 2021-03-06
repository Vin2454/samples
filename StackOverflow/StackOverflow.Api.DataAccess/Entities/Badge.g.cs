using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("Badges", Schema="dbo")]
	public partial class Badge : AbstractEntity
	{
		public Badge()
		{
		}

		public virtual void SetProperties(
			DateTime date,
			int id,
			string name,
			int userId)
		{
			this.Date = date;
			this.Id = id;
			this.Name = name;
			this.UserId = userId;
		}

		[Column("Date")]
		public DateTime Date { get; private set; }

		[Key]
		[Column("Id")]
		public int Id { get; private set; }

		[MaxLength(40)]
		[Column("Name")]
		public string Name { get; private set; }

		[Column("UserId")]
		public int UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f0c38ae71d90a8aefcbfc00fb4405250</Hash>
</Codenesium>*/