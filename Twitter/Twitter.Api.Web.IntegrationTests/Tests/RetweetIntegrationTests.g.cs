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
	[Trait("Table", "Retweet")]
	[Trait("Area", "Integration")]
	public class RetweetIntegrationTests
	{
		public RetweetIntegrationTests()
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

			await client.RetweetDeleteAsync(1);

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

			ApiRetweetResponseModel model = await client.RetweetGetAsync(1);

			ApiRetweetModelMapper mapper = new ApiRetweetModelMapper();

			UpdateResponse<ApiRetweetResponseModel> updateResponse = await client.RetweetUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiRetweetRequestModel();
			createModel.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("1"), 1);
			CreateResponse<ApiRetweetResponseModel> createResult = await client.RetweetCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiRetweetResponseModel getResponse = await client.RetweetGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.RetweetDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiRetweetResponseModel verifyResponse = await client.RetweetGetAsync(2);

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
			ApiRetweetResponseModel response = await client.RetweetGetAsync(1);

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

			List<ApiRetweetResponseModel> response = await client.RetweetAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiRetweetResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiRetweetRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("1"), 1);
			CreateResponse<ApiRetweetResponseModel> result = await client.RetweetCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>820795cba5c30dee38e256da06b6153c</Hash>
</Codenesium>*/