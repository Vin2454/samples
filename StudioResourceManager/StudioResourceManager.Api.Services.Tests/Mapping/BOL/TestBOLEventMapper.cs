using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Event")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLEventMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLEventMapper();
			ApiEventRequestModel model = new ApiEventRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");
			BOEvent response = mapper.MapModelToBO(1, model);

			response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BillAmount.Should().Be(1m);
			response.EventStatusId.Should().Be(1);
			response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.StudentNote.Should().Be("A");
			response.TeacherNote.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLEventMapper();
			BOEvent bo = new BOEvent();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");
			ApiEventResponseModel response = mapper.MapBOToModel(bo);

			response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BillAmount.Should().Be(1m);
			response.EventStatusId.Should().Be(1);
			response.Id.Should().Be(1);
			response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.StudentNote.Should().Be("A");
			response.TeacherNote.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLEventMapper();
			BOEvent bo = new BOEvent();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");
			List<ApiEventResponseModel> response = mapper.MapBOToModel(new List<BOEvent>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9e1314afada0e86d56b4ca30b578410e</Hash>
</Codenesium>*/