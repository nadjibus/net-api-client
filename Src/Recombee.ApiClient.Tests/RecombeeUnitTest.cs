using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Recombee.ApiClient.ApiRequests;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace Recombee.ApiClient.Tests
{
    public class RecombeeUnitTest
    {
        protected RecombeeClient client;
        
        public RecombeeUnitTest()
        {
            InitClient();
        }

        private void InitClient()
        {
            client = new RecombeeClient("client-test", "jGGQ6ZKa8rQ1zTAyxTc0EMn55YPF7FJLUtaMLhbsGxmvwxgTwXYqmUk5xVZFw98L");

            client.SendAsync(new ResetDatabase()).Wait();
            var retryCount = 0;

            do
            {
                try
                {
                    // To make sure databse has been reset and is ready
                    client.SendAsync(new AddItemProperty("int_property", "int")).Wait();
                    Task.Delay(TimeSpan.FromSeconds(5)).Wait();
                    break;
                }
                catch (Exception ex)
                {
                    retryCount++;
                    if (retryCount > 10)
                        throw ex;
                }


            } while (true);

            

            Batch requests = new Batch(new Request[]{
                new AddItemProperty("str_property", "string"),

                new AddUserProperty("int_property", "int"),
                new AddUserProperty("str_property", "string"),

                new SetItemValues("entity_id", new Dictionary<string, object>()
                {
                    {"int_property", 42},
                    {"str_property", "hello"}
                }, cascadeCreate: true),
                new SetUserValues("entity_id", new Dictionary<string, object>()
                {
                    {"int_property", 42},
                    {"str_property", "hello"}
                }, cascadeCreate: true),

                new AddSeries("entity_id"),
                new AddGroup("entity_id"),
                new InsertToGroup("entity_id", "item", "entity_id"),
                new InsertToSeries("entity_id", "item", "entity_id", 1),
            });

            client.SendAsync(requests).Wait();

            Task.Delay(20000).Wait();

        }

        protected DateTime ParseDateTime(string dateStr)
        {
            return DateTime.Parse(dateStr, null, System.Globalization.DateTimeStyles.RoundtripKind);
        }

        //http://stackoverflow.com/questions/249760/how-to-convert-a-unix-timestamp-to-datetime-and-vice-versa
        public static DateTime UnixTimeStampToDateTime( double unixTimeStamp )
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds( unixTimeStamp ).ToLocalTime();
            return dtDateTime;
        }
    }
}
