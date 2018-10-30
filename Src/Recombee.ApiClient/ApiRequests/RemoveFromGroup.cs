/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using System.Net.Http;
using Recombee.ApiClient.Util;


namespace Recombee.ApiClient.ApiRequests
{
    /// <summary>Remove from group</summary>
    /// <remarks>Removes an existing group item from the group.</remarks>
    public class RemoveFromGroup : Request
    {
        /// <summary>ID of the group from which a group item is to be removed.</summary>
        public string GroupId { get; }

        /// <summary>Type of the item to be removed.</summary>
        public string ItemType { get; }

        /// <summary>ID of the item iff `itemType` is `item`. ID of the group iff `itemType` is `group`.</summary>
        public string ItemId { get; }

        /// <summary>Construct the request</summary>
        /// <param name="groupId">ID of the group from which a group item is to be removed.</param>
        /// <param name="itemType">Type of the item to be removed.</param>
        /// <param name="itemId">ID of the item iff `itemType` is `item`. ID of the group iff `itemType` is `group`.</param>
        public RemoveFromGroup (string groupId, string itemType, string itemId): base(HttpMethod.Delete, 10000)
        {
            this.GroupId = groupId;
            this.ItemType = itemType;
            this.ItemId = itemId;
        }
    
        /// <returns>URI to the endpoint including path parameters</returns>
        public override string Path()
        {
            return string.Format("/groups/{0}/items/", GroupId);
        }
    
        /// <summary>Get query parameters</summary>
        /// <returns>Dictionary containing values of query parameters (name of parameter: value of the parameter)</returns>
        public override Dictionary<string, object> QueryParameters()
        {
           var parameters =  new Dictionary<string, object>()
            {
                {"itemType", ItemType},
                {"itemId", ItemId}
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
