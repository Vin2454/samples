using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiSaleRequestModel : AbstractApiRequestModel
        {
                public ApiSaleRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string ipAddress,
                        string notes,
                        DateTime saleDate,
                        int transactionId)
                {
                        this.IpAddress = ipAddress;
                        this.Notes = notes;
                        this.SaleDate = saleDate;
                        this.TransactionId = transactionId;
                }

                [JsonProperty]
                public string IpAddress { get; private set; }

                [JsonProperty]
                public string Notes { get; private set; }

                [JsonProperty]
                public DateTime SaleDate { get; private set; }

                [JsonProperty]
                public int TransactionId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2dfafbc0edb1b84cd0833195647a3da6</Hash>
</Codenesium>*/