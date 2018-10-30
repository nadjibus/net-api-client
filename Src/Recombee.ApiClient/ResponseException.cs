using Recombee.ApiClient.ApiRequests;

namespace Recombee.ApiClient
{
    /// <summary>Exception thrown when a request did not succeed (did not return 200 or 201)</summary>
    public class ResponseException: ApiException
    {
        /// <summary>Request which failed</summary>
        public Request FailedRequest { get; }

        /// <summary>Obtained HTTP status code</summary>
        public System.Net.HttpStatusCode StatusCode { get; }

        /// <summary>Create the exception</summary>
        /// <param name="request">Request which caused the exception</param>
        /// <param name="statusCode">Resulting status code from API</param>
        /// <param name="message">Error message from the API</param>
        public ResponseException(Request request, System.Net.HttpStatusCode statusCode, string message): base(message)
        {
            this.FailedRequest = request;
            this.StatusCode = statusCode;
        }
    }
}