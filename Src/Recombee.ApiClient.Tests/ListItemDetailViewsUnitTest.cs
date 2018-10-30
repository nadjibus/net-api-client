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
    public class ListItemDetailViewsUnitTest: InteractionsUnitTest
    {

        [Fact]
        public async void TestListItemDetailViews()
        {
            ListItemDetailViews req;
            Request req2;
            IEnumerable<DetailView> resp;
            // it 'lists interactions'
            req = new ListItemDetailViews("item");
            resp = await client.SendAsync(req);
            Assert.Single(resp);
            Assert.Equal ("item",resp.ElementAt(0).ItemId);
            Assert.Equal ("user",resp.ElementAt(0).UserId);
        }
    }
}
