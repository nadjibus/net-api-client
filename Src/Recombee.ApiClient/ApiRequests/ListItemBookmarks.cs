/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using System.Net.Http;
using Recombee.ApiClient.Util;


namespace Recombee.ApiClient.ApiRequests
{
    /// <summary>List item bookmarks</summary>
    /// <remarks>List all the ever-made bookmarks of a given item.</remarks>
    public class ListItemBookmarks : Request
    {
        /// <summary>ID of the item of which the bookmarks are to be listed.
        /// </summary>
        public string ItemId { get; }

        /// <summary>Construct the request</summary>
        /// <param name="itemId">ID of the item of which the bookmarks are to be listed.
        /// </param>
        public ListItemBookmarks (string itemId): base(HttpMethod.Get, 100000)
        {
            this.ItemId = itemId;
        }
    
        /// <returns>URI to the endpoint including path parameters</returns>
        public override string Path()
        {
            return string.Format("/items/{0}/bookmarks/", ItemId);
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
        
            };
            return parameters;
        }
    
    }
}
