/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using System.Net.Http;
using Recombee.ApiClient.Util;


namespace Recombee.ApiClient.ApiRequests
{
    /// <summary>Insert to group</summary>
    /// <remarks>Inserts an existing item/group into group of given `groupId`.
    /// </remarks>
    public class InsertToGroup : Request
    {
        /// <summary>ID of the group to be inserted into.</summary>
        public string GroupId { get; }

        /// <summary>`item` iff the regular item from the catalog is to be inserted, `group` iff group is inserted as the item.</summary>
        public string ItemType { get; }

        /// <summary>ID of the item iff `itemType` is `item`. ID of the group iff `itemType` is `group`.</summary>
        public string ItemId { get; }

        /// <summary>Indicates that any non-existing entity specified within the request should be created (as is corresponding PUT requests were invoked). This concerns both the `groupId` and the `groupId`. If `cascadeCreate` is set true, the behavior also depends on the `itemType`. Either items or group may be created if not present in the database.</summary>
        public bool? CascadeCreate { get; }

        /// <summary>Construct the request</summary>
        /// <param name="groupId">ID of the group to be inserted into.</param>
        /// <param name="itemType">`item` iff the regular item from the catalog is to be inserted, `group` iff group is inserted as the item.</param>
        /// <param name="itemId">ID of the item iff `itemType` is `item`. ID of the group iff `itemType` is `group`.</param>
        /// <param name="cascadeCreate">Indicates that any non-existing entity specified within the request should be created (as is corresponding PUT requests were invoked). This concerns both the `groupId` and the `groupId`. If `cascadeCreate` is set true, the behavior also depends on the `itemType`. Either items or group may be created if not present in the database.</param>
        public InsertToGroup (string groupId, string itemType, string itemId, bool? cascadeCreate = null): base(HttpMethod.Post, 10000)
        {
            this.GroupId = groupId;
            this.ItemType = itemType;
            this.ItemId = itemId;
            this.CascadeCreate = cascadeCreate;
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
        
            };
            return parameters;
        }
    
        /// <summary>Get body parameters</summary>
        /// <returns>Dictionary containing  values of body parameters (name of parameter: value of the parameter)</returns>
        public override Dictionary<string, object> BodyParameters()
        {
           var parameters =  new Dictionary<string, object>()
            {
                {"itemType", ItemType},
                {"itemId", ItemId}
            };
            if (CascadeCreate.HasValue)
                parameters["cascadeCreate"] = CascadeCreate.Value;
            return parameters;
        }
    
    }
}
