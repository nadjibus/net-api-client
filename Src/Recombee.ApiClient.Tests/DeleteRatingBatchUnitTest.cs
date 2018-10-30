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
    public class DeleteRatingBatchUnitTest: InteractionsUnitTest
    {

        [Fact]
        public async void TestDeleteRating()
        {
            Request[] requests = {
                new DeleteRating("user","item",timestamp: UnixTimeStampToDateTime(0)),
                new DeleteRating("user","item")
            };

            BatchResponse batchResponse = await client.SendAsync(new Batch(requests));
            Assert.Equal(200, (int)batchResponse.StatusCodes.ElementAt(0));
            Assert.Equal(404, (int)batchResponse.StatusCodes.ElementAt(1));
        }
    }
}
