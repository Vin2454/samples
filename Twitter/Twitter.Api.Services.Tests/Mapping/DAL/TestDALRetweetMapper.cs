using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Retweet")]
	[Trait("Area", "DALMapper")]
	public class TestDALRetweetMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALRetweetMapper();
			var bo = new BORetweet();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"), 1);

			Retweet response = mapper.MapBOToEF(bo);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.RetwitterUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.TweetTweetId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALRetweetMapper();
			Retweet entity = new Retweet();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("0"), 1);

			BORetweet response = mapper.MapEFToBO(entity);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.RetwitterUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.TweetTweetId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALRetweetMapper();
			Retweet entity = new Retweet();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("0"), 1);

			List<BORetweet> response = mapper.MapEFToBO(new List<Retweet>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b34a264f3a49a644944c7c4dc972a483</Hash>
</Codenesium>*/