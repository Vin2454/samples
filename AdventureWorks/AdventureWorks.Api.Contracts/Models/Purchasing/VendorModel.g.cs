using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class VendorModel
	{
		public VendorModel()
		{}
		public VendorModel(string accountNumber,
		                   string name,
		                   int creditRating,
		                   bool preferredVendorStatus,
		                   bool activeFlag,
		                   string purchasingWebServiceURL,
		                   DateTime modifiedDate)
		{
			this.AccountNumber = accountNumber;
			this.Name = name;
			this.CreditRating = creditRating;
			this.PreferredVendorStatus = preferredVendorStatus;
			this.ActiveFlag = activeFlag;
			this.PurchasingWebServiceURL = purchasingWebServiceURL;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string _accountNumber;
		[Required]
		public string AccountNumber
		{
			get
			{
				return _accountNumber;
			}
			set
			{
				this._accountNumber = value;
			}
		}

		private string _name;
		[Required]
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				this._name = value;
			}
		}

		private int _creditRating;
		[Required]
		public int CreditRating
		{
			get
			{
				return _creditRating;
			}
			set
			{
				this._creditRating = value;
			}
		}

		private bool _preferredVendorStatus;
		[Required]
		public bool PreferredVendorStatus
		{
			get
			{
				return _preferredVendorStatus;
			}
			set
			{
				this._preferredVendorStatus = value;
			}
		}

		private bool _activeFlag;
		[Required]
		public bool ActiveFlag
		{
			get
			{
				return _activeFlag;
			}
			set
			{
				this._activeFlag = value;
			}
		}

		private string _purchasingWebServiceURL;
		public string PurchasingWebServiceURL
		{
			get
			{
				return _purchasingWebServiceURL.IsEmptyOrZeroOrNull() ? null : _purchasingWebServiceURL;
			}
			set
			{
				this._purchasingWebServiceURL = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>07e3d236a5b04d61407792fa1eb4fa4b</Hash>
</Codenesium>*/