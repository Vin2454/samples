using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public partial interface IMessengerRepository
	{
		Task<Messenger> Create(Messenger item);

		Task Update(Messenger item);

		Task Delete(int id);

		Task<Messenger> Get(int id);

		Task<List<Messenger>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Messenger>> ByMessageId(int? messageId, int limit = int.MaxValue, int offset = 0);

		Task<List<Messenger>> ByToUserId(int toUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Messenger>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0);

		Task<Message> MessageByMessageId(int? messageId);

		Task<User> UserByToUserId(int toUserId);

		Task<User> UserByUserId(int? userId);
	}
}

/*<Codenesium>
    <Hash>7865202079ce20c978fa8cf8454d968c</Hash>
</Codenesium>*/