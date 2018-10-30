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
    public class ListUsersBatchUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestListUsers()
        {
            Request[] requests = {
                new ListUsers(),
                new ListUsers()
            };

            BatchResponse batchResponse = await client.SendAsync(new Batch(requests));
            Assert.Equal(200, (int)batchResponse.StatusCodes.ElementAt(0));
            Assert.Equal (new User[]{new User("entity_id")},((IEnumerable<User>) batchResponse[0]));
            Assert.Equal(200, (int)batchResponse.StatusCodes.ElementAt(1));
            Assert.Single(((IEnumerable<User>) batchResponse[1]));
        }
    }
}
