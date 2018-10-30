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
    public class ListItemBookmarksBatchUnitTest: InteractionsUnitTest
    {

        [Fact]
        public async void TestListItemBookmarks()
        {
            Request[] requests = {
                new ListItemBookmarks("item")
            };

            BatchResponse batchResponse = await client.SendAsync(new Batch(requests));
            Assert.Equal(200, (int)batchResponse.StatusCodes.ElementAt(0));
            Assert.Single(((IEnumerable<Bookmark>) batchResponse[0]));
            Assert.Equal ("item",((IEnumerable<Bookmark>) batchResponse[0]).ElementAt(0).ItemId);
            Assert.Equal ("user",((IEnumerable<Bookmark>) batchResponse[0]).ElementAt(0).UserId);
        }
    }
}
