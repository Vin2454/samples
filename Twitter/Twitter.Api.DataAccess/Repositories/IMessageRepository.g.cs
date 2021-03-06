using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public partial interface IMessageRepository
	{
		Task<Message> Create(Message item);

		Task Update(Message item);

		Task Delete(int messageId);

		Task<Message> Get(int messageId);

		Task<List<Message>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Message>> BySenderUserId(int? senderUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Messenger>> MessengersByMessageId(int messageId, int limit = int.MaxValue, int offset = 0);

		Task<User> UserBySenderUserId(int? senderUserId);
	}
}

/*<Codenesium>
    <Hash>cd5f278766169471f037e0227240a22c</Hash>
</Codenesium>*/