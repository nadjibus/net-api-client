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
    public class ListGroupsBatchUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestListGroups()
        {
            Request[] requests = {
                new ListGroups()
            };

            BatchResponse batchResponse = await client.SendAsync(new Batch(requests));
            Assert.Equal(200, (int)batchResponse.StatusCodes.ElementAt(0));
            Assert.Equal (new Group[]{new Group("entity_id")},((IEnumerable<Group>) batchResponse[0]));
        }
    }
}
