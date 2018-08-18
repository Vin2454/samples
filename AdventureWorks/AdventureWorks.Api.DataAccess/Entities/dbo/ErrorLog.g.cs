using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ErrorLog", Schema="dbo")]
	public partial class ErrorLog : AbstractEntity
	{
		public ErrorLog()
		{
		}

		public virtual void SetProperties(
			int? errorLine,
			int errorLogID,
			string errorMessage,
			int errorNumber,
			string errorProcedure,
			int? errorSeverity,
			int? errorState,
			DateTime errorTime,
			string userName)
		{
			this.ErrorLine = errorLine;
			this.ErrorLogID = errorLogID;
			this.ErrorMessage = errorMessage;
			this.ErrorNumber = errorNumber;
			this.ErrorProcedure = errorProcedure;
			this.ErrorSeverity = errorSeverity;
			this.ErrorState = errorState;
			this.ErrorTime = errorTime;
			this.UserName = userName;
		}

		[Column("ErrorLine")]
		public int? ErrorLine { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ErrorLogID")]
		public int ErrorLogID { get; private set; }

		[MaxLength(4000)]
		[Column("ErrorMessage")]
		public string ErrorMessage { get; private set; }

		[Column("ErrorNumber")]
		public int ErrorNumber { get; private set; }

		[MaxLength(126)]
		[Column("ErrorProcedure")]
		public string ErrorProcedure { get; private set; }

		[Column("ErrorSeverity")]
		public int? ErrorSeverity { get; private set; }

		[Column("ErrorState")]
		public int? ErrorState { get; private set; }

		[Column("ErrorTime")]
		public DateTime ErrorTime { get; private set; }

		[MaxLength(128)]
		[Column("UserName")]
		public string UserName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3812b038f6994042e9d5c5b1258fdefe</Hash>
</Codenesium>*/