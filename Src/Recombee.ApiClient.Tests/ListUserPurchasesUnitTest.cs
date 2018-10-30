/*
 This file is auto-generated, do not edit
*/


using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Recombee.ApiClient.ApiRequests;
using Recombee.ApiClient.Bindings;

namespace Recombee.ApiClient.Tests
{
    public class ListUserPurchasesUnitTest: InteractionsUnitTest
    {

        [Fact]
        public async void TestListUserPurchases()
        {
            ListUserPurchases req;
            Request req2;
            IEnumerable<Purchase> resp;
            // it 'lists user interactions'
            req = new ListUserPurchases("user");
            resp = await client.SendAsync(req);
            Assert.Single(resp);
            Assert.Equal ("item",resp.ElementAt(0).ItemId);
            Assert.Equal ("user",resp.ElementAt(0).UserId);
        }
    }
}
