using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;

using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using AdventureWorksNS.Api.Client;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
	[Trait("Integration", " TransactionHistory")]
	public class TransactionHistoryTests
	{
		private TestServer server;
		private ApiClient client;

		public TransactionHistoryTests()
		{}

		[Fact]
		public async void TestCreate()
		{
			// setup
			this.server = new TestServer(new WebHostBuilder()
			                             .UseStartup<TestStartup>());

			this.client = new ApiClient(this.server.CreateClient());
		}

		[Fact]
		public async void TestUpdate()
		{
			// setup
			this.server = new TestServer(new WebHostBuilder()
			                             .UseStartup<TestStartup>());

			this.client = new ApiClient(this.server.CreateClient());
		}

		[Fact]
		public async void TestDelete()
		{
			// setup
			this.server = new TestServer(new WebHostBuilder()
			                             .UseStartup<TestStartup>());

			this.client = new ApiClient(this.server.CreateClient());
		}

		[Fact]
		public async void TestGetById()
		{
			// setup
			this.server = new TestServer(new WebHostBuilder()
			                             .UseStartup<TestStartup>());

			this.client = new ApiClient(this.server.CreateClient());
		}

		[Fact]
		public async void TestSearch()
		{
			// setup
			this.server = new TestServer(new WebHostBuilder()
			                             .UseStartup<TestStartup>());

			this.client = new ApiClient(this.server.CreateClient());
		}

		[Fact]
		public async void TestBulkInsert()
		{
			// setup
			this.server = new TestServer(new WebHostBuilder()
			                             .UseStartup<TestStartup>());

			this.client = new ApiClient(this.server.CreateClient());
		}
	}
}

/*<Codenesium>
    <Hash>4b21e1ed39da3264f5378d028abc6eec</Hash>
</Codenesium>*/