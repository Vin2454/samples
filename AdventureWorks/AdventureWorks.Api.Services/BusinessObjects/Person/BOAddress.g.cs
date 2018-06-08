using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOAddress: AbstractBusinessObject
        {
                public BOAddress() : base()
                {
                }

                public void SetProperties(int addressID,
                                          string addressLine1,
                                          string addressLine2,
                                          string city,
                                          DateTime modifiedDate,
                                          string postalCode,
                                          Guid rowguid,
                                          int stateProvinceID)
                {
                        this.AddressID = addressID;
                        this.AddressLine1 = addressLine1;
                        this.AddressLine2 = addressLine2;
                        this.City = city;
                        this.ModifiedDate = modifiedDate;
                        this.PostalCode = postalCode;
                        this.Rowguid = rowguid;
                        this.StateProvinceID = stateProvinceID;
                }

                public int AddressID { get; private set; }

                public string AddressLine1 { get; private set; }

                public string AddressLine2 { get; private set; }

                public string City { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string PostalCode { get; private set; }

                public Guid Rowguid { get; private set; }

                public int StateProvinceID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>3d00510151e954293cc3e28b81aab8fc</Hash>
</Codenesium>*/