using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PurchaseOrderHeader")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLPurchaseOrderHeaderActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLPurchaseOrderHeaderMapper();

                        ApiPurchaseOrderHeaderRequestModel model = new ApiPurchaseOrderHeaderRequestModel();

                        model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1);
                        BOPurchaseOrderHeader response = mapper.MapModelToBO(1, model);

                        response.EmployeeID.Should().Be(1);
                        response.Freight.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.RevisionNumber.Should().Be(1);
                        response.ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ShipMethodID.Should().Be(1);
                        response.Status.Should().Be(1);
                        response.SubTotal.Should().Be(1);
                        response.TaxAmt.Should().Be(1);
                        response.TotalDue.Should().Be(1);
                        response.VendorID.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLPurchaseOrderHeaderMapper();

                        BOPurchaseOrderHeader bo = new BOPurchaseOrderHeader();

                        bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1);
                        ApiPurchaseOrderHeaderResponseModel response = mapper.MapBOToModel(bo);

                        response.EmployeeID.Should().Be(1);
                        response.Freight.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PurchaseOrderID.Should().Be(1);
                        response.RevisionNumber.Should().Be(1);
                        response.ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ShipMethodID.Should().Be(1);
                        response.Status.Should().Be(1);
                        response.SubTotal.Should().Be(1);
                        response.TaxAmt.Should().Be(1);
                        response.TotalDue.Should().Be(1);
                        response.VendorID.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLPurchaseOrderHeaderMapper();

                        BOPurchaseOrderHeader bo = new BOPurchaseOrderHeader();

                        bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1);
                        List<ApiPurchaseOrderHeaderResponseModel> response = mapper.MapBOToModel(new List<BOPurchaseOrderHeader>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>ea8a291b15de78c66b9279ad4906a759</Hash>
</Codenesium>*/