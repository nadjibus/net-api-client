using System;
using System.Collections.Generic;
using Xunit;
using Recombee.ApiClient;
using Recombee.ApiClient.ApiRequests;
using Recombee.ApiClient.Bindings;

namespace Recombee.ApiClient.Tests
{
    public class GetItemValuesUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestGetItemValues()
        {
            GetItemValues req = new GetItemValues("entity_id");
            Item resp = await client.SendAsync(req);
            Assert.Equal ((long)42, (long)resp.Values["int_property"]);
            Assert.Equal ("hello",resp.Values["str_property"]);
        }
    }
}
