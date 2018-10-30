/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using Recombee.ApiClient.Util;

namespace Recombee.ApiClient.Bindings
{
    /// <summary>SeriesItem Binding</summary>
    public class SeriesItem: RecombeeBinding {
        /// <summary>`item` iff the regular item from the catalog is to be inserted, `series` iff series is inserted as the item.</summary>
        public string ItemType { get; }

        /// <summary>ID of the item iff `itemType` is `item`. ID of the series iff `itemType` is `series`.</summary>
        public string ItemId { get; }

        /// <summary>Time index used for sorting items in the series. According to time, items are sorted within series in ascending order. In the example of TV show episodes, the episode number is a natural choice to be passed as time.</summary>
        public double Time { get; }

        public SeriesItem (string itemType, string itemId, double time)
        {
            this.ItemType = itemType;
            this.ItemId = itemId;
            this.Time = time;
        }
    
        /// <summary>Determines whether the specified object is equal to the current object</summary>
        /// <param name="obj">The object to compare with the current object</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false</returns>
        public override bool Equals(Object obj)
        {
             if (!(obj is SeriesItem))
                 return false;
             if (obj == this)
                 return true;
        
             SeriesItem that = (SeriesItem) obj;
             return new EqualsBuilder<SeriesItem>(this, that)
                .With(m => m.ItemType)
                .With(m => m.ItemId)
                .With(m => m.Time)
                .Equals();
        }
        /// <summary>Hash function</summary>
        /// <returns>A hash code for the current object</returns>
        public override int GetHashCode()
        {
             return new HashCodeBuilder<SeriesItem>(this)
                .With(m => m.ItemType)
                .With(m => m.ItemId)
                .With(m => m.Time)
                .HashCode;
        }
    }
    
}
