using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiClientRequestModel : AbstractApiRequestModel
        {
                public ApiClientRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string email,
                        string firstName,
                        string lastName,
                        string notes,
                        string phone)
                {
                        this.Email = email;
                        this.FirstName = firstName;
                        this.LastName = lastName;
                        this.Notes = notes;
                        this.Phone = phone;
                }

                [JsonProperty]
                public string Email { get; private set; }

                [JsonProperty]
                public string FirstName { get; private set; }

                [JsonProperty]
                public string LastName { get; private set; }

                [JsonProperty]
                public string Notes { get; private set; }

                [JsonProperty]
                public string Phone { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8d2e249c3081d0550b5d412c692f7119</Hash>
</Codenesium>*/