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
    public class ListItemsUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestListItems()
        {
            ListItems req;
            Request req2;
            IEnumerable<Item> resp;
            // it 'lists entities'
            req = new ListItems();
            resp = await client.SendAsync(req);
            Assert.Equal (new Item[]{new Item("entity_id")},resp);
            // it 'return properties'
            req = new ListItems();
            resp = await client.SendAsync(req);
            Assert.Single(resp);
        }
    }
}
