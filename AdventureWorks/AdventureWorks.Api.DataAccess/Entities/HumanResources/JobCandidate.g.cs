using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("JobCandidate", Schema="HumanResources")]
	public partial class JobCandidate : AbstractEntity
	{
		public JobCandidate()
		{
		}

		public virtual void SetProperties(
			int? businessEntityID,
			int jobCandidateID,
			DateTime modifiedDate,
			string resume)
		{
			this.BusinessEntityID = businessEntityID;
			this.JobCandidateID = jobCandidateID;
			this.ModifiedDate = modifiedDate;
			this.Resume = resume;
		}

		[Column("BusinessEntityID")]
		public int? BusinessEntityID { get; private set; }

		[Key]
		[Column("JobCandidateID")]
		public int JobCandidateID { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Column("Resume")]
		public string Resume { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cd52ed0a70b36c8189d4766cb2004043</Hash>
</Codenesium>*/