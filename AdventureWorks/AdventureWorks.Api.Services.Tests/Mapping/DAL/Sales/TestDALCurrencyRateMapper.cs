using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CurrencyRate")]
	[Trait("Area", "DALMapper")]
	public class TestDALCurrencyRateMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALCurrencyRateMapper();
			var bo = new BOCurrencyRate();
			bo.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			CurrencyRate response = mapper.MapBOToEF(bo);

			response.AverageRate.Should().Be(1m);
			response.CurrencyRateDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.CurrencyRateID.Should().Be(1);
			response.EndOfDayRate.Should().Be(1m);
			response.FromCurrencyCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ToCurrencyCode.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALCurrencyRateMapper();
			CurrencyRate entity = new CurrencyRate();
			entity.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			BOCurrencyRate response = mapper.MapEFToBO(entity);

			response.AverageRate.Should().Be(1m);
			response.CurrencyRateDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.CurrencyRateID.Should().Be(1);
			response.EndOfDayRate.Should().Be(1m);
			response.FromCurrencyCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ToCurrencyCode.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALCurrencyRateMapper();
			CurrencyRate entity = new CurrencyRate();
			entity.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			List<BOCurrencyRate> response = mapper.MapEFToBO(new List<CurrencyRate>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>07371c3e432772478179c83c201673ce</Hash>
</Codenesium>*/