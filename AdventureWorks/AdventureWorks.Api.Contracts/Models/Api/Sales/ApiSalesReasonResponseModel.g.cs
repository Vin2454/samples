using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesReasonResponseModel: AbstractApiResponseModel
        {
                public ApiSalesReasonResponseModel() : base()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        string reasonType,
                        int salesReasonID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ReasonType = reasonType;
                        this.SalesReasonID = salesReasonID;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public string ReasonType { get; private set; }

                public int SalesReasonID { get; private set; }

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
                public bool ShouldSerializeReasonTypeValue { get; set; } = true;

                public bool ShouldSerializeReasonType()
                {
                        return this.ShouldSerializeReasonTypeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSalesReasonIDValue { get; set; } = true;

                public bool ShouldSerializeSalesReasonID()
                {
                        return this.ShouldSerializeSalesReasonIDValue;
                }

                public void DisableAllFields()
                {
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeReasonTypeValue = false;
                        this.ShouldSerializeSalesReasonIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>1678640456dfd7156e20a9bd806df249</Hash>
</Codenesium>*/