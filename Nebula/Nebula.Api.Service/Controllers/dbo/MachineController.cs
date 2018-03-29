using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service
{
	[Route("api/machines")]
	public class MachinesController: AbstractMachinesController
	{
		public MachinesController(
			ILogger<MachinesController> logger,
			ApplicationContext context,
			IMachineRepository machineRepository,
			IMachineModelValidator machineModelValidator
			) : base(logger,
			         context,
			         machineRepository,
			         machineModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>09ba51d307dad73f60dda10fdf5eafa2</Hash>
</Codenesium>*/