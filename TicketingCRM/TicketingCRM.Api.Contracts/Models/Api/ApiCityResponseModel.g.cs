using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiCityResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string name,
                        int provinceId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.ProvinceId = provinceId;

                        this.ProvinceIdEntity = nameof(ApiResponse.Provinces);
                }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }

                [Required]
                [JsonProperty]
                public int ProvinceId { get; private set; }

                [JsonProperty]
                public string ProvinceIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>cca310fad75f2a846dadb086679c5458</Hash>
</Codenesium>*/