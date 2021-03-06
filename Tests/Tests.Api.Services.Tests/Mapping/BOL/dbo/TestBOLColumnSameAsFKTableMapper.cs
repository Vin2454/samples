using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ColumnSameAsFKTable")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLColumnSameAsFKTableMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLColumnSameAsFKTableMapper();
			ApiColumnSameAsFKTableRequestModel model = new ApiColumnSameAsFKTableRequestModel();
			model.SetProperties(1, 1);
			BOColumnSameAsFKTable response = mapper.MapModelToBO(1, model);

			response.Person.Should().Be(1);
			response.PersonId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLColumnSameAsFKTableMapper();
			BOColumnSameAsFKTable bo = new BOColumnSameAsFKTable();
			bo.SetProperties(1, 1, 1);
			ApiColumnSameAsFKTableResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Person.Should().Be(1);
			response.PersonId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLColumnSameAsFKTableMapper();
			BOColumnSameAsFKTable bo = new BOColumnSameAsFKTable();
			bo.SetProperties(1, 1, 1);
			List<ApiColumnSameAsFKTableResponseModel> response = mapper.MapBOToModel(new List<BOColumnSameAsFKTable>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>70fc5567349394d89fc2a8ac542dd414</Hash>
</Codenesium>*/