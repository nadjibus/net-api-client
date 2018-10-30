/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using System.Net.Http;
using Recombee.ApiClient.Util;


namespace Recombee.ApiClient.ApiRequests
{
    /// <summary>List item cart additions</summary>
    /// <remarks>List all the ever-made cart addition of a given item.</remarks>
    public class ListItemCartAdditions : Request
    {
        /// <summary>ID of the item of which the cart addition are to be listed.
        /// </summary>
        public string ItemId { get; }

        /// <summary>Construct the request</summary>
        /// <param name="itemId">ID of the item of which the cart addition are to be listed.
        /// </param>
        public ListItemCartAdditions (string itemId): base(HttpMethod.Get, 100000)
        {
            this.ItemId = itemId;
        }
    
        /// <returns>URI to the endpoint including path parameters</returns>
        public override string Path()
        {
            return string.Format("/items/{0}/cartadditions/", ItemId);
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
