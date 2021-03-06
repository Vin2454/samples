using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Tweet")]
	[Trait("Area", "Integration")]
	public class TweetIntegrationTests
	{
		public TweetIntegrationTests()
		{
		}

		[Fact]
		public async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			await client.TweetDeleteAsync(1);

			var response = await this.CreateRecord(client);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			ApiTweetResponseModel model = await client.TweetGetAsync(1);

			ApiTweetModelMapper mapper = new ApiTweetModelMapper();

			UpdateResponse<ApiTweetResponseModel> updateResponse = await client.TweetUpdateAsync(model.TweetId, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
		}

		[Fact]
		public async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			var createModel = new ApiTweetRequestModel();
			createModel.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("1"), 1);
			CreateResponse<ApiTweetResponseModel> createResult = await client.TweetCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiTweetResponseModel getResponse = await client.TweetGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.TweetDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiTweetResponseModel verifyResponse = await client.TweetGetAsync(2);

			verifyResponse.Should().BeNull();
		}

		[Fact]
		public async void TestGet()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiTweetResponseModel response = await client.TweetGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			List<ApiTweetResponseModel> response = await client.TweetAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTweetResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiTweetRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("1"), 1);
			CreateResponse<ApiTweetResponseModel> result = await client.TweetCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>cca853da202e45a7e533c730af702e9b</Hash>
</Codenesium>*/