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
    public class MergeUsersBatchUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestMergeUsers()
        {
            Request[] requests = {
                new AddUser("target"),
                new MergeUsers("target","entity_id"),
                new MergeUsers("nonex_id","entity_id")
            };

            BatchResponse batchResponse = await client.SendAsync(new Batch(requests));
            Assert.Equal(201, (int)batchResponse.StatusCodes.ElementAt(0));
            Assert.Equal(200, (int)batchResponse.StatusCodes.ElementAt(1));
            Assert.Equal(404, (int)batchResponse.StatusCodes.ElementAt(2));
        }
    }
}
