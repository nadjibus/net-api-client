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
    public class DeleteViewPortionUnitTest: InteractionsUnitTest
    {

        [Fact]
        public async void TestDeleteViewPortion()
        {
            DeleteViewPortion req;
            Request req2;
            RecombeeBinding resp;
            // it 'does not fail with existing entity id'
            req = new DeleteViewPortion("user","item");
            resp = await client.SendAsync(req);
            req = new DeleteViewPortion("user","item");
            try
            {
                await client.SendAsync(req);
                Assert.True(false,"No exception thrown");
            }
            catch (ResponseException ex)
            {
                Assert.Equal(404, (int)ex.StatusCode);
            }
        }
    }
}
