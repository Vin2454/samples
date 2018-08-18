using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FileServiceNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileServiceNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VersionInfo")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLVersionInfoMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLVersionInfoMapper();
			ApiVersionInfoRequestModel model = new ApiVersionInfoRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			BOVersionInfo response = mapper.MapModelToBO(1, model);

			response.AppliedOn.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLVersionInfoMapper();
			BOVersionInfo bo = new BOVersionInfo();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiVersionInfoResponseModel response = mapper.MapBOToModel(bo);

			response.AppliedOn.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
			response.Version.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLVersionInfoMapper();
			BOVersionInfo bo = new BOVersionInfo();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiVersionInfoResponseModel> response = mapper.MapBOToModel(new List<BOVersionInfo>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5b5b39503adbf3f77122bbbbb0b8409b</Hash>
</Codenesium>*/