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
    public class RecommendItemsToUserUnitTest: RecommendationUnitTest
    {

        [Fact]
        public async void TestRecommendItemsToUser()
        {
            RecommendItemsToUser req;
            Request req2;
            RecommendationResponse resp;
            // it 'recommends'
            req = new RecommendItemsToUser("entity_id",9);
            resp = await client.SendAsync(req);
            // it 'recommends to previously nonexisting entity with cascadeCreate'
            req = new RecommendItemsToUser("nonexisting",9,cascadeCreate: true);
            resp = await client.SendAsync(req);
            // it 'recommends with expert settings'
            req = new RecommendItemsToUser("nonexisting2",9,cascadeCreate: true,expertSettings: new Dictionary<string, object>(){});
            resp = await client.SendAsync(req);
        }
    }
}
