using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using ESPIOTNS.Api.DataAccess;
using ESPIOTNS.Api.Services;

namespace ESPIOTNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "DeviceAction")]
        [Trait("Area", "DALMapper")]
        public class TestDALDeviceActionActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALDeviceActionMapper();

                        var bo = new BODeviceAction();

                        bo.SetProperties(1, 1, "A", "A");

                        DeviceAction response = mapper.MapBOToEF(bo);

                        response.DeviceId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.@Value.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALDeviceActionMapper();

                        DeviceAction entity = new DeviceAction();

                        entity.SetProperties(1, 1, "A", "A");

                        BODeviceAction  response = mapper.MapEFToBO(entity);

                        response.DeviceId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.@Value.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALDeviceActionMapper();

                        DeviceAction entity = new DeviceAction();

                        entity.SetProperties(1, 1, "A", "A");

                        List<BODeviceAction> response = mapper.MapEFToBO(new List<DeviceAction>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>d261d5eabc2431930895f055ce3bb86e</Hash>
</Codenesium>*/