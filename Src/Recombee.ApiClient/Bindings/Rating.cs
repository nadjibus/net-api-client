/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using Recombee.ApiClient.Util;

namespace Recombee.ApiClient.Bindings
{
    /// <summary>Rating Binding</summary>
    public class Rating: RecombeeBinding {
        /// <summary>User who submitted the rating</summary>
        public string UserId { get; }

        /// <summary>Rated item</summary>
        public string ItemId { get; }

        [JsonConverter(typeof(EpochJsonReader))]
        private readonly DateTime? _timestamp;
        /// <summary>UTC timestamp of the rating as ISO8601-1 pattern or UTC epoch time. The default value is the current time.</summary>
        [JsonConverter(typeof(EpochJsonReader))]
        public DateTime? Timestamp
        {
            get {return _timestamp;}
        }

        /// <summary>Rating rescaled to interval [-1.0,1.0], where -1.0 means the worst rating possible, 0.0 means neutral, and 1.0 means absolutely positive rating. For example, in the case of 5-star evaluations, rating = (numStars-3)/2 formula may be used for the conversion.</summary>
        public double RatingValue { get; }

        /// <summary>If this rating is based on a recommendation request, `recommId` is the id of the clicked recommendation.</summary>
        public string RecommId { get; }

        public Rating (string userId, string itemId, double rating, DateTime? timestamp = null, string recommId = null)
        {
            this.UserId = userId;
            this.ItemId = itemId;
            this._timestamp = timestamp;
            this.RatingValue = rating;
            this.RecommId = recommId;
        }
    
        /// <summary>Determines whether the specified object is equal to the current object</summary>
        /// <param name="obj">The object to compare with the current object</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false</returns>
        public override bool Equals(Object obj)
        {
             if (!(obj is Rating))
                 return false;
             if (obj == this)
                 return true;
        
             Rating that = (Rating) obj;
             return new EqualsBuilder<Rating>(this, that)
                .With(m => m.UserId)
                .With(m => m.ItemId)
                .With(m => m.Timestamp)
                .With(m => m.RatingValue)
                .With(m => m.RecommId)
                .Equals();
        }
        /// <summary>Hash function</summary>
        /// <returns>A hash code for the current object</returns>
        public override int GetHashCode()
        {
             return new HashCodeBuilder<Rating>(this)
                .With(m => m.UserId)
                .With(m => m.ItemId)
                .With(m => m.Timestamp)
                .With(m => m.RatingValue)
                .With(m => m.RecommId)
                .HashCode;
        }
    }
    
}
