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
    public class AddItemUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestAddItem()
        {
            AddItem req;
            Request req2;
            RecombeeBinding resp;
            // it 'does not fail with valid entity id'
            req = new AddItem("valid_id");
            resp = await client.SendAsync(req);
            // it 'fails with invalid entity id'
            req = new AddItem("$$$not_valid$$$");
            try
            {
                await client.SendAsync(req);
                Assert.True(false,"No exception thrown");
            }
            catch (ResponseException ex)
            {
                Assert.Equal(400, (int)ex.StatusCode);
            }
            // it 'really stores entity to the system'
            req = new AddItem("valid_id2");
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
