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
    public class SetViewPortionUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestSetViewPortion()
        {
            SetViewPortion req;
            Request req2;
            RecombeeBinding resp;
            // it 'does not fail with cascadeCreate'
            req = new SetViewPortion("u_id","i_id",1,cascadeCreate: true);
            resp = await client.SendAsync(req);
            // it 'does not fail with existing item and user'
            req = new SetViewPortion("entity_id","entity_id",0);
            resp = await client.SendAsync(req);
            // it 'fails with nonexisting item id'
            req = new SetViewPortion("entity_id","nonex_id",1);
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
            req = new SetViewPortion("nonex_id","entity_id",0.5);
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
            req = new SetViewPortion("entity_id","entity_id",0,timestamp: UnixTimeStampToDateTime(-15));
            try
            {
                await client.SendAsync(req);
                Assert.True(false,"No exception thrown");
            }
            catch (ResponseException ex)
            {
                Assert.Equal(400, (int)ex.StatusCode);
            }
            // it 'fails with invalid portion'
            req = new SetViewPortion("entity_id","entity_id",-2);
            try
            {
                await client.SendAsync(req);
                Assert.True(false,"No exception thrown");
            }
            catch (ResponseException ex)
            {
                Assert.Equal(400, (int)ex.StatusCode);
            }
            // it 'fails with invalid sessionId'
            req = new SetViewPortion("entity_id","entity_id",0.7,sessionId: "a****");
            try
            {
                await client.SendAsync(req);
                Assert.True(false,"No exception thrown");
            }
            catch (ResponseException ex)
            {
                Assert.Equal(400, (int)ex.StatusCode);
            }
        }
    }
}
