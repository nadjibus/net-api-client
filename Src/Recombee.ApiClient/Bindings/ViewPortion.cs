/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using Recombee.ApiClient.Util;

namespace Recombee.ApiClient.Bindings
{
    /// <summary>ViewPortion Binding</summary>
    public class ViewPortion: RecombeeBinding {
        /// <summary>User who viewed a portion of the item</summary>
        public string UserId { get; }

        /// <summary>Viewed item</summary>
        public string ItemId { get; }

        /// <summary>Viewed portion of the item (number between 0.0 (viewed nothing) and 1.0 (viewed full item) ). It should be the really viewed part of the item, no matter seeking, so for example if the user seeked immediately to half of the item and then viewed 10% of the item, the `portion` should still be `0.1`.</summary>
        public double Portion { get; }

        /// <summary>ID of session in which the user viewed the item. Default is `null` (`None`, `nil`, `NULL` etc. depending on language).</summary>
        public string SessionId { get; }

        [JsonConverter(typeof(EpochJsonReader))]
        private readonly DateTime? _timestamp;
        /// <summary>UTC timestamp of the rating as ISO8601-1 pattern or UTC epoch time. The default value is the current time.</summary>
        [JsonConverter(typeof(EpochJsonReader))]
        public DateTime? Timestamp
        {
            get {return _timestamp;}
        }

        /// <summary>If this view portion is based on a recommendation request, `recommId` is the id of the clicked recommendation.</summary>
        public string RecommId { get; }

        public ViewPortion (string userId, string itemId, double portion, string sessionId = null, DateTime? timestamp = null, string recommId = null)
        {
            this.UserId = userId;
            this.ItemId = itemId;
            this.Portion = portion;
            this.SessionId = sessionId;
            this._timestamp = timestamp;
            this.RecommId = recommId;
        }
    
        /// <summary>Determines whether the specified object is equal to the current object</summary>
        /// <param name="obj">The object to compare with the current object</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false</returns>
        public override bool Equals(Object obj)
        {
             if (!(obj is ViewPortion))
                 return false;
             if (obj == this)
                 return true;
        
             ViewPortion that = (ViewPortion) obj;
             return new EqualsBuilder<ViewPortion>(this, that)
                .With(m => m.UserId)
                .With(m => m.ItemId)
                .With(m => m.Portion)
                .With(m => m.SessionId)
                .With(m => m.Timestamp)
                .With(m => m.RecommId)
                .Equals();
        }
        /// <summary>Hash function</summary>
        /// <returns>A hash code for the current object</returns>
        public override int GetHashCode()
        {
             return new HashCodeBuilder<ViewPortion>(this)
                .With(m => m.UserId)
                .With(m => m.ItemId)
                .With(m => m.Portion)
                .With(m => m.SessionId)
                .With(m => m.Timestamp)
                .With(m => m.RecommId)
                .HashCode;
        }
    }
    
}
