using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPipelineResponseModel: AbstractApiResponseModel
        {
                public ApiPipelineResponseModel() : base()
                {
                }

                public void SetProperties(
                        int id,
                        int pipelineStatusId,
                        int saleId)
                {
                        this.Id = id;
                        this.PipelineStatusId = pipelineStatusId;
                        this.SaleId = saleId;

                        this.PipelineStatusIdEntity = nameof(ApiResponse.PipelineStatus);
                }

                public int Id { get; private set; }

                public int PipelineStatusId { get; private set; }

                public string PipelineStatusIdEntity { get; set; }

                public int SaleId { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePipelineStatusIdValue { get; set; } = true;

                public bool ShouldSerializePipelineStatusId()
                {
                        return this.ShouldSerializePipelineStatusIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSaleIdValue { get; set; } = true;

                public bool ShouldSerializeSaleId()
                {
                        return this.ShouldSerializeSaleIdValue;
                }

                public void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializePipelineStatusIdValue = false;
                        this.ShouldSerializeSaleIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>a18f31c1312ecaacfbc73e9364a4c4a4</Hash>
</Codenesium>*/