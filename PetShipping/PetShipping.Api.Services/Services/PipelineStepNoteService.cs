using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineStepNoteService : AbstractPipelineStepNoteService, IPipelineStepNoteService
	{
		public PipelineStepNoteService(
			ILogger<IPipelineStepNoteRepository> logger,
			IPipelineStepNoteRepository pipelineStepNoteRepository,
			IApiPipelineStepNoteRequestModelValidator pipelineStepNoteModelValidator,
			IBOLPipelineStepNoteMapper bolpipelineStepNoteMapper,
			IDALPipelineStepNoteMapper dalpipelineStepNoteMapper
			)
			: base(logger,
			       pipelineStepNoteRepository,
			       pipelineStepNoteModelValidator,
			       bolpipelineStepNoteMapper,
			       dalpipelineStepNoteMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>295409689112ae93bdb76defcf594837</Hash>
</Codenesium>*/