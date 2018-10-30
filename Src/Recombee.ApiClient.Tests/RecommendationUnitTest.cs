using Recombee.ApiClient.ApiRequests;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Recombee.ApiClient.Tests
{
    public class RecommendationUnitTest: RecombeeUnitTest
    {
        const int NUM = 1000;
        const double PROBABILITY_PURCHASED = 0.007;

        public RecommendationUnitTest()
        {
            DoRecommendationTests();
        }

        private void DoRecommendationTests()
        {
            var userIds = Enumerable.Range(0, NUM).Select(i => string.Format("user-{0}", i));
            var itemIds = Enumerable.Range(0, NUM).Select(i => string.Format("item-{0}", i));

            client.SendAsync(new Batch(new Request[]{
                    new AddItemProperty("answer", "int"),
                    new AddItemProperty("id2", "string"),
                    new AddItemProperty("empty", "string")
            })).Wait();

            var itemRequests = itemIds.Select(itemId =>
                new SetItemValues(itemId, new Dictionary<string, object>
                {
                    {"answer", 42},
                    {"id2", itemId},
                }, cascadeCreate: true)
            );

            client.SendAsync(new Batch(itemRequests)).Wait();

            client.SendAsync(new Batch(userIds.Select(id => new AddUser(id)))).Wait();

            Random r = new Random();
            var purchases = new List<Request>();
            foreach (String userId in userIds)
            {
                purchases.AddRange(
                    itemIds.Where(_ => r.NextDouble() < PROBABILITY_PURCHASED)
                        .Select(itemId => new AddPurchase(userId, itemId))
                );
            }
            client.SendAsync(new Batch(purchases)).Wait();

            Task.Delay(5000).Wait();
        }
    }
}
