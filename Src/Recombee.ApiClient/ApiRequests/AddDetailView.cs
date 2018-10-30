/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using System.Net.Http;
using Recombee.ApiClient.Util;


namespace Recombee.ApiClient.ApiRequests
{
    /// <summary>Add detail view</summary>
    /// <remarks>Adds a detail view of a given item made by a given user.
    /// </remarks>
    public class AddDetailView : Request
    {
        /// <summary>User who viewed the item</summary>
        public string UserId { get; }

        /// <summary>Viewed item</summary>
        public string ItemId { get; }

        /// <summary>UTC timestamp of the view as ISO8601-1 pattern or UTC epoch time. The default value is the current time.</summary>
        public DateTime? Timestamp { get; }

        /// <summary>Duration of the view</summary>
        public long? Duration { get; }

        /// <summary>Sets whether the given user/item should be created if not present in the database.</summary>
        public bool? CascadeCreate { get; }

        /// <summary>If this detail view is based on a recommendation request, `recommId` is the id of the clicked recommendation.</summary>
        public string RecommId { get; }

        /// <summary>Construct the request</summary>
        /// <param name="userId">User who viewed the item</param>
        /// <param name="itemId">Viewed item</param>
        /// <param name="timestamp">UTC timestamp of the view as ISO8601-1 pattern or UTC epoch time. The default value is the current time.</param>
        /// <param name="duration">Duration of the view</param>
        /// <param name="cascadeCreate">Sets whether the given user/item should be created if not present in the database.</param>
        /// <param name="recommId">If this detail view is based on a recommendation request, `recommId` is the id of the clicked recommendation.</param>
        public AddDetailView (string userId, string itemId, DateTime? timestamp = null, long? duration = null, bool? cascadeCreate = null, string recommId = null): base(HttpMethod.Post, 10000)
        {
            this.UserId = userId;
            this.ItemId = itemId;
            this.Timestamp = timestamp;
            this.Duration = duration;
            this.CascadeCreate = cascadeCreate;
            this.RecommId = recommId;
        }
    
        /// <returns>URI to the endpoint including path parameters</returns>
        public override string Path()
        {
            return "/detailviews/";
        }
    
        /// <summary>Get query parameters</summary>
        /// <returns>Dictionary containing values of query parameters (name of parameter: value of the parameter)</returns>
        public override Dictionary<string, object> QueryParameters()
        {
           var parameters =  new Dictionary<string, object>()
            {
        
            };
            return parameters;
        }
    
        /// <summary>Get body parameters</summary>
        /// <returns>Dictionary containing  values of body parameters (name of parameter: value of the parameter)</returns>
        public override Dictionary<string, object> BodyParameters()
        {
           var parameters =  new Dictionary<string, object>()
            {
                {"userId", UserId},
                {"itemId", ItemId}
            };
            if (Timestamp.HasValue)
                parameters["timestamp"] = ConvertToUnixTimestamp(Timestamp.Value);
            if (Duration.HasValue)
                parameters["duration"] = Duration.Value;
            if (CascadeCreate.HasValue)
                parameters["cascadeCreate"] = CascadeCreate.Value;
            if (RecommId != null)
                parameters["recommId"] = RecommId;
            return parameters;
        }
    
    }
}
