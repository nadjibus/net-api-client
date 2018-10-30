using System.Linq;
using Xunit;
using Recombee.ApiClient.ApiRequests;
using Recombee.ApiClient.Bindings;

namespace Recombee.ApiClient.Tests
{
    public class GetItemValuesBatchUnitTest: RecombeeUnitTest
    {

        [Fact]
        public async void TestGetItemValues()
        {
            Request[] requests = {
                new GetItemValues("entity_id")
            };

            BatchResponse batchResponse = await client.SendAsync(new Batch(requests));
            Assert.Equal(200, (int)batchResponse.StatusCodes.ElementAt(0));
            Assert.Equal ((long)42,(long)((Item) batchResponse[0]).Values["int_property"]);
            Assert.Equal ("hello",((Item) batchResponse[0]).Values["str_property"]);
        }
    }
}
