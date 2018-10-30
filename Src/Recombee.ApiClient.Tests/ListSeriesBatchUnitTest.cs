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
    public class ListSeriesBatchUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestListSeries()
        {
            Request[] requests = {
                new ListSeries()
            };

            BatchResponse batchResponse = await client.SendAsync(new Batch(requests));
            Assert.Equal(200, (int)batchResponse.StatusCodes.ElementAt(0));
            Assert.Equal (new Series[]{new Series("entity_id")},((IEnumerable<Series>) batchResponse[0]));
        }
    }
}
