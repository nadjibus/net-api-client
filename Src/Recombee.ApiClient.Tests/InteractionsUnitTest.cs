using Recombee.ApiClient.ApiRequests;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Recombee.ApiClient.Tests
{
    public class InteractionsUnitTest : RecombeeUnitTest
    {
        public InteractionsUnitTest()
        {
            Batch requests = new Batch(new Request[]{
                    new AddUser("user"),
                    new AddItem("item"),
                    new AddDetailView("user", "item", timestamp: UnixTimeStampToDateTime(0)),
                    new AddPurchase("user", "item", timestamp: UnixTimeStampToDateTime(0)),
                    new AddRating("user", "item", 1, timestamp: UnixTimeStampToDateTime(0)),
                    new AddCartAddition("user", "item", timestamp: UnixTimeStampToDateTime(0)),
                    new AddBookmark("user", "item", timestamp: UnixTimeStampToDateTime(0)),
                    new SetViewPortion("user", "item", 1, timestamp: UnixTimeStampToDateTime(0))
                });

            client.SendAsync(requests).Wait();

            Task.Delay(10000).Wait();
        }
    }
}
