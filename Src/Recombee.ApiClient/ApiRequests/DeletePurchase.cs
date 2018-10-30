/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using System.Net.Http;
using Recombee.ApiClient.Util;


namespace Recombee.ApiClient.ApiRequests
{
    /// <summary>Delete purchase</summary>
    /// <remarks>Deletes an existing purchase uniquely specified by `userId`, `itemId`, and `timestamp` or all the purchases with given `userId` and `itemId` if `timestamp` is omitted.
    /// </remarks>
    public class DeletePurchase : Request
    {
        /// <summary>ID of the user who made the purchase.</summary>
        public string UserId { get; }

        /// <summary>ID of the item of which was purchased.</summary>
        public string ItemId { get; }

        /// <summary>Unix timestamp of the purchase. If the `timestamp` is omitted, then all the purchases with given `userId` and `itemId` are deleted.</summary>
        public DateTime? Timestamp { get; }

        /// <summary>Construct the request</summary>
        /// <param name="userId">ID of the user who made the purchase.</param>
        /// <param name="itemId">ID of the item of which was purchased.</param>
        /// <param name="timestamp">Unix timestamp of the purchase. If the `timestamp` is omitted, then all the purchases with given `userId` and `itemId` are deleted.</param>
        public DeletePurchase (string userId, string itemId, DateTime? timestamp = null): base(HttpMethod.Delete, 10000)
        {
            this.UserId = userId;
            this.ItemId = itemId;
            this.Timestamp = timestamp;
        }
    
        /// <returns>URI to the endpoint including path parameters</returns>
        public override string Path()
        {
            return "/purchases/";
        }
    
        /// <summary>Get query parameters</summary>
        /// <returns>Dictionary containing values of query parameters (name of parameter: value of the parameter)</returns>
        public override Dictionary<string, object> QueryParameters()
        {
           var parameters =  new Dictionary<string, object>()
            {
                {"userId", UserId},
                {"itemId", ItemId}
            };
            if (Timestamp.HasValue)
                parameters["timestamp"] = ConvertToUnixTimestamp(Timestamp.Value);
            return parameters;
        }
    
        /// <summary>Get body parameters</summary>
        /// <returns>Dictionary containing  values of body parameters (name of parameter: value of the parameter)</returns>
        public override Dictionary<string, object> BodyParameters()
        {
           var parameters =  new Dictionary<string, object>()
            {
        
            };
            return parameters;
        }
    
    }
}
