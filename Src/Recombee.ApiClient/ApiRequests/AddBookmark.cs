/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using System.Net.Http;
using Recombee.ApiClient.Util;


namespace Recombee.ApiClient.ApiRequests
{
    /// <summary>Add bookmark</summary>
    /// <remarks>Adds a bookmark of a given item made by a given user.
    /// </remarks>
    public class AddBookmark : Request
    {
        /// <summary>User who bookmarked the item</summary>
        public string UserId { get; }

        /// <summary>Bookmarked item</summary>
        public string ItemId { get; }

        /// <summary>UTC timestamp of the bookmark as ISO8601-1 pattern or UTC epoch time. The default value is the current time.</summary>
        public DateTime? Timestamp { get; }

        /// <summary>Sets whether the given user/item should be created if not present in the database.</summary>
        public bool? CascadeCreate { get; }

        /// <summary>If this bookmark is based on a recommendation request, `recommId` is the id of the clicked recommendation.</summary>
        public string RecommId { get; }

        /// <summary>Construct the request</summary>
        /// <param name="userId">User who bookmarked the item</param>
        /// <param name="itemId">Bookmarked item</param>
        /// <param name="timestamp">UTC timestamp of the bookmark as ISO8601-1 pattern or UTC epoch time. The default value is the current time.</param>
        /// <param name="cascadeCreate">Sets whether the given user/item should be created if not present in the database.</param>
        /// <param name="recommId">If this bookmark is based on a recommendation request, `recommId` is the id of the clicked recommendation.</param>
        public AddBookmark (string userId, string itemId, DateTime? timestamp = null, bool? cascadeCreate = null, string recommId = null): base(HttpMethod.Post, 10000)
        {
            this.UserId = userId;
            this.ItemId = itemId;
            this.Timestamp = timestamp;
            this.CascadeCreate = cascadeCreate;
            this.RecommId = recommId;
        }
    
        /// <returns>URI to the endpoint including path parameters</returns>
        public override string Path()
        {
            return "/bookmarks/";
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
            if (CascadeCreate.HasValue)
                parameters["cascadeCreate"] = CascadeCreate.Value;
            if (RecommId != null)
                parameters["recommId"] = RecommId;
            return parameters;
        }
    
    }
}
