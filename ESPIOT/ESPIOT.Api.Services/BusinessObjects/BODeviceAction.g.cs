using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace ESPIOTNS.Api.Services
{
	public partial class BODeviceAction: AbstractBusinessObject
	{
		public BODeviceAction() : base()
		{}

		public void SetProperties(int id,
		                          int deviceId,
		                          string name,
		                          string @value)
		{
			this.DeviceId = deviceId.ToInt();
			this.Id = id.ToInt();
			this.Name = name;
			this.@Value = @value;
		}

		public int DeviceId { get; private set; }
		public int Id { get; private set; }
		public string Name { get; private set; }
		public string @Value { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9feae50d5b602b621d0498242125af32</Hash>
</Codenesium>*/