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
    public class ListItemPropertiesUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestListItemProperties()
        {
            ListItemProperties req;
            Request req2;
            IEnumerable<PropertyInfo> resp;
            // it 'lists properties'
            req = new ListItemProperties();
            resp = await client.SendAsync(req);
            Assert.Equal(2, resp.Count());
        }
    }
}
