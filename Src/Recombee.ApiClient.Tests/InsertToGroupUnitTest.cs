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
    public class InsertToGroupUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestInsertToGroup()
        {
            InsertToGroup req;
            Request req2;
            RecombeeBinding resp;
            // it 'does not fail when inserting existing item into existing set'
            req2 = new AddItem("new_item");
            await client.SendAsync(req2);
            req = new InsertToGroup("entity_id","item","new_item");
            resp = await client.SendAsync(req);
            // it 'does not fail when cascadeCreate is used'
            req = new InsertToGroup("new_set","item","new_item2",cascadeCreate: true);
            resp = await client.SendAsync(req);
            // it 'really inserts item to the set'
            req2 = new AddItem("new_item3");
            await client.SendAsync(req2);
            req = new InsertToGroup("entity_id","item","new_item3");
            resp = await client.SendAsync(req);
            try
            {
                await client.SendAsync(req);
                Assert.True(false,"No exception thrown");
            }
            catch (ResponseException ex)
            {
                Assert.Equal(409, (int)ex.StatusCode);
            }
        }
    }
}
