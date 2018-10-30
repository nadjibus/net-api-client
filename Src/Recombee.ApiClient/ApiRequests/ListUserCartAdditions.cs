/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using System.Net.Http;
using Recombee.ApiClient.Util;


namespace Recombee.ApiClient.ApiRequests
{
    /// <summary>List user cart additions</summary>
    /// <remarks>List all the cart additions ever made by a given user.</remarks>
    public class ListUserCartAdditions : Request
    {
        /// <summary>ID of the user whose cart additions are to be listed.</summary>
        public string UserId { get; }

        /// <summary>Construct the request</summary>
        /// <param name="userId">ID of the user whose cart additions are to be listed.</param>
        public ListUserCartAdditions (string userId): base(HttpMethod.Get, 100000)
        {
            this.UserId = userId;
        }
    
        /// <returns>URI to the endpoint including path parameters</returns>
        public override string Path()
        {
            return string.Format("/users/{0}/cartadditions/", UserId);
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
