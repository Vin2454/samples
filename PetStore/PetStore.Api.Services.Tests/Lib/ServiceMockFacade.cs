using Microsoft.Extensions.Logging;
using Moq;

namespace PetStoreNS.Api.Services.Tests
{
      public class ServiceMockFacade<T> : AbstractServiceMockFacade<T>
        where T : class
    {
    }
}