using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOSale
	{
		private ISaleRepository saleRepository;
		private ISaleModelValidator saleModelValidator;
		private ILogger logger;

		public AbstractBOSale(
			ILogger logger,
			ISaleRepository saleRepository,
			ISaleModelValidator saleModelValidator)

		{
			this.saleRepository = saleRepository;
			this.saleModelValidator = saleModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			SaleModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.saleModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.saleRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			SaleModel model)
		{
			ActionResponse response = new ActionResponse(await this.saleModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.saleRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.saleModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.saleRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.saleRepository.GetById(id);
		}

		public virtual POCOSale GetByIdDirect(int id)
		{
			return this.saleRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSale, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.saleRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.saleRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSale> GetWhereDirect(Expression<Func<EFSale, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.saleRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>d7e5809427a36dd737cd246cb474a05e</Hash>
</Codenesium>*/