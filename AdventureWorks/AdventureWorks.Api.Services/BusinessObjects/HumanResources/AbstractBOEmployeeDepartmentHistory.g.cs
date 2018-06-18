using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOEmployeeDepartmentHistory: AbstractBusinessObject
        {
                public AbstractBOEmployeeDepartmentHistory() : base()
                {
                }

                public virtual void SetProperties(int businessEntityID,
                                                  short departmentID,
                                                  Nullable<DateTime> endDate,
                                                  DateTime modifiedDate,
                                                  int shiftID,
                                                  DateTime startDate)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.DepartmentID = departmentID;
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.ShiftID = shiftID;
                        this.StartDate = startDate;
                }

                public int BusinessEntityID { get; private set; }

                public short DepartmentID { get; private set; }

                public Nullable<DateTime> EndDate { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ShiftID { get; private set; }

                public DateTime StartDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ddb1e465eb2362d083549815f30b3a15</Hash>
</Codenesium>*/