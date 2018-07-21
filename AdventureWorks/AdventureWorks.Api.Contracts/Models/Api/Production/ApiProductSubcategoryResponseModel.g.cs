using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductSubcategoryResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int productSubcategoryID,
                        DateTime modifiedDate,
                        string name,
                        int productCategoryID,
                        Guid rowguid)
                {
                        this.ProductSubcategoryID = productSubcategoryID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ProductCategoryID = productCategoryID;
                        this.Rowguid = rowguid;
                }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public int ProductCategoryID { get; private set; }

                [JsonProperty]
                public int ProductSubcategoryID { get; private set; }

                [JsonProperty]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b120fa7f8668d5e6ffd100fc48ab584d</Hash>
</Codenesium>*/