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
    public class ListItemDetailViewsBatchUnitTest: InteractionsUnitTest
    {

        [Fact]
        public async void TestListItemDetailViews()
        {
            Request[] requests = {
                new ListItemDetailViews("item")
            };

            BatchResponse batchResponse = await client.SendAsync(new Batch(requests));
            Assert.Equal(200, (int)batchResponse.StatusCodes.ElementAt(0));
            Assert.Single(((IEnumerable<DetailView>) batchResponse[0]));
            Assert.Equal ("item",((IEnumerable<DetailView>) batchResponse[0]).ElementAt(0).ItemId);
            Assert.Equal ("user",((IEnumerable<DetailView>) batchResponse[0]).ElementAt(0).UserId);
        }
    }
}
