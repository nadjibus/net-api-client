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
    public class AddCartAdditionUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestAddCartAddition()
        {
            AddCartAddition req;
            Request req2;
            RecombeeBinding resp;
            // it 'does not fail with cascadeCreate'
            req = new AddCartAddition("u_id","i_id",cascadeCreate: true);
            resp = await client.SendAsync(req);
            // it 'does not fail with existing item and user'
            req = new AddCartAddition("entity_id","entity_id");
            resp = await client.SendAsync(req);
            // it 'does not fail with valid timestamp'
            req = new AddCartAddition("entity_id","entity_id",timestamp: ParseDateTime("2013-10-29T09:38:41.341Z"));
            resp = await client.SendAsync(req);
            // it 'fails with nonexisting item id'
            req = new AddCartAddition("entity_id","nonex_id");
            try
            {
                await client.SendAsync(req);
                Assert.True(false,"No exception thrown");
            }
            catch (ResponseException ex)
            {
                Assert.Equal(404, (int)ex.StatusCode);
            }
            // it 'fails with nonexisting user id'
            req = new AddCartAddition("nonex_id","entity_id");
            try
            {
                await client.SendAsync(req);
                Assert.True(false,"No exception thrown");
            }
            catch (ResponseException ex)
            {
                Assert.Equal(404, (int)ex.StatusCode);
            }
            // it 'fails with invalid time'
            req = new AddCartAddition("entity_id","entity_id",timestamp: UnixTimeStampToDateTime(-15));
            try
            {
                await client.SendAsync(req);
                Assert.True(false,"No exception thrown");
            }
            catch (ResponseException ex)
            {
                Assert.Equal(400, (int)ex.StatusCode);
            }
            // it 'really stores interaction to the system'
            req = new AddCartAddition("u_id2","i_id2",cascadeCreate: true,timestamp: UnixTimeStampToDateTime(5));
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
