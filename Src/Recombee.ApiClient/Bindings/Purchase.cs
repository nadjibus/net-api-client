/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using Recombee.ApiClient.Util;

namespace Recombee.ApiClient.Bindings
{
    /// <summary>Purchase Binding</summary>
    public class Purchase: RecombeeBinding {
        /// <summary>User who purchased the item</summary>
        public string UserId { get; }

        /// <summary>Purchased item</summary>
        public string ItemId { get; }

        [JsonConverter(typeof(EpochJsonReader))]
        private readonly DateTime? _timestamp;
        /// <summary>UTC timestamp of the purchase as ISO8601-1 pattern or UTC epoch time. The default value is the current time.</summary>
        [JsonConverter(typeof(EpochJsonReader))]
        public DateTime? Timestamp
        {
            get {return _timestamp;}
        }

        /// <summary>Amount (number) of purchased items. The default is 1. For example if `user-x` purchases two `item-y` during a single order (session...), the `amount` should equal to 2.</summary>
        public double? Amount { get; }

        /// <summary>Price paid by the user for the item. If `amount` is greater than 1, sum of prices of all the items should be given.</summary>
        public double? Price { get; }

        /// <summary>Your profit from the purchased item. The profit is natural in e-commerce domain (for example if `user-x` purchases `item-y` for $100 and the gross margin is 30 %, then the profit is $30), but is applicable also in other domains (for example at a news company it may be income from displayed advertisement on article page). If `amount` is greater than 1, sum of profit of all the items should be given.</summary>
        public double? Profit { get; }

        /// <summary>If this purchase is based on a recommendation request, `recommId` is the id of the clicked recommendation.</summary>
        public string RecommId { get; }

        public Purchase (string userId, string itemId, DateTime? timestamp = null, double? amount = null, double? price = null, double? profit = null, string recommId = null)
        {
            this.UserId = userId;
            this.ItemId = itemId;
            this._timestamp = timestamp;
            this.Amount = amount;
            this.Price = price;
            this.Profit = profit;
            this.RecommId = recommId;
        }
    
        /// <summary>Determines whether the specified object is equal to the current object</summary>
        /// <param name="obj">The object to compare with the current object</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false</returns>
        public override bool Equals(Object obj)
        {
             if (!(obj is Purchase))
                 return false;
             if (obj == this)
                 return true;
        
             Purchase that = (Purchase) obj;
             return new EqualsBuilder<Purchase>(this, that)
                .With(m => m.UserId)
                .With(m => m.ItemId)
                .With(m => m.Timestamp)
                .With(m => m.Amount)
                .With(m => m.Price)
                .With(m => m.Profit)
                .With(m => m.RecommId)
                .Equals();
        }
        /// <summary>Hash function</summary>
        /// <returns>A hash code for the current object</returns>
        public override int GetHashCode()
        {
             return new HashCodeBuilder<Purchase>(this)
                .With(m => m.UserId)
                .With(m => m.ItemId)
                .With(m => m.Timestamp)
                .With(m => m.Amount)
                .With(m => m.Price)
                .With(m => m.Profit)
                .With(m => m.RecommId)
                .HashCode;
        }
    }
    
}
