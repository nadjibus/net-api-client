/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using Recombee.ApiClient.Util;

namespace Recombee.ApiClient.Bindings
{
    /// <summary>DetailView Binding</summary>
    public class DetailView: RecombeeBinding {
        /// <summary>User who viewed the item</summary>
        public string UserId { get; }

        /// <summary>Viewed item</summary>
        public string ItemId { get; }

        [JsonConverter(typeof(EpochJsonReader))]
        private readonly DateTime? _timestamp;
        /// <summary>UTC timestamp of the view as ISO8601-1 pattern or UTC epoch time. The default value is the current time.</summary>
        [JsonConverter(typeof(EpochJsonReader))]
        public DateTime? Timestamp
        {
            get {return _timestamp;}
        }

        /// <summary>Duration of the view</summary>
        public long? Duration { get; }

        /// <summary>If this detail view is based on a recommendation request, `recommId` is the id of the clicked recommendation.</summary>
        public string RecommId { get; }

        public DetailView (string userId, string itemId, DateTime? timestamp = null, long? duration = null, string recommId = null)
        {
            this.UserId = userId;
            this.ItemId = itemId;
            this._timestamp = timestamp;
            this.Duration = duration;
            this.RecommId = recommId;
        }
    
        /// <summary>Determines whether the specified object is equal to the current object</summary>
        /// <param name="obj">The object to compare with the current object</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false</returns>
        public override bool Equals(Object obj)
        {
             if (!(obj is DetailView))
                 return false;
             if (obj == this)
                 return true;
        
             DetailView that = (DetailView) obj;
             return new EqualsBuilder<DetailView>(this, that)
                .With(m => m.UserId)
                .With(m => m.ItemId)
                .With(m => m.Timestamp)
                .With(m => m.Duration)
                .With(m => m.RecommId)
                .Equals();
        }
        /// <summary>Hash function</summary>
        /// <returns>A hash code for the current object</returns>
        public override int GetHashCode()
        {
             return new HashCodeBuilder<DetailView>(this)
                .With(m => m.UserId)
                .With(m => m.ItemId)
                .With(m => m.Timestamp)
                .With(m => m.Duration)
                .With(m => m.RecommId)
                .HashCode;
        }
    }
    
}
