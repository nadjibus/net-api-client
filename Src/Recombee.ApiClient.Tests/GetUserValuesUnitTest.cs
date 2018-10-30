using System;
using System.Collections.Generic;
using Xunit;
using Recombee.ApiClient;
using Recombee.ApiClient.ApiRequests;
using Recombee.ApiClient.Bindings;

namespace Recombee.ApiClient.Tests
{
    public class GetUserValuesUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestGetUserValues()
        {
            GetUserValues req = new GetUserValues("entity_id");
            User resp = await client.SendAsync(req);
            Assert.Equal ((long)42, (long)resp.Values["int_property"]);
            Assert.Equal ("hello",resp.Values["str_property"]);
        }
    }
}
