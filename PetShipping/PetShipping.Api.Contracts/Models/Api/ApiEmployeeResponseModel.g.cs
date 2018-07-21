using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiEmployeeResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string firstName,
                        bool isSalesPerson,
                        bool isShipper,
                        string lastName)
                {
                        this.Id = id;
                        this.FirstName = firstName;
                        this.IsSalesPerson = isSalesPerson;
                        this.IsShipper = isShipper;
                        this.LastName = lastName;
                }

                [Required]
                [JsonProperty]
                public string FirstName { get; private set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public bool IsSalesPerson { get; private set; }

                [Required]
                [JsonProperty]
                public bool IsShipper { get; private set; }

                [Required]
                [JsonProperty]
                public string LastName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a2fe153245f0fe48a13db2229e9ae3e6</Hash>
</Codenesium>*/