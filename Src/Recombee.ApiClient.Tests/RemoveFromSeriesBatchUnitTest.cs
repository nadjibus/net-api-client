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
    public class RemoveFromSeriesBatchUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestRemoveFromSeries()
        {
            Request[] requests = {
                new RemoveFromSeries("entity_id","item","entity_id",0),
                new RemoveFromSeries("entity_id","item","entity_id",1),
                new RemoveFromSeries("entity_id","item","not_contained",1)
            };

            BatchResponse batchResponse = await client.SendAsync(new Batch(requests));
            Assert.Equal(404, (int)batchResponse.StatusCodes.ElementAt(0));
            Assert.Equal(200, (int)batchResponse.StatusCodes.ElementAt(1));
            Assert.Equal(404, (int)batchResponse.StatusCodes.ElementAt(2));
        }
    }
}
