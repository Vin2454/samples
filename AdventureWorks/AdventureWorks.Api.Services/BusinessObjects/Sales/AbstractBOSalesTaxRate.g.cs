using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOSalesTaxRate: AbstractBusinessObject
        {
                public AbstractBOSalesTaxRate() : base()
                {
                }

                public virtual void SetProperties(int salesTaxRateID,
                                                  DateTime modifiedDate,
                                                  string name,
                                                  Guid rowguid,
                                                  int stateProvinceID,
                                                  decimal taxRate,
                                                  int taxType)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                        this.SalesTaxRateID = salesTaxRateID;
                        this.StateProvinceID = stateProvinceID;
                        this.TaxRate = taxRate;
                        this.TaxType = taxType;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public Guid Rowguid { get; private set; }

                public int SalesTaxRateID { get; private set; }

                public int StateProvinceID { get; private set; }

                public decimal TaxRate { get; private set; }

                public int TaxType { get; private set; }
        }
}

/*<Codenesium>
    <Hash>51e579919281444d2cff103c7bbea213</Hash>
</Codenesium>*/