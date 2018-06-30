using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductCostHistoryRequestModel : AbstractApiRequestModel
        {
                public ApiProductCostHistoryRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime? endDate,
                        DateTime modifiedDate,
                        decimal standardCost,
                        DateTime startDate)
                {
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.StandardCost = standardCost;
                        this.StartDate = startDate;
                }

                private DateTime? endDate;

                public DateTime? EndDate
                {
                        get
                        {
                                return this.endDate;
                        }

                        set
                        {
                                this.endDate = value;
                        }
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private decimal standardCost;

                [Required]
                public decimal StandardCost
                {
                        get
                        {
                                return this.standardCost;
                        }

                        set
                        {
                                this.standardCost = value;
                        }
                }

                private DateTime startDate;

                [Required]
                public DateTime StartDate
                {
                        get
                        {
                                return this.startDate;
                        }

                        set
                        {
                                this.startDate = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>0295e1f4948bab6a30c68eb98e1a20df</Hash>
</Codenesium>*/