using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DirectTweet")]
	[Trait("Area", "DALMapper")]
	public class TestDALDirectTweetMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALDirectTweetMapper();
			var bo = new BODirectTweet();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"));

			DirectTweet response = mapper.MapBOToEF(bo);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TaggedUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.TweetId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALDirectTweetMapper();
			DirectTweet entity = new DirectTweet();
			entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"), 1);

			BODirectTweet response = mapper.MapEFToBO(entity);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TaggedUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.TweetId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALDirectTweetMapper();
			DirectTweet entity = new DirectTweet();
			entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"), 1);

			List<BODirectTweet> response = mapper.MapEFToBO(new List<DirectTweet>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>31c7c32a623918323274fe8ef10fb8d4</Hash>
</Codenesium>*/