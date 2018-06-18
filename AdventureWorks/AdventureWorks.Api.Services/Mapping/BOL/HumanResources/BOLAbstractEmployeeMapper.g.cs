using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractEmployeeMapper
        {
                public virtual BOEmployee MapModelToBO(
                        int businessEntityID,
                        ApiEmployeeRequestModel model
                        )
                {
                        BOEmployee boEmployee = new BOEmployee();

                        boEmployee.SetProperties(
                                businessEntityID,
                                model.BirthDate,
                                model.CurrentFlag,
                                model.Gender,
                                model.HireDate,
                                model.JobTitle,
                                model.LoginID,
                                model.MaritalStatus,
                                model.ModifiedDate,
                                model.NationalIDNumber,
                                model.OrganizationLevel,
                                model.Rowguid,
                                model.SalariedFlag,
                                model.SickLeaveHours,
                                model.VacationHours);
                        return boEmployee;
                }

                public virtual ApiEmployeeResponseModel MapBOToModel(
                        BOEmployee boEmployee)
                {
                        var model = new ApiEmployeeResponseModel();

                        model.SetProperties(boEmployee.BirthDate, boEmployee.BusinessEntityID, boEmployee.CurrentFlag, boEmployee.Gender, boEmployee.HireDate, boEmployee.JobTitle, boEmployee.LoginID, boEmployee.MaritalStatus, boEmployee.ModifiedDate, boEmployee.NationalIDNumber, boEmployee.OrganizationLevel, boEmployee.Rowguid, boEmployee.SalariedFlag, boEmployee.SickLeaveHours, boEmployee.VacationHours);

                        return model;
                }

                public virtual List<ApiEmployeeResponseModel> MapBOToModel(
                        List<BOEmployee> items)
                {
                        List<ApiEmployeeResponseModel> response = new List<ApiEmployeeResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>adc4a21cc54937228c1cc5fa6ab15917</Hash>
</Codenesium>*/