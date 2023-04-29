using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace DotNetReplaceUrlDoubleSlash.Api.Test.Shared
{
    public abstract class IntegrationTestBase
    {
        protected static HttpClient client;

        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            var factory = new WebApplicationFactory<Program>();
            client = factory.CreateClient();
        }
    }
}
