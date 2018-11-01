using System;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Recombee.ApiClient.ApiRequests;
using Recombee.ApiClient.Bindings;

namespace Recombee.ApiClient
{
    /// <summary>Client for sending requests to Recombee and getting replies, with Async support.</summary>
    public partial class RecombeeClient
    {
        private const string UserAgent = "recombee-.net-api-client/2.2.0";

        readonly string _databaseId;
        readonly byte[] _secretTokenBytes;
        readonly bool _useHttpsAsDefault;
        private readonly string _hostUri = "rapi.recombee.com";
        readonly int _batchMaxSize = 10000; //Maximal number of requests within one batch request
        readonly HttpClient _httpClient;


        /// <summary>Initialize the client</summary>
        /// <param name="databaseId">ID of the database.</param>
        /// <param name="secretToken">Corresponding secret token.</param>
        /// <param name="useHttpsAsDefault">If true, all requests are sent using HTTPS.</param>
        /// <param name="httpClient">If you want to use your own HttpClient instance, pass it here.</param>
        public RecombeeClient(string databaseId, string secretToken, bool useHttpsAsDefault = false, HttpClient httpClient = null)
        {
            _databaseId = databaseId;
            _secretTokenBytes = Encoding.ASCII.GetBytes(secretToken);
            _useHttpsAsDefault = useHttpsAsDefault;
            _httpClient = httpClient ?? new HttpClient();
            _hostUri = Environment.GetEnvironmentVariable("RAPI_URI") ?? _hostUri;
        }

        public async Task<StringBinding> SendAsync(Request request)
        {
            var json = await SendRequestAsync(request).ConfigureAwait(false);
            return ParseResponse(json, request);
        }

        public StringBinding ParseResponse(string json, Request request)
        {
            return new StringBinding(json);
        }

        public async Task<IEnumerable<Item>> SendAsync(ListItems request)
        {
            var json = await SendRequestAsync(request).ConfigureAwait(false);
            return ParseResponse(json, request);
        }

        public async Task<IEnumerable<User>> SendAsync(ListUsers request)
        {
            var json = await SendRequestAsync(request).ConfigureAwait(false);
            return ParseResponse(json, request);
        }

        public async Task<IEnumerable<Recommendation>> SendAsync(UserBasedRecommendation request)
        {
            var json = await SendRequestAsync(request).ConfigureAwait(false);
            return ParseResponse(json, request);
        }

        public async Task<IEnumerable<Recommendation>> SendAsync(ItemBasedRecommendation request)
        {
            var json = await SendRequestAsync(request).ConfigureAwait(false);
            return ParseResponse(json, request);
        }

        private IEnumerable<Recommendation> ParseResponse(string json, UserBasedRecommendation request)
        {
            return ParseRecommRequestResponse(json, request);
        }

        private IEnumerable<Recommendation> ParseResponse(string json, ItemBasedRecommendation request)
        {
            return ParseRecommRequestResponse(json, request);
        }

        private IEnumerable<Recommendation> ParseRecommRequestResponse(string json, Request request)
        {
            try
            {
                var strArray = JsonConvert.DeserializeObject<string[]>(json);
                return strArray.Select(x => new Recommendation(x));
            }
            catch (JsonReaderException)
            {
                //might have failed because it returned also the item properties
                var valsArray = JsonConvert.DeserializeObject<Dictionary<string, object>[]>(json);
                return valsArray.Select(vals => new Recommendation((string)vals["itemId"], vals));
            }
        }

        private IEnumerable<Item> ParseResponse(string json, ListItems request)
        {
            try
            {
                var strArray = JsonConvert.DeserializeObject<string[]>(json);
                return strArray.Select(x => new Item(x));
            }
            catch (JsonReaderException)
            {
                //might have failed because it returned also the item properties
                var valsArray = JsonConvert.DeserializeObject<Dictionary<string, object>[]>(json);
                return valsArray.Select(vals => new Item((string)vals["itemId"], vals));
            }
        }

        private IEnumerable<User> ParseResponse(string json, ListUsers request)
        {
            try
            {
                var strArray = JsonConvert.DeserializeObject<string[]>(json);
                return strArray.Select(x => new User(x));
            }
            catch (JsonReaderException)
            {
                //might have failed because it returned also the item properties
                var valsArray = JsonConvert.DeserializeObject<Dictionary<string, object>[]>(json);
                return valsArray.Select(vals => new User((string)vals["userId"], vals));
            }
        }

        public async Task<Item> SendAsync(GetItemValues request)
        {
            var json = await SendRequestAsync(request).ConfigureAwait(false);
            return ParseResponse(json, request);
        }

        private Item ParseResponse(string json, GetItemValues request)
        {
            var vals = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            return new Item(request.ItemId, vals);
        }

        public async Task<User> SendAsync(GetUserValues request)
        {
            var json = await SendRequestAsync(request).ConfigureAwait(false);
            return ParseResponse(json, request);
        }

        private User ParseResponse(string json, GetUserValues request)
        {
            var vals = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            return new User(request.UserId, vals);
        }

        private class BatchParseHelper
        {
            public int Code;
            public Newtonsoft.Json.Linq.JRaw Json;

