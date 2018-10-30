/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using System.Net.Http;
using Recombee.ApiClient.Util;


namespace Recombee.ApiClient.ApiRequests
{
    /// <summary>Get user property info</summary>
    /// <remarks>Gets information about specified user property.
    /// </remarks>
    public class GetUserPropertyInfo : Request
    {
        /// <summary>Name of the property about which the information is to be retrieved.</summary>
        public string PropertyName { get; }

        /// <summary>Construct the request</summary>
        /// <param name="propertyName">Name of the property about which the information is to be retrieved.</param>
        public GetUserPropertyInfo (string propertyName): base(HttpMethod.Get, 100000)
        {
            this.PropertyName = propertyName;
        }
    
        /// <returns>URI to the endpoint including path parameters</returns>
        public override string Path()
        {
            return string.Format("/users/properties/{0}", PropertyName);
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
