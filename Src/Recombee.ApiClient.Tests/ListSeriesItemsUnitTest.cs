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
    public class ListSeriesItemsUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestListSeriesItems()
        {
            ListSeriesItems req;
            Request req2;
            IEnumerable<SeriesItem> resp;
            // it 'lists set items'
            req = new ListSeriesItems("entity_id");
            resp = await client.SendAsync(req);
            Assert.Single(resp);
            Assert.Equal ("entity_id",resp.ElementAt(0).ItemId);
            Assert.Equal ("item",resp.ElementAt(0).ItemType);
        }
    }
}
