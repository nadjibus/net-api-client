/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using System.Net.Http;
using Recombee.ApiClient.Util;


namespace Recombee.ApiClient.ApiRequests
{
    /// <summary>Insert to series</summary>
    /// <remarks>Inserts an existing item/series into series of given seriesId at position determined by time.
    /// </remarks>
    public class InsertToSeries : Request
    {
        /// <summary>ID of the series to be inserted into.</summary>
        public string SeriesId { get; }

        /// <summary>`item` iff the regular item from the catalog is to be inserted, `series` iff series is inserted as the item.</summary>
        public string ItemType { get; }

        /// <summary>ID of the item iff `itemType` is `item`. ID of the series iff `itemType` is `series`.</summary>
        public string ItemId { get; }

        /// <summary>Time index used for sorting items in the series. According to time, items are sorted within series in ascending order. In the example of TV show episodes, the episode number is a natural choice to be passed as time.</summary>
        public double Time { get; }

        /// <summary>Indicates that any non-existing entity specified within the request should be created (as is corresponding PUT requests were invoked). This concerns both the `seriesId` and the `itemId`. If `cascadeCreate` is set true, the behavior also depends on the `itemType`. Either item or series may be created if not present in the database.</summary>
        public bool? CascadeCreate { get; }

        /// <summary>Construct the request</summary>
        /// <param name="seriesId">ID of the series to be inserted into.</param>
        /// <param name="itemType">`item` iff the regular item from the catalog is to be inserted, `series` iff series is inserted as the item.</param>
        /// <param name="itemId">ID of the item iff `itemType` is `item`. ID of the series iff `itemType` is `series`.</param>
        /// <param name="time">Time index used for sorting items in the series. According to time, items are sorted within series in ascending order. In the example of TV show episodes, the episode number is a natural choice to be passed as time.</param>
        /// <param name="cascadeCreate">Indicates that any non-existing entity specified within the request should be created (as is corresponding PUT requests were invoked). This concerns both the `seriesId` and the `itemId`. If `cascadeCreate` is set true, the behavior also depends on the `itemType`. Either item or series may be created if not present in the database.</param>
        public InsertToSeries (string seriesId, string itemType, string itemId, double time, bool? cascadeCreate = null): base(HttpMethod.Post, 10000)
        {
            this.SeriesId = seriesId;
            this.ItemType = itemType;
            this.ItemId = itemId;
            this.Time = time;
            this.CascadeCreate = cascadeCreate;
        }
    
        /// <returns>URI to the endpoint including path parameters</returns>
        public override string Path()
        {
            return string.Format("/series/{0}/items/", SeriesId);
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
                {"itemId", ItemId},
                {"time", Time}
            };
            if (CascadeCreate.HasValue)
                parameters["cascadeCreate"] = CascadeCreate.Value;
            return parameters;
        }
    
    }
}
