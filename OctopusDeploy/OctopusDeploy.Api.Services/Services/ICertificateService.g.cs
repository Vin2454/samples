using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface ICertificateService
        {
                Task<CreateResponse<ApiCertificateResponseModel>> Create(
                        ApiCertificateRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiCertificateRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiCertificateResponseModel> Get(string id);

                Task<List<ApiCertificateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiCertificateResponseModel>> GetCreated(DateTime created);
                Task<List<ApiCertificateResponseModel>> GetDataVersion(byte[] dataVersion);
                Task<List<ApiCertificateResponseModel>> GetNotAfter(DateTime notAfter);
                Task<List<ApiCertificateResponseModel>> GetThumbprint(string thumbprint);
        }
}

/*<Codenesium>
    <Hash>b38f3614073f6d04dc1ad32991e76624</Hash>
</Codenesium>*/