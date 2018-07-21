using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiCustomerResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string email,
                        string firstName,
                        string lastName,
                        string phone)
                {
                        this.Id = id;
                        this.Email = email;
                        this.FirstName = firstName;
                        this.LastName = lastName;
                        this.Phone = phone;
                }

                [Required]
                [JsonProperty]
                public string Email { get; private set; }

                [Required]
                [JsonProperty]
                public string FirstName { get; private set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string LastName { get; private set; }

                [Required]
                [JsonProperty]
                public string Phone { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ed70b791a5e88d5de46e638b016ee39c</Hash>
</Codenesium>*/