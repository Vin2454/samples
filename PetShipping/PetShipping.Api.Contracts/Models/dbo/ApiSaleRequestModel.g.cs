using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiSaleRequestModel: AbstractApiRequestModel
	{
		public ApiSaleRequestModel() : base()
		{}

		public void SetProperties(
			decimal amount,
			int clientId,
			string note,
			int petId,
			DateTime saleDate,
			int salesPersonId)
		{
			this.Amount = amount.ToDecimal();
			this.ClientId = clientId.ToInt();
			this.Note = note;
			this.PetId = petId.ToInt();
			this.SaleDate = saleDate.ToDateTime();
			this.SalesPersonId = salesPersonId.ToInt();
		}

		private decimal amount;

		[Required]
		public decimal Amount
		{
			get
			{
				return this.amount;
			}

			set
			{
				this.amount = value;
			}
		}

		private int clientId;

		[Required]
		public int ClientId
		{
			get
			{
				return this.clientId;
			}

			set
			{
				this.clientId = value;
			}
		}

		private string note;

		[Required]
		public string Note
		{
			get
			{
				return this.note;
			}

			set
			{
				this.note = value;
			}
		}

		private int petId;

		[Required]
		public int PetId
		{
			get
			{
				return this.petId;
			}

			set
			{
				this.petId = value;
			}
		}

		private DateTime saleDate;

		[Required]
		public DateTime SaleDate
		{
			get
			{
				return this.saleDate;
			}

			set
			{
				this.saleDate = value;
			}
		}

		private int salesPersonId;

		[Required]
		public int SalesPersonId
		{
			get
			{
				return this.salesPersonId;
			}

			set
			{
				this.salesPersonId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>7ca25e4a738e8fe24a7817e6e3d2463b</Hash>
</Codenesium>*/