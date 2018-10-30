/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using System.Net.Http;
using Recombee.ApiClient.Util;


namespace Recombee.ApiClient.ApiRequests
{
    /// <summary>Delete view portion</summary>
    /// <remarks>Deletes an existing view portion specified by (`userId`, `itemId`, `sessionId`) from the database.
    /// </remarks>
    public class DeleteViewPortion : Request
    {
        /// <summary>ID of the user who rated the item.</summary>
        public string UserId { get; }

        /// <summary>ID of the item which was rated.</summary>
        public string ItemId { get; }

        /// <summary>Identifier of a session.</summary>
        public string SessionId { get; }

        /// <summary>Construct the request</summary>
        /// <param name="userId">ID of the user who rated the item.</param>
        /// <param name="itemId">ID of the item which was rated.</param>
        /// <param name="sessionId">Identifier of a session.</param>
        public DeleteViewPortion (string userId, string itemId, string sessionId = null): base(HttpMethod.Delete, 10000)
        {
            this.UserId = userId;
            this.ItemId = itemId;
            this.SessionId = sessionId;
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
                {"userId", UserId},
                {"itemId", ItemId}
            };
            if (SessionId != null)
                parameters["sessionId"] = SessionId;
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
