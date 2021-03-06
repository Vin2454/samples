using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOPassword : AbstractBusinessObject
	{
		public AbstractBOPassword()
			: base()
		{
		}

		public virtual void SetProperties(int businessEntityID,
		                                  DateTime modifiedDate,
		                                  string passwordHash,
		                                  string passwordSalt,
		                                  Guid rowguid)
		{
			this.BusinessEntityID = businessEntityID;
			this.ModifiedDate = modifiedDate;
			this.PasswordHash = passwordHash;
			this.PasswordSalt = passwordSalt;
			this.Rowguid = rowguid;
		}

		public int BusinessEntityID { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public string PasswordHash { get; private set; }

		public string PasswordSalt { get; private set; }

		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>76fa04a81e758938c79efd7b74ac13f3</Hash>
</Codenesium>*/