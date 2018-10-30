using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Recombee.ApiClient.Bindings
{
    /// <summary>Binding encapsulating responses to a batch request</summary>
    public class BatchResponse: RecombeeBinding
    {
        public IEnumerable<object> Responses { get; }

        public IEnumerable<HttpStatusCode> StatusCodes { get; }

        /// <summary>Get i-th reponse. If the sub-request failed, throws the appropriate exception.</summary>
        public object this[int index]
        {
            get
            {
                var res = Responses.ElementAt(index);
                if(res is Exception)
                    throw (Exception)res;
                return res;
            }
        }

        public BatchResponse(IEnumerable<object> responses, IEnumerable<HttpStatusCode> statusCodes)
        {
            this.Responses = responses;
            this.StatusCodes = statusCodes;
        }
    }
}
