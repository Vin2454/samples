using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractCommentService : AbstractService
	{
		protected ICommentRepository CommentRepository { get; private set; }

		protected IApiCommentRequestModelValidator CommentModelValidator { get; private set; }

		protected IBOLCommentMapper BolCommentMapper { get; private set; }

		protected IDALCommentMapper DalCommentMapper { get; private set; }

		private ILogger logger;

		public AbstractCommentService(
			ILogger logger,
			ICommentRepository commentRepository,
			IApiCommentRequestModelValidator commentModelValidator,
			IBOLCommentMapper bolCommentMapper,
			IDALCommentMapper dalCommentMapper)
			: base()
		{
			this.CommentRepository = commentRepository;
			this.CommentModelValidator = commentModelValidator;
			this.BolCommentMapper = bolCommentMapper;
			this.DalCommentMapper = dalCommentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCommentResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CommentRepository.All(limit, offset);

			return this.BolCommentMapper.MapBOToModel(this.DalCommentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCommentResponseModel> Get(int id)
		{
			var record = await this.CommentRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCommentMapper.MapBOToModel(this.DalCommentMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCommentResponseModel>> Create(
			ApiCommentRequestModel model)
		{
			CreateResponse<ApiCommentResponseModel> response = new CreateResponse<ApiCommentResponseModel>(await this.CommentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolCommentMapper.MapModelToBO(default(int), model);
				var record = await this.CommentRepository.Create(this.DalCommentMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCommentMapper.MapBOToModel(this.DalCommentMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCommentResponseModel>> Update(
			int id,
			ApiCommentRequestModel model)
		{
			var validationResult = await this.CommentModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCommentMapper.MapModelToBO(id, model);
				await this.CommentRepository.Update(this.DalCommentMapper.MapBOToEF(bo));

				var record = await this.CommentRepository.Get(id);

				return new UpdateResponse<ApiCommentResponseModel>(this.BolCommentMapper.MapBOToModel(this.DalCommentMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCommentResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.CommentModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.CommentRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>eb8ee4bbda9a1fdf3629a69836bf1fe1</Hash>
</Codenesium>*/