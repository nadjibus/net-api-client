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
    public class RecommendItemsToUserBatchUnitTest: RecommendationUnitTest
    {

        [Fact]
        public async void TestRecommendItemsToUser()
        {
            Request[] requests = {
                new RecommendItemsToUser("entity_id",9),
                new RecommendItemsToUser("nonexisting",9,cascadeCreate: true),
                new RecommendItemsToUser("nonexisting2",9,cascadeCreate: true,expertSettings: new Dictionary<string, object>(){})
            };

            BatchResponse batchResponse = await client.SendAsync(new Batch(requests));
            Assert.Equal(200, (int)batchResponse.StatusCodes.ElementAt(0));
            Assert.Equal(200, (int)batchResponse.StatusCodes.ElementAt(1));
            Assert.Equal(200, (int)batchResponse.StatusCodes.ElementAt(2));
        }
    }
}
