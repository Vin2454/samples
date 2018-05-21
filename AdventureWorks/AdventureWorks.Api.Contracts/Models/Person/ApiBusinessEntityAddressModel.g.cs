using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiBusinessEntityAddressModel: AbstractModel
	{
		public ApiBusinessEntityAddressModel() : base()
		{}

		public ApiBusinessEntityAddressModel(
			int addressID,
			int addressTypeID,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.AddressID = addressID.ToInt();
			this.AddressTypeID = addressTypeID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
		}

		private int addressID;

		[Required]
		public int AddressID
		{
			get
			{
				return this.addressID;
			}

			set
			{
				this.addressID = value;
			}
		}

		private int addressTypeID;

		[Required]
		public int AddressTypeID
		{
			get
			{
				return this.addressTypeID;
			}

			set
			{
				this.addressTypeID = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}

		private Guid rowguid;

		[Required]
		public Guid Rowguid
		{
			get
			{
				return this.rowguid;
			}

			set
			{
				this.rowguid = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>1ea8fae55a79d9270afb741ec74f9fdd</Hash>
</Codenesium>*/