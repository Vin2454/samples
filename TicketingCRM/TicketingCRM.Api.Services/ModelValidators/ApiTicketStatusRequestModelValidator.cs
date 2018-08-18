using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiTicketStatusRequestModelValidator : AbstractApiTicketStatusRequestModelValidator, IApiTicketStatusRequestModelValidator
	{
		public ApiTicketStatusRequestModelValidator(ITicketStatusRepository ticketStatusRepository)
			: base(ticketStatusRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTicketStatusRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketStatusRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>c735892efb670951b318ed91c4a90c8e</Hash>
</Codenesium>*/