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
    public class AddItemPropertyUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestAddItemProperty()
        {
            AddItemProperty req;
            Request req2;
            RecombeeBinding resp;
            // it 'does not fail with valid name and type'
            req = new AddItemProperty("number","int");
            resp = await client.SendAsync(req);
            req = new AddItemProperty("str","string");
            resp = await client.SendAsync(req);
            // it 'fails with invalid type'
            req = new AddItemProperty("prop","integer");
            try
            {
                await client.SendAsync(req);
                Assert.True(false,"No exception thrown");
            }
            catch (ResponseException ex)
            {
                Assert.Equal(400, (int)ex.StatusCode);
            }
            // it 'really stores property to the system'
            req = new AddItemProperty("number2","int");
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
