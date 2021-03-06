using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class CustomerService : AbstractCustomerService, ICustomerService
	{
		public CustomerService(
			ILogger<ICustomerRepository> logger,
			ICustomerRepository customerRepository,
			IApiCustomerRequestModelValidator customerModelValidator,
			IBOLCustomerMapper bolcustomerMapper,
			IDALCustomerMapper dalcustomerMapper)
			: base(logger,
			       customerRepository,
			       customerModelValidator,
			       bolcustomerMapper,
			       dalcustomerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c9f424aea8c7eb3cfec7220e55736c3c</Hash>
</Codenesium>*/