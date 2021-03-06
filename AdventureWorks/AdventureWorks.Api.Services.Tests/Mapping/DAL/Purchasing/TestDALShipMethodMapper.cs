using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ShipMethod")]
	[Trait("Area", "DALMapper")]
	public class TestDALShipMethodMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALShipMethodMapper();
			var bo = new BOShipMethod();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);

			ShipMethod response = mapper.MapBOToEF(bo);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.ShipBase.Should().Be(1m);
			response.ShipMethodID.Should().Be(1);
			response.ShipRate.Should().Be(1m);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALShipMethodMapper();
			ShipMethod entity = new ShipMethod();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1, 1m);

			BOShipMethod response = mapper.MapEFToBO(entity);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.ShipBase.Should().Be(1m);
			response.ShipMethodID.Should().Be(1);
			response.ShipRate.Should().Be(1m);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALShipMethodMapper();
			ShipMethod entity = new ShipMethod();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1, 1m);

			List<BOShipMethod> response = mapper.MapEFToBO(new List<ShipMethod>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e1393647bbc16a2b20f92be5bb2a8991</Hash>
</Codenesium>*/