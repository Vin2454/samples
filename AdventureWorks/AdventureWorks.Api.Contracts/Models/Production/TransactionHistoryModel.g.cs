using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class TransactionHistoryModel
	{
		public TransactionHistoryModel()
		{}

		public TransactionHistoryModel(int productID,
		                               int referenceOrderID,
		                               int referenceOrderLineID,
		                               DateTime transactionDate,
		                               string transactionType,
		                               int quantity,
		                               decimal actualCost,
		                               DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.ReferenceOrderID = referenceOrderID.ToInt();
			this.ReferenceOrderLineID = referenceOrderLineID.ToInt();
			this.TransactionDate = transactionDate.ToDateTime();
			this.TransactionType = transactionType;
			this.Quantity = quantity.ToInt();
			this.ActualCost = actualCost;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public TransactionHistoryModel(POCOTransactionHistory poco)
		{
			this.ReferenceOrderID = poco.ReferenceOrderID.ToInt();
			this.ReferenceOrderLineID = poco.ReferenceOrderLineID.ToInt();
			this.TransactionDate = poco.TransactionDate.ToDateTime();
			this.TransactionType = poco.TransactionType;
			this.Quantity = poco.Quantity.ToInt();
			this.ActualCost = poco.ActualCost;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.ProductID = poco.ProductID.Value.ToInt();
		}

		private int _productID;
		[Required]
		public int ProductID
		{
			get
			{
				return _productID;
			}
			set
			{
				this._productID = value;
			}
		}

		private int _referenceOrderID;
		[Required]
		public int ReferenceOrderID
		{
			get
			{
				return _referenceOrderID;
			}
			set
			{
				this._referenceOrderID = value;
			}
		}

		private int _referenceOrderLineID;
		[Required]
		public int ReferenceOrderLineID
		{
			get
			{
				return _referenceOrderLineID;
			}
			set
			{
				this._referenceOrderLineID = value;
			}
		}

		private DateTime _transactionDate;
		[Required]
		public DateTime TransactionDate
		{
			get
			{
				return _transactionDate;
			}
			set
			{
				this._transactionDate = value;
			}
		}

		private string _transactionType;
		[Required]
		public string TransactionType
		{
			get
			{
				return _transactionType;
			}
			set
			{
				this._transactionType = value;
			}
		}

		private int _quantity;
		[Required]
		public int Quantity
		{
			get
			{
				return _quantity;
			}
			set
			{
				this._quantity = value;
			}
		}

		private decimal _actualCost;
		[Required]
		public decimal ActualCost
		{
			get
			{
				return _actualCost;
			}
			set
			{
				this._actualCost = value;
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
    <Hash>bd15381bb246520a7b209df854d463d4</Hash>
</Codenesium>*/