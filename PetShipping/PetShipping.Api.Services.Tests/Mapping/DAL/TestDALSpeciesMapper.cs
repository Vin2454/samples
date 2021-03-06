using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Species")]
	[Trait("Area", "DALMapper")]
	public class TestDALSpeciesMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALSpeciesMapper();
			var bo = new BOSpecies();
			bo.SetProperties(1, "A");

			Species response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSpeciesMapper();
			Species entity = new Species();
			entity.SetProperties(1, "A");

			BOSpecies response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSpeciesMapper();
			Species entity = new Species();
			entity.SetProperties(1, "A");

			List<BOSpecies> response = mapper.MapEFToBO(new List<Species>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6b812564e65d25dc935d91cae72a7d81</Hash>
</Codenesium>*/