            public BatchParseHelper()
            {
                Code = 0;
                Json = null;
            }
        }
        public async Task<BatchResponse> SendAsync(Batch request)
        {
            if (request.Requests.Count() > _batchMaxSize)
                return await SendMultipartBatchRequestAsync(request).ConfigureAwait(false);

            var json = await SendRequestAsync(request).ConfigureAwait(false);
            var partiallyParsed = JsonConvert.DeserializeObject<BatchParseHelper[]>(json);

            var resps = request.Requests.Zip(partiallyParsed, (req, res) => ParseOneBatchResponse(res.Json.ToString(), res.Code, req));
            var statusCodes = partiallyParsed.Select(res => (HttpStatusCode)res.Code);
            return new BatchResponse(resps, statusCodes);
        }

        private async Task<BatchResponse> SendMultipartBatchRequestAsync(Batch request)
        {
            var parts = request.Requests.Part(_batchMaxSize);
            var resultsTasks = parts.Select(requests => SendAsync(new Batch(requests))).ToList();
            var responsesTasksResult = await Task.WhenAll(resultsTasks).ConfigureAwait(false);
            var responses = responsesTasksResult.Select(br => br.Responses).SelectMany(x => x);
            var statusCodes = responsesTasksResult.Select(br => br.StatusCodes).SelectMany(x => x);
            return new BatchResponse(responses, statusCodes);
        }


        protected async Task<string> SendRequestAsync(Request request)
        {
            var uri = ProcessRequestUri(request);
            try
            {
                var response = await PerformHttpRequestAsync(uri, request).ConfigureAwait(false);
                var jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                CheckStatusCode(response.StatusCode, jsonString, request);
                return jsonString;
            }
            catch (AggregateException ae)
            {
                ae.Handle(x =>
                {
                    if (x is TaskCanceledException)
                        throw new TimeoutException(request, x);

                    return false;
                });
            }

            throw new InvalidOperationException("Invalid state after sending a request."); // Should never happen
        }

        private void CheckStatusCode(HttpStatusCode statusCode, string response, Request request)
        {
            var code = (int)statusCode;

            if (code >= 200 && code <= 299)
                return;

            throw new ResponseException(request, statusCode, response);
        }


        private async Task<HttpResponseMessage> PerformHttpRequestAsync(string uri, Request request)
        {
            // https://github.com/davidfowl/AspNetCoreDiagnosticScenarios/blob/93e39b8f48169cce4803615519ef87bb2a969c8e/AsyncGuidance.md#always-dispose-cancellationtokensources-used-for-timeouts

            using (var ctsTimeout = new CancellationTokenSource(request.Timeout))
            {
                var httpRequest = new HttpRequestMessage(request.RequestHttpMethod, uri);

                httpRequest.Headers.Add("User-Agent", UserAgent);

                if (httpRequest.Method == HttpMethod.Put)
                {
                    httpRequest.Content = new StringContent("");
                }
                else if (httpRequest.Method == HttpMethod.Post)
                {
                    var requestBody = JsonConvert.SerializeObject(request.BodyParameters());
                    httpRequest.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                }

                try
                {
                    return await _httpClient.SendAsync(httpRequest, ctsTimeout.Token);
                }
                catch (TaskCanceledException ex)
                {
                    throw new TimeoutException(request, ex);
                }
            }
        }

        private string StripLeadingQuestionMark(string query)
        {
            if (query.Length > 0 && query[0] == '?')
            {
                return query.Substring(1);
            }
            return query;
        }

        private string ProcessRequestUri(Request request)
        {
            var uriBuilder = new UriBuilder();

            uriBuilder.Path = string.Format("/{0}{1}", _databaseId, request.Path());
            uriBuilder.Query = QueryParameters(request);
            AppendHmacParameters(uriBuilder);
            uriBuilder.Scheme = request.EnsureHttps || _useHttpsAsDefault ? "https" : "http";
            uriBuilder.Host = _hostUri;

            return uriBuilder.ToString();
        }

        private string QueryParameters(Request request)
        {
            var encodedQueryStringParams = request.QueryParameters().
                Select(p => string.Format("{0}={1}", p.Key, WebUtility.UrlEncode(string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", p.Value))));
            return string.Join("&", encodedQueryStringParams);
        }

        private int UnixTimestampNow()
        {
            return (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }
        private void AppendHmacParameters(UriBuilder uriBuilder)
        {
            uriBuilder.Query = StripLeadingQuestionMark(uriBuilder.Query) + (uriBuilder.Query.Length == 0 ? "" : "&") + string.Format("hmac_timestamp={0}", UnixTimestampNow());
            using (var myHmacSha1 = new HMACSHA1(_secretTokenBytes))
            {
                var uriToBeSigned = uriBuilder.Path + uriBuilder.Query;
                var hmacBytes = myHmacSha1.ComputeHash(Encoding.ASCII.GetBytes(uriToBeSigned));
                var hmacRes = BitConverter.ToString(hmacBytes).Replace("-", "");
                uriBuilder.Query = StripLeadingQuestionMark(uriBuilder.Query) + string.Format("&hmac_sign={0}", hmacRes);
            }
        }
    }
}
