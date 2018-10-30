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
    public class ListGroupItemsBatchUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestListGroupItems()
        {
            Request[] requests = {
                new ListGroupItems("entity_id")
            };

            BatchResponse batchResponse = await client.SendAsync(new Batch(requests));
            Assert.Equal(200, (int)batchResponse.StatusCodes.ElementAt(0));
            Assert.Single(((IEnumerable<GroupItem>) batchResponse[0]));
            Assert.Equal ("entity_id",((IEnumerable<GroupItem>) batchResponse[0]).ElementAt(0).ItemId);
            Assert.Equal ("item",((IEnumerable<GroupItem>) batchResponse[0]).ElementAt(0).ItemType);
        }
    }
}
