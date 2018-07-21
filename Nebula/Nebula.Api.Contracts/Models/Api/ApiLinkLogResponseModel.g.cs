using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiLinkLogResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        DateTime dateEntered,
                        int linkId,
                        string log)
                {
                        this.Id = id;
                        this.DateEntered = dateEntered;
                        this.LinkId = linkId;
                        this.Log = log;

                        this.LinkIdEntity = nameof(ApiResponse.Links);
                }

                [Required]
                [JsonProperty]
                public DateTime DateEntered { get; private set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public int LinkId { get; private set; }

                [JsonProperty]
                public string LinkIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public string Log { get; private set; }
        }
}

/*<Codenesium>
    <Hash>bbfcd16cbf9ec4c46576df3621f752a2</Hash>
</Codenesium>*/