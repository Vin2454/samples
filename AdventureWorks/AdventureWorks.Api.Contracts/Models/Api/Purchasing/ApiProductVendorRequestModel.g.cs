using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductVendorRequestModel: AbstractApiRequestModel
        {
                public ApiProductVendorRequestModel() : base()
                {
                }

                public void SetProperties(
                        int averageLeadTime,
                        int businessEntityID,
                        Nullable<decimal> lastReceiptCost,
                        Nullable<DateTime> lastReceiptDate,
                        int maxOrderQty,
                        int minOrderQty,
                        DateTime modifiedDate,
                        Nullable<int> onOrderQty,
                        decimal standardPrice,
                        string unitMeasureCode)
                {
                        this.AverageLeadTime = averageLeadTime;
                        this.BusinessEntityID = businessEntityID;
                        this.LastReceiptCost = lastReceiptCost;
                        this.LastReceiptDate = lastReceiptDate;
                        this.MaxOrderQty = maxOrderQty;
                        this.MinOrderQty = minOrderQty;
                        this.ModifiedDate = modifiedDate;
                        this.OnOrderQty = onOrderQty;
                        this.StandardPrice = standardPrice;
                        this.UnitMeasureCode = unitMeasureCode;
                }

                private int averageLeadTime;

                [Required]
                public int AverageLeadTime
                {
                        get
                        {
                                return this.averageLeadTime;
                        }

                        set
                        {
                                this.averageLeadTime = value;
                        }
                }

                private int businessEntityID;

                [Required]
                public int BusinessEntityID
                {
                        get
                        {
                                return this.businessEntityID;
                        }

                        set
                        {
                                this.businessEntityID = value;
                        }
                }

                private Nullable<decimal> lastReceiptCost;

                public Nullable<decimal> LastReceiptCost
                {
                        get
                        {
                                return this.lastReceiptCost.IsEmptyOrZeroOrNull() ? null : this.lastReceiptCost;
                        }

                        set
                        {
                                this.lastReceiptCost = value;
                        }
                }

                private Nullable<DateTime> lastReceiptDate;

                public Nullable<DateTime> LastReceiptDate
                {
                        get
                        {
                                return this.lastReceiptDate.IsEmptyOrZeroOrNull() ? null : this.lastReceiptDate;
                        }

                        set
                        {
                                this.lastReceiptDate = value;
                        }
                }

                private int maxOrderQty;

                [Required]
                public int MaxOrderQty
                {
                        get
                        {
                                return this.maxOrderQty;
                        }

                        set
                        {
                                this.maxOrderQty = value;
                        }
                }

                private int minOrderQty;

                [Required]
                public int MinOrderQty
                {
                        get
                        {
                                return this.minOrderQty;
                        }

                        set
                        {
                                this.minOrderQty = value;
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

                private Nullable<int> onOrderQty;

                public Nullable<int> OnOrderQty
                {
                        get
                        {
                                return this.onOrderQty.IsEmptyOrZeroOrNull() ? null : this.onOrderQty;
                        }

                        set
                        {
                                this.onOrderQty = value;
                        }
                }

                private decimal standardPrice;

                [Required]
                public decimal StandardPrice
                {
                        get
                        {
                                return this.standardPrice;
                        }

                        set
                        {
                                this.standardPrice = value;
                        }
                }

                private string unitMeasureCode;

                [Required]
                public string UnitMeasureCode
                {
                        get
                        {
                                return this.unitMeasureCode;
                        }

                        set
                        {
                                this.unitMeasureCode = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>42ba4e0f5102df5f083395d2ae7d6642</Hash>
</Codenesium>*/