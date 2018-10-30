using System.Collections.Generic;
using System.Linq;
using Xunit;
using Recombee.ApiClient.ApiRequests;

namespace Recombee.ApiClient.Tests
{
    public class BatchUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestLargeBatch()
        {
            await client.SendAsync(new AddItemProperty("batch_test", "boolean"));
            const int NUM_ITEMS = 14783;
            var reqs = Enumerable.Range(0, NUM_ITEMS).Select(i => new SetItemValues(string.Format("item-{0}", i),
                                                                new Dictionary<string, object>{{"batch_test", true}},
                                                                cascadeCreate: true));

            var responses = await client.SendAsync(new Batch(reqs));
            Assert.Equal(NUM_ITEMS, responses.Responses.Count());
            foreach(var statusCode in responses.StatusCodes)
                Assert.Equal(200, (int)statusCode);
        }
    }
}
