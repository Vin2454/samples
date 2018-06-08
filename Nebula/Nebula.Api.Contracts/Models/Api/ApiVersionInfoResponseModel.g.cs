using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiVersionInfoResponseModel: AbstractApiResponseModel
        {
                public ApiVersionInfoResponseModel() : base()
                {
                }

                public void SetProperties(
                        Nullable<DateTime> appliedOn,
                        string description,
                        long version)
                {
                        this.AppliedOn = appliedOn;
                        this.Description = description;
                        this.Version = version;
                }

                public Nullable<DateTime> AppliedOn { get; private set; }

                public string Description { get; private set; }

                public long Version { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAppliedOnValue { get; set; } = true;

                public bool ShouldSerializeAppliedOn()
                {
                        return this.ShouldSerializeAppliedOnValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDescriptionValue { get; set; } = true;

                public bool ShouldSerializeDescription()
                {
                        return this.ShouldSerializeDescriptionValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeVersionValue { get; set; } = true;

                public bool ShouldSerializeVersion()
                {
                        return this.ShouldSerializeVersionValue;
                }

                public void DisableAllFields()
                {
                        this.ShouldSerializeAppliedOnValue = false;
                        this.ShouldSerializeDescriptionValue = false;
                        this.ShouldSerializeVersionValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>1a1fe22eed6cf548603e8c74ec6a385b</Hash>
</Codenesium>*/