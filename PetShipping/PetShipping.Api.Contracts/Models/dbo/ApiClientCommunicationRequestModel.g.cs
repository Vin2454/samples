using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiClientCommunicationRequestModel: AbstractApiRequestModel
	{
		public ApiClientCommunicationRequestModel() : base()
		{}

		public void SetProperties(
			int clientId,
			DateTime dateCreated,
			int employeeId,
			string notes)
		{
			this.ClientId = clientId.ToInt();
			this.DateCreated = dateCreated.ToDateTime();
			this.EmployeeId = employeeId.ToInt();
			this.Notes = notes;
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

		private DateTime dateCreated;

		[Required]
		public DateTime DateCreated
		{
			get
			{
				return this.dateCreated;
			}

			set
			{
				this.dateCreated = value;
			}
		}

		private int employeeId;

		[Required]
		public int EmployeeId
		{
			get
			{
				return this.employeeId;
			}

			set
			{
				this.employeeId = value;
			}
		}

		private string notes;

		[Required]
		public string Notes
		{
			get
			{
				return this.notes;
			}

			set
			{
				this.notes = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>c94c4db6becfe6aa07de935f636cbb92</Hash>
</Codenesium>*/