/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using System.Net.Http;
using Recombee.ApiClient.Util;


namespace Recombee.ApiClient.ApiRequests
{
    /// <summary>Delete group</summary>
    /// <remarks>Deletes the group of given `groupId` from the database.
    /// Deleting a group will only delete assignment of items to it, not the items themselves!
    /// </remarks>
    public class DeleteGroup : Request
    {
        /// <summary>ID of the group to be deleted.</summary>
        public string GroupId { get; }

        /// <summary>Construct the request</summary>
        /// <param name="groupId">ID of the group to be deleted.</param>
        public DeleteGroup (string groupId): base(HttpMethod.Delete, 10000)
        {
            this.GroupId = groupId;
        }
    
        /// <returns>URI to the endpoint including path parameters</returns>
        public override string Path()
        {
            return string.Format("/groups/{0}", GroupId);
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
