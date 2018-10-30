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
    public class ListUsersUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestListUsers()
        {
            ListUsers req;
            Request req2;
            IEnumerable<User> resp;
            // it 'lists entities'
            req = new ListUsers();
            resp = await client.SendAsync(req);
            Assert.Equal (new User[]{new User("entity_id")},resp);
            // it 'return properties'
            req = new ListUsers();
            resp = await client.SendAsync(req);
            Assert.Single(resp);
        }
    }
}
