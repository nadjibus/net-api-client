/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using System.Net.Http;
using Recombee.ApiClient.Util;


namespace Recombee.ApiClient.ApiRequests
{
    /// <summary>Add rating</summary>
    /// <remarks>Adds a rating of given item made by a given user.
    /// </remarks>
    public class AddRating : Request
    {
        /// <summary>User who submitted the rating</summary>
        public string UserId { get; }

        /// <summary>Rated item</summary>
        public string ItemId { get; }

        /// <summary>UTC timestamp of the rating as ISO8601-1 pattern or UTC epoch time. The default value is the current time.</summary>
        public DateTime? Timestamp { get; }

        /// <summary>Rating rescaled to interval [-1.0,1.0], where -1.0 means the worst rating possible, 0.0 means neutral, and 1.0 means absolutely positive rating. For example, in the case of 5-star evaluations, rating = (numStars-3)/2 formula may be used for the conversion.</summary>
        public double Rating { get; }

        /// <summary>Sets whether the given user/item should be created if not present in the database.</summary>
        public bool? CascadeCreate { get; }

        /// <summary>If this rating is based on a recommendation request, `recommId` is the id of the clicked recommendation.</summary>
        public string RecommId { get; }

        /// <summary>Construct the request</summary>
        /// <param name="userId">User who submitted the rating</param>
        /// <param name="itemId">Rated item</param>
        /// <param name="timestamp">UTC timestamp of the rating as ISO8601-1 pattern or UTC epoch time. The default value is the current time.</param>
        /// <param name="rating">Rating rescaled to interval [-1.0,1.0], where -1.0 means the worst rating possible, 0.0 means neutral, and 1.0 means absolutely positive rating. For example, in the case of 5-star evaluations, rating = (numStars-3)/2 formula may be used for the conversion.</param>
        /// <param name="cascadeCreate">Sets whether the given user/item should be created if not present in the database.</param>
        /// <param name="recommId">If this rating is based on a recommendation request, `recommId` is the id of the clicked recommendation.</param>
        public AddRating (string userId, string itemId, double rating, DateTime? timestamp = null, bool? cascadeCreate = null, string recommId = null): base(HttpMethod.Post, 10000)
        {
            this.UserId = userId;
            this.ItemId = itemId;
            this.Timestamp = timestamp;
            this.Rating = rating;
            this.CascadeCreate = cascadeCreate;
            this.RecommId = recommId;
        }
    
        /// <returns>URI to the endpoint including path parameters</returns>
        public override string Path()
        {
            return "/ratings/";
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
                {"userId", UserId},
                {"itemId", ItemId},
                {"rating", Rating}
            };
            if (Timestamp.HasValue)
                parameters["timestamp"] = ConvertToUnixTimestamp(Timestamp.Value);
            if (CascadeCreate.HasValue)
                parameters["cascadeCreate"] = CascadeCreate.Value;
            if (RecommId != null)
                parameters["recommId"] = RecommId;
            return parameters;
        }
    
    }
}
