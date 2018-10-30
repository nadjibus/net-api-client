/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using System.Net.Http;
using Recombee.ApiClient.Util;


namespace Recombee.ApiClient.ApiRequests
{
    /// <summary>Set view portion</summary>
    /// <remarks>Sets viewed portion of an item (for example a video or article) by a user (at a session).
    /// If you send new request with the same (`userId`, `itemId`, `sessionId`), the portion gets updated.
    /// </remarks>
    public class SetViewPortion : Request
    {
        /// <summary>User who viewed a portion of the item</summary>
        public string UserId { get; }

        /// <summary>Viewed item</summary>
        public string ItemId { get; }

        /// <summary>Viewed portion of the item (number between 0.0 (viewed nothing) and 1.0 (viewed full item) ). It should be the really viewed part of the item, no matter seeking, so for example if the user seeked immediately to half of the item and then viewed 10% of the item, the `portion` should still be `0.1`.</summary>
        public double Portion { get; }

        /// <summary>ID of session in which the user viewed the item. Default is `null` (`None`, `nil`, `NULL` etc. depending on language).</summary>
        public string SessionId { get; }

        /// <summary>UTC timestamp of the rating as ISO8601-1 pattern or UTC epoch time. The default value is the current time.</summary>
        public DateTime? Timestamp { get; }

        /// <summary>Sets whether the given user/item should be created if not present in the database.</summary>
        public bool? CascadeCreate { get; }

        /// <summary>If this view portion is based on a recommendation request, `recommId` is the id of the clicked recommendation.</summary>
        public string RecommId { get; }

        /// <summary>Construct the request</summary>
        /// <param name="userId">User who viewed a portion of the item</param>
        /// <param name="itemId">Viewed item</param>
        /// <param name="portion">Viewed portion of the item (number between 0.0 (viewed nothing) and 1.0 (viewed full item) ). It should be the really viewed part of the item, no matter seeking, so for example if the user seeked immediately to half of the item and then viewed 10% of the item, the `portion` should still be `0.1`.</param>
        /// <param name="sessionId">ID of session in which the user viewed the item. Default is `null` (`None`, `nil`, `NULL` etc. depending on language).</param>
        /// <param name="timestamp">UTC timestamp of the rating as ISO8601-1 pattern or UTC epoch time. The default value is the current time.</param>
        /// <param name="cascadeCreate">Sets whether the given user/item should be created if not present in the database.</param>
        /// <param name="recommId">If this view portion is based on a recommendation request, `recommId` is the id of the clicked recommendation.</param>
        public SetViewPortion (string userId, string itemId, double portion, string sessionId = null, DateTime? timestamp = null, bool? cascadeCreate = null, string recommId = null): base(HttpMethod.Post, 10000)
        {
            this.UserId = userId;
            this.ItemId = itemId;
            this.Portion = portion;
            this.SessionId = sessionId;
            this.Timestamp = timestamp;
            this.CascadeCreate = cascadeCreate;
            this.RecommId = recommId;
        }
    
        /// <returns>URI to the endpoint including path parameters</returns>
        public override string Path()
        {
            return "/viewportions/";
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
                {"itemId", ItemId},
                {"portion", Portion}
            };
            if (SessionId != null)
                parameters["sessionId"] = SessionId;
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
