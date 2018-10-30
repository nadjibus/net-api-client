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
    public class ListUserCartAdditionsBatchUnitTest: InteractionsUnitTest
    {

        [Fact]
        public async void TestListUserCartAdditions()
        {
            Request[] requests = {
                new ListUserCartAdditions("user")
            };

            BatchResponse batchResponse = await client.SendAsync(new Batch(requests));
            Assert.Equal(200, (int)batchResponse.StatusCodes.ElementAt(0));
            Assert.Single(((IEnumerable<CartAddition>) batchResponse[0]));
            Assert.Equal ("item",((IEnumerable<CartAddition>) batchResponse[0]).ElementAt(0).ItemId);
            Assert.Equal ("user",((IEnumerable<CartAddition>) batchResponse[0]).ElementAt(0).UserId);
        }
    }
}
