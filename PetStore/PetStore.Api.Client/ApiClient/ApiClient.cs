using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.Client
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
    <Hash>ac1135652844b87222c06c58022bb702</Hash>
</Codenesium>*/