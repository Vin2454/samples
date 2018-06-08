using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiScrapReasonResponseModel: AbstractApiResponseModel
        {
                public ApiScrapReasonResponseModel() : base()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        short scrapReasonID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ScrapReasonID = scrapReasonID;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public short ScrapReasonID { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeScrapReasonIDValue { get; set; } = true;

                public bool ShouldSerializeScrapReasonID()
                {
                        return this.ShouldSerializeScrapReasonIDValue;
                }

                public void DisableAllFields()
                {
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeScrapReasonIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>89fe1d4a829f18624ae6e953749abdd7</Hash>
</Codenesium>*/