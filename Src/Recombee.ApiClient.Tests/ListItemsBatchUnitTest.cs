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
    public class ListItemsBatchUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestListItems()
        {
            Request[] requests = {
                new ListItems(),
                new ListItems()
            };

            BatchResponse batchResponse = await client.SendAsync(new Batch(requests));
            Assert.Equal(200, (int)batchResponse.StatusCodes.ElementAt(0));
            Assert.Equal (new Item[]{new Item("entity_id")},((IEnumerable<Item>) batchResponse[0]));
            Assert.Equal(200, (int)batchResponse.StatusCodes.ElementAt(1));
            Assert.Single(((IEnumerable<Item>) batchResponse[1]));
        }
    }
}
