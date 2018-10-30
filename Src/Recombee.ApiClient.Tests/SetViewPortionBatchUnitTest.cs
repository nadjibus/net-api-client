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
    public class SetViewPortionBatchUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestSetViewPortion()
        {
            Request[] requests = {
                new SetViewPortion("u_id","i_id",1,cascadeCreate: true),
                new SetViewPortion("entity_id","entity_id",0),
                new SetViewPortion("entity_id","nonex_id",1),
                new SetViewPortion("nonex_id","entity_id",0.5),
                new SetViewPortion("entity_id","entity_id",0,timestamp: UnixTimeStampToDateTime(-15)),
                new SetViewPortion("entity_id","entity_id",-2),
                new SetViewPortion("entity_id","entity_id",0.7,sessionId: "a****")
            };

            BatchResponse batchResponse = await client.SendAsync(new Batch(requests));
            Assert.Equal(200, (int)batchResponse.StatusCodes.ElementAt(0));
            Assert.Equal(200, (int)batchResponse.StatusCodes.ElementAt(1));
            Assert.Equal(404, (int)batchResponse.StatusCodes.ElementAt(2));
            Assert.Equal(404, (int)batchResponse.StatusCodes.ElementAt(3));
            Assert.Equal(400, (int)batchResponse.StatusCodes.ElementAt(4));
            Assert.Equal(400, (int)batchResponse.StatusCodes.ElementAt(5));
            Assert.Equal(400, (int)batchResponse.StatusCodes.ElementAt(6));
        }
    }
}
