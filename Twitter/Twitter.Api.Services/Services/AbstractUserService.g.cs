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
	public abstract class AbstractUserService : AbstractService
	{
		protected IUserRepository UserRepository { get; private set; }

		protected IApiUserRequestModelValidator UserModelValidator { get; private set; }

		protected IBOLUserMapper BolUserMapper { get; private set; }

		protected IDALUserMapper DalUserMapper { get; private set; }

		protected IBOLDirectTweetMapper BolDirectTweetMapper { get; private set; }

		protected IDALDirectTweetMapper DalDirectTweetMapper { get; private set; }

		protected IBOLFollowerMapper BolFollowerMapper { get; private set; }

		protected IDALFollowerMapper DalFollowerMapper { get; private set; }

		protected IBOLMessageMapper BolMessageMapper { get; private set; }

		protected IDALMessageMapper DalMessageMapper { get; private set; }

		protected IBOLMessengerMapper BolMessengerMapper { get; private set; }

		protected IDALMessengerMapper DalMessengerMapper { get; private set; }

		protected IBOLQuoteTweetMapper BolQuoteTweetMapper { get; private set; }

		protected IDALQuoteTweetMapper DalQuoteTweetMapper { get; private set; }

		protected IBOLReplyMapper BolReplyMapper { get; private set; }

		protected IDALReplyMapper DalReplyMapper { get; private set; }

		protected IBOLRetweetMapper BolRetweetMapper { get; private set; }

		protected IDALRetweetMapper DalRetweetMapper { get; private set; }

		protected IBOLTweetMapper BolTweetMapper { get; private set; }

		protected IDALTweetMapper DalTweetMapper { get; private set; }

		private ILogger logger;

		public AbstractUserService(
			ILogger logger,
			IUserRepository userRepository,
			IApiUserRequestModelValidator userModelValidator,
			IBOLUserMapper bolUserMapper,
			IDALUserMapper dalUserMapper,
			IBOLDirectTweetMapper bolDirectTweetMapper,
			IDALDirectTweetMapper dalDirectTweetMapper,
			IBOLFollowerMapper bolFollowerMapper,
			IDALFollowerMapper dalFollowerMapper,
			IBOLMessageMapper bolMessageMapper,
			IDALMessageMapper dalMessageMapper,
			IBOLMessengerMapper bolMessengerMapper,
			IDALMessengerMapper dalMessengerMapper,
			IBOLQuoteTweetMapper bolQuoteTweetMapper,
			IDALQuoteTweetMapper dalQuoteTweetMapper,
			IBOLReplyMapper bolReplyMapper,
			IDALReplyMapper dalReplyMapper,
			IBOLRetweetMapper bolRetweetMapper,
			IDALRetweetMapper dalRetweetMapper,
			IBOLTweetMapper bolTweetMapper,
			IDALTweetMapper dalTweetMapper)
			: base()
		{
			this.UserRepository = userRepository;
			this.UserModelValidator = userModelValidator;
			this.BolUserMapper = bolUserMapper;
			this.DalUserMapper = dalUserMapper;
			this.BolDirectTweetMapper = bolDirectTweetMapper;
			this.DalDirectTweetMapper = dalDirectTweetMapper;
			this.BolFollowerMapper = bolFollowerMapper;
			this.DalFollowerMapper = dalFollowerMapper;
			this.BolMessageMapper = bolMessageMapper;
			this.DalMessageMapper = dalMessageMapper;
			this.BolMessengerMapper = bolMessengerMapper;
			this.DalMessengerMapper = dalMessengerMapper;
			this.BolQuoteTweetMapper = bolQuoteTweetMapper;
			this.DalQuoteTweetMapper = dalQuoteTweetMapper;
			this.BolReplyMapper = bolReplyMapper;
			this.DalReplyMapper = dalReplyMapper;
			this.BolRetweetMapper = bolRetweetMapper;
			this.DalRetweetMapper = dalRetweetMapper;
			this.BolTweetMapper = bolTweetMapper;
			this.DalTweetMapper = dalTweetMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiUserResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.UserRepository.All(limit, offset);

			return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiUserResponseModel> Get(int userId)
		{
			var record = await this.UserRepository.Get(userId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiUserResponseModel>> Create(
			ApiUserRequestModel model)
		{
			CreateResponse<ApiUserResponseModel> response = new CreateResponse<ApiUserResponseModel>(await this.UserModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolUserMapper.MapModelToBO(default(int), model);
				var record = await this.UserRepository.Create(this.DalUserMapper.MapBOToEF(bo));

				response.SetRecord(this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiUserResponseModel>> Update(
			int userId,
			ApiUserRequestModel model)
		{
			var validationResult = await this.UserModelValidator.ValidateUpdateAsync(userId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolUserMapper.MapModelToBO(userId, model);
				await this.UserRepository.Update(this.DalUserMapper.MapBOToEF(bo));

				var record = await this.UserRepository.Get(userId);

				return new UpdateResponse<ApiUserResponseModel>(this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiUserResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int userId)
		{
			ActionResponse response = new ActionResponse(await this.UserModelValidator.ValidateDeleteAsync(userId));
			if (response.Success)
			{
				await this.UserRepository.Delete(userId);
			}

			return response;
		}

		public async Task<List<ApiUserResponseModel>> ByLocationLocationId(int locationLocationId, int limit = 0, int offset = int.MaxValue)
		{
			List<User> records = await this.UserRepository.ByLocationLocationId(locationLocationId, limit, offset);

			return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiDirectTweetResponseModel>> DirectTweetsByTaggedUserId(int taggedUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<DirectTweet> records = await this.UserRepository.DirectTweetsByTaggedUserId(taggedUserId, limit, offset);

			return this.BolDirectTweetMapper.MapBOToModel(this.DalDirectTweetMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiFollowerResponseModel>> FollowersByFollowedUserId(int followedUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Follower> records = await this.UserRepository.FollowersByFollowedUserId(followedUserId, limit, offset);

			return this.BolFollowerMapper.MapBOToModel(this.DalFollowerMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiFollowerResponseModel>> FollowersByFollowingUserId(int followingUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Follower> records = await this.UserRepository.FollowersByFollowingUserId(followingUserId, limit, offset);

			return this.BolFollowerMapper.MapBOToModel(this.DalFollowerMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiMessageResponseModel>> MessagesBySenderUserId(int senderUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Message> records = await this.UserRepository.MessagesBySenderUserId(senderUserId, limit, offset);

			return this.BolMessageMapper.MapBOToModel(this.DalMessageMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiMessengerResponseModel>> MessengersByToUserId(int toUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Messenger> records = await this.UserRepository.MessengersByToUserId(toUserId, limit, offset);

			return this.BolMessengerMapper.MapBOToModel(this.DalMessengerMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiMessengerResponseModel>> MessengersByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			List<Messenger> records = await this.UserRepository.MessengersByUserId(userId, limit, offset);

			return this.BolMessengerMapper.MapBOToModel(this.DalMessengerMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiQuoteTweetResponseModel>> QuoteTweetsByRetweeterUserId(int retweeterUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<QuoteTweet> records = await this.UserRepository.QuoteTweetsByRetweeterUserId(retweeterUserId, limit, offset);

			return this.BolQuoteTweetMapper.MapBOToModel(this.DalQuoteTweetMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiReplyResponseModel>> RepliesByReplierUserId(int replierUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Reply> records = await this.UserRepository.RepliesByReplierUserId(replierUserId, limit, offset);

			return this.BolReplyMapper.MapBOToModel(this.DalReplyMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiRetweetResponseModel>> RetweetsByRetwitterUserId(int retwitterUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Retweet> records = await this.UserRepository.RetweetsByRetwitterUserId(retwitterUserId, limit, offset);

			return this.BolRetweetMapper.MapBOToModel(this.DalRetweetMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTweetResponseModel>> TweetsByUserUserId(int userUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Tweet> records = await this.UserRepository.TweetsByUserUserId(userUserId, limit, offset);

			return this.BolTweetMapper.MapBOToModel(this.DalTweetMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiUserResponseModel>> ByLikerUserId(int likerUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<User> records = await this.UserRepository.ByLikerUserId(likerUserId, limit, offset);

			return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>313fca733ac1021eec11562015c8b031</Hash>
</Codenesium>*/