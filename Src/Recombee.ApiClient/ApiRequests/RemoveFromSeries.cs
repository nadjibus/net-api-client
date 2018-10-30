/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using System.Net.Http;
using Recombee.ApiClient.Util;


namespace Recombee.ApiClient.ApiRequests
{
    /// <summary>Remove from series</summary>
    /// <remarks>Removes an existing series item from the series.</remarks>
    public class RemoveFromSeries : Request
    {
        /// <summary>ID of the series from which a series item is to be removed.</summary>
        public string SeriesId { get; }

        /// <summary>Type of the item to be removed.</summary>
        public string ItemType { get; }

        /// <summary>ID of the item iff `itemType` is `item`. ID of the series iff `itemType` is `series`.</summary>
        public string ItemId { get; }

        /// <summary>Time index of the item to be removed.</summary>
        public double Time { get; }

        /// <summary>Construct the request</summary>
        /// <param name="seriesId">ID of the series from which a series item is to be removed.</param>
        /// <param name="itemType">Type of the item to be removed.</param>
        /// <param name="itemId">ID of the item iff `itemType` is `item`. ID of the series iff `itemType` is `series`.</param>
        /// <param name="time">Time index of the item to be removed.</param>
        public RemoveFromSeries (string seriesId, string itemType, string itemId, double time): base(HttpMethod.Delete, 10000)
        {
            this.SeriesId = seriesId;
            this.ItemType = itemType;
            this.ItemId = itemId;
            this.Time = time;
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
                {"itemType", ItemType},
                {"itemId", ItemId},
                {"time", Time}
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
