using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.Client
{
        public class ApiClient: AbstractApiClient
        {
                public ApiClient(string apiUrl) : base(apiUrl, "1.0")
                {
                }

                public ApiClient(HttpClient client) : base(client)
                {
                }
        }
}

/*<Codenesium>
    <Hash>09d35ded91c6da7d8bc57377074e8e0c</Hash>
</Codenesium>*/