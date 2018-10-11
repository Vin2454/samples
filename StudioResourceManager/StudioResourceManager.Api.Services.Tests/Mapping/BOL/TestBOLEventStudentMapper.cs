using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStudent")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLEventStudentMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLEventStudentMapper();
			ApiEventStudentRequestModel model = new ApiEventStudentRequestModel();
			model.SetProperties(1);
			BOEventStudent response = mapper.MapModelToBO(1, model);

			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLEventStudentMapper();
			BOEventStudent bo = new BOEventStudent();
			bo.SetProperties(1, 1);
			ApiEventStudentResponseModel response = mapper.MapBOToModel(bo);

			response.EventId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLEventStudentMapper();
			BOEventStudent bo = new BOEventStudent();
			bo.SetProperties(1, 1);
			List<ApiEventStudentResponseModel> response = mapper.MapBOToModel(new List<BOEventStudent>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>377400eb66346b1f40d2d7d36f3e27cc</Hash>
</Codenesium>*/