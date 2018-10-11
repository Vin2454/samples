using FluentAssertions;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceSpaceFeature")]
	[Trait("Area", "DALMapper")]
	public class TestDALSpaceSpaceFeatureMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALSpaceSpaceFeatureMapper();
			var bo = new BOSpaceSpaceFeature();
			bo.SetProperties(1, 1);

			SpaceSpaceFeature response = mapper.MapBOToEF(bo);

			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSpaceSpaceFeatureMapper();
			SpaceSpaceFeature entity = new SpaceSpaceFeature();
			entity.SetProperties(1, 1);

			BOSpaceSpaceFeature response = mapper.MapEFToBO(entity);

			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSpaceSpaceFeatureMapper();
			SpaceSpaceFeature entity = new SpaceSpaceFeature();
			entity.SetProperties(1, 1);

			List<BOSpaceSpaceFeature> response = mapper.MapEFToBO(new List<SpaceSpaceFeature>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1ac99750623b214e50bb1a151d0b1ab9</Hash>
</Codenesium>*/