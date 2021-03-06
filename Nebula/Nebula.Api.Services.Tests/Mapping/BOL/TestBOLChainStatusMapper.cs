using FluentAssertions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ChainStatus")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLChainStatusMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLChainStatusMapper();
			ApiChainStatusRequestModel model = new ApiChainStatusRequestModel();
			model.SetProperties("A");
			BOChainStatus response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLChainStatusMapper();
			BOChainStatus bo = new BOChainStatus();
			bo.SetProperties(1, "A");
			ApiChainStatusResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLChainStatusMapper();
			BOChainStatus bo = new BOChainStatus();
			bo.SetProperties(1, "A");
			List<ApiChainStatusResponseModel> response = mapper.MapBOToModel(new List<BOChainStatus>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>fed25982c8b3223e9a7f07af754bd1a7</Hash>
</Codenesium>*/