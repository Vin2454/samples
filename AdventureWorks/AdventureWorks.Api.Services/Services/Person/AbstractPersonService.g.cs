using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractPersonService: AbstractService
        {
                private IPersonRepository personRepository;

                private IApiPersonRequestModelValidator personModelValidator;

                private IBOLPersonMapper bolPersonMapper;

                private IDALPersonMapper dalPersonMapper;

                private IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper;

                private IDALBusinessEntityContactMapper dalBusinessEntityContactMapper;
                private IBOLEmailAddressMapper bolEmailAddressMapper;

                private IDALEmailAddressMapper dalEmailAddressMapper;
                private IBOLPasswordMapper bolPasswordMapper;

                private IDALPasswordMapper dalPasswordMapper;
                private IBOLPersonPhoneMapper bolPersonPhoneMapper;

                private IDALPersonPhoneMapper dalPersonPhoneMapper;

                private ILogger logger;

                public AbstractPersonService(
                        ILogger logger,
                        IPersonRepository personRepository,
                        IApiPersonRequestModelValidator personModelValidator,
                        IBOLPersonMapper bolPersonMapper,
                        IDALPersonMapper dalPersonMapper

                        ,
                        IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper,
                        IDALBusinessEntityContactMapper dalBusinessEntityContactMapper
                        ,
                        IBOLEmailAddressMapper bolEmailAddressMapper,
                        IDALEmailAddressMapper dalEmailAddressMapper
                        ,
                        IBOLPasswordMapper bolPasswordMapper,
                        IDALPasswordMapper dalPasswordMapper
                        ,
                        IBOLPersonPhoneMapper bolPersonPhoneMapper,
                        IDALPersonPhoneMapper dalPersonPhoneMapper

                        )
                        : base()

                {
                        this.personRepository = personRepository;
                        this.personModelValidator = personModelValidator;
                        this.bolPersonMapper = bolPersonMapper;
                        this.dalPersonMapper = dalPersonMapper;
                        this.bolBusinessEntityContactMapper = bolBusinessEntityContactMapper;
                        this.dalBusinessEntityContactMapper = dalBusinessEntityContactMapper;
                        this.bolEmailAddressMapper = bolEmailAddressMapper;
                        this.dalEmailAddressMapper = dalEmailAddressMapper;
                        this.bolPasswordMapper = bolPasswordMapper;
                        this.dalPasswordMapper = dalPasswordMapper;
                        this.bolPersonPhoneMapper = bolPersonPhoneMapper;
                        this.dalPersonPhoneMapper = dalPersonPhoneMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPersonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.personRepository.All(limit, offset);

                        return this.bolPersonMapper.MapBOToModel(this.dalPersonMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPersonResponseModel> Get(int businessEntityID)
                {
                        var record = await this.personRepository.Get(businessEntityID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolPersonMapper.MapBOToModel(this.dalPersonMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiPersonResponseModel>> Create(
                        ApiPersonRequestModel model)
                {
                        CreateResponse<ApiPersonResponseModel> response = new CreateResponse<ApiPersonResponseModel>(await this.personModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPersonMapper.MapModelToBO(default (int), model);
                                var record = await this.personRepository.Create(this.dalPersonMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPersonMapper.MapBOToModel(this.dalPersonMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int businessEntityID,
                        ApiPersonRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.personModelValidator.ValidateUpdateAsync(businessEntityID, model));

                        if (response.Success)
                        {
                                var bo = this.bolPersonMapper.MapModelToBO(businessEntityID, model);
                                await this.personRepository.Update(this.dalPersonMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int businessEntityID)
                {
                        ActionResponse response = new ActionResponse(await this.personModelValidator.ValidateDeleteAsync(businessEntityID));

                        if (response.Success)
                        {
                                await this.personRepository.Delete(businessEntityID);
                        }

                        return response;
                }

                public async Task<List<ApiPersonResponseModel>> ByLastNameFirstNameMiddleName(string lastName, string firstName, string middleName)
                {
                        List<Person> records = await this.personRepository.ByLastNameFirstNameMiddleName(lastName, firstName, middleName);

                        return this.bolPersonMapper.MapBOToModel(this.dalPersonMapper.MapEFToBO(records));
                }
                public async Task<List<ApiPersonResponseModel>> ByAdditionalContactInfo(string additionalContactInfo)
                {
                        List<Person> records = await this.personRepository.ByAdditionalContactInfo(additionalContactInfo);

                        return this.bolPersonMapper.MapBOToModel(this.dalPersonMapper.MapEFToBO(records));
                }
                public async Task<List<ApiPersonResponseModel>> ByDemographics(string demographics)
                {
                        List<Person> records = await this.personRepository.ByDemographics(demographics);

                        return this.bolPersonMapper.MapBOToModel(this.dalPersonMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContacts(int personID, int limit = int.MaxValue, int offset = 0)
                {
                        List<BusinessEntityContact> records = await this.personRepository.BusinessEntityContacts(personID, limit, offset);

                        return this.bolBusinessEntityContactMapper.MapBOToModel(this.dalBusinessEntityContactMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiEmailAddressResponseModel>> EmailAddresses(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        List<EmailAddress> records = await this.personRepository.EmailAddresses(businessEntityID, limit, offset);

                        return this.bolEmailAddressMapper.MapBOToModel(this.dalEmailAddressMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiPasswordResponseModel>> Passwords(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        List<Password> records = await this.personRepository.Passwords(businessEntityID, limit, offset);

                        return this.bolPasswordMapper.MapBOToModel(this.dalPasswordMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiPersonPhoneResponseModel>> PersonPhones(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        List<PersonPhone> records = await this.personRepository.PersonPhones(businessEntityID, limit, offset);

                        return this.bolPersonPhoneMapper.MapBOToModel(this.dalPersonPhoneMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>d2340cfd77bc10221607f24a3a4afff9</Hash>
</Codenesium>*/