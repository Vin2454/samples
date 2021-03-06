using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpecialOfferProduct")]
	[Trait("Area", "DALMapper")]
	public class TestDALSpecialOfferProductMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALSpecialOfferProductMapper();
			var bo = new BOSpecialOfferProduct();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			SpecialOfferProduct response = mapper.MapBOToEF(bo);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SpecialOfferID.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSpecialOfferProductMapper();
			SpecialOfferProduct entity = new SpecialOfferProduct();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);

			BOSpecialOfferProduct response = mapper.MapEFToBO(entity);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SpecialOfferID.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSpecialOfferProductMapper();
			SpecialOfferProduct entity = new SpecialOfferProduct();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);

			List<BOSpecialOfferProduct> response = mapper.MapEFToBO(new List<SpecialOfferProduct>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>0c4baa7f5d93827b241c549b97bbaa03</Hash>
</Codenesium>*/