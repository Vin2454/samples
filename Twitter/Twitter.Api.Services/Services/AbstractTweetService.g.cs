using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractTweetService : AbstractService
	{
		protected ITweetRepository TweetRepository { get; private set; }

		protected IApiTweetRequestModelValidator TweetModelValidator { get; private set; }

		protected IBOLTweetMapper BolTweetMapper { get; private set; }

		protected IDALTweetMapper DalTweetMapper { get; private set; }

		protected IBOLQuoteTweetMapper BolQuoteTweetMapper { get; private set; }

		protected IDALQuoteTweetMapper DalQuoteTweetMapper { get; private set; }

		protected IBOLRetweetMapper BolRetweetMapper { get; private set; }

		protected IDALRetweetMapper DalRetweetMapper { get; private set; }

		private ILogger logger;

		public AbstractTweetService(
			ILogger logger,
			ITweetRepository tweetRepository,
			IApiTweetRequestModelValidator tweetModelValidator,
			IBOLTweetMapper bolTweetMapper,
			IDALTweetMapper dalTweetMapper,
			IBOLQuoteTweetMapper bolQuoteTweetMapper,
			IDALQuoteTweetMapper dalQuoteTweetMapper,
			IBOLRetweetMapper bolRetweetMapper,
			IDALRetweetMapper dalRetweetMapper)
			: base()
		{
			this.TweetRepository = tweetRepository;
			this.TweetModelValidator = tweetModelValidator;
			this.BolTweetMapper = bolTweetMapper;
			this.DalTweetMapper = dalTweetMapper;
			this.BolQuoteTweetMapper = bolQuoteTweetMapper;
			this.DalQuoteTweetMapper = dalQuoteTweetMapper;
			this.BolRetweetMapper = bolRetweetMapper;
			this.DalRetweetMapper = dalRetweetMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTweetResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TweetRepository.All(limit, offset);

			return this.BolTweetMapper.MapBOToModel(this.DalTweetMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTweetResponseModel> Get(int tweetId)
		{
			var record = await this.TweetRepository.Get(tweetId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTweetMapper.MapBOToModel(this.DalTweetMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTweetResponseModel>> Create(
			ApiTweetRequestModel model)
		{
			CreateResponse<ApiTweetResponseModel> response = new CreateResponse<ApiTweetResponseModel>(await this.TweetModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTweetMapper.MapModelToBO(default(int), model);
				var record = await this.TweetRepository.Create(this.DalTweetMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTweetMapper.MapBOToModel(this.DalTweetMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTweetResponseModel>> Update(
			int tweetId,
			ApiTweetRequestModel model)
		{
			var validationResult = await this.TweetModelValidator.ValidateUpdateAsync(tweetId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTweetMapper.MapModelToBO(tweetId, model);
				await this.TweetRepository.Update(this.DalTweetMapper.MapBOToEF(bo));

				var record = await this.TweetRepository.Get(tweetId);

				return new UpdateResponse<ApiTweetResponseModel>(this.BolTweetMapper.MapBOToModel(this.DalTweetMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTweetResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int tweetId)
		{
			ActionResponse response = new ActionResponse(await this.TweetModelValidator.ValidateDeleteAsync(tweetId));
			if (response.Success)
			{
				await this.TweetRepository.Delete(tweetId);
			}

			return response;
		}

		public async Task<List<ApiTweetResponseModel>> ByLocationId(int locationId, int limit = 0, int offset = int.MaxValue)
		{
			List<Tweet> records = await this.TweetRepository.ByLocationId(locationId, limit, offset);

			return this.BolTweetMapper.MapBOToModel(this.DalTweetMapper.MapEFToBO(records));
		}

		public async Task<List<ApiTweetResponseModel>> ByUserUserId(int userUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Tweet> records = await this.TweetRepository.ByUserUserId(userUserId, limit, offset);

			return this.BolTweetMapper.MapBOToModel(this.DalTweetMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiQuoteTweetResponseModel>> QuoteTweetsBySourceTweetId(int sourceTweetId, int limit = int.MaxValue, int offset = 0)
		{
			List<QuoteTweet> records = await this.TweetRepository.QuoteTweetsBySourceTweetId(sourceTweetId, limit, offset);

			return this.BolQuoteTweetMapper.MapBOToModel(this.DalQuoteTweetMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiRetweetResponseModel>> RetweetsByTweetTweetId(int tweetTweetId, int limit = int.MaxValue, int offset = 0)
		{
			List<Retweet> records = await this.TweetRepository.RetweetsByTweetTweetId(tweetTweetId, limit, offset);

			return this.BolRetweetMapper.MapBOToModel(this.DalRetweetMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>a78aa75ff84645cb9eedcfb8f81b3353</Hash>
</Codenesium>*/