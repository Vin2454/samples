using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiVendorModel
	{
		public ApiVendorModel()
		{}

		public ApiVendorModel(
			string accountNumber,
			bool activeFlag,
			int creditRating,
			DateTime modifiedDate,
			string name,
			bool preferredVendorStatus,
			string purchasingWebServiceURL)
		{
			this.AccountNumber = accountNumber.ToString();
			this.ActiveFlag = activeFlag.ToBoolean();
			this.CreditRating = creditRating.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.PreferredVendorStatus = preferredVendorStatus.ToBoolean();
			this.PurchasingWebServiceURL = purchasingWebServiceURL.ToString();
		}

		private string accountNumber;

		[Required]
		public string AccountNumber
		{
			get
			{
				return this.accountNumber;
			}

			set
			{
				this.accountNumber = value;
			}
		}

		private bool activeFlag;

		[Required]
		public bool ActiveFlag
		{
			get
			{
				return this.activeFlag;
			}

			set
			{
				this.activeFlag = value;
			}
		}

		private int creditRating;

		[Required]
		public int CreditRating
		{
			get
			{
				return this.creditRating;
			}

			set
			{
				this.creditRating = value;
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

		private string name;

		[Required]
		public string Name
		{
			get
			{
				return this.name;
			}

			set
			{
				this.name = value;
			}
		}

		private bool preferredVendorStatus;

		[Required]
		public bool PreferredVendorStatus
		{
			get
			{
				return this.preferredVendorStatus;
			}

			set
			{
				this.preferredVendorStatus = value;
			}
		}

		private string purchasingWebServiceURL;

		public string PurchasingWebServiceURL
		{
			get
			{
				return this.purchasingWebServiceURL.IsEmptyOrZeroOrNull() ? null : this.purchasingWebServiceURL;
			}

			set
			{
				this.purchasingWebServiceURL = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>02cb78086882c8d8d67ecd52bed308eb</Hash>
</Codenesium>*/