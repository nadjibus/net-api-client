/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using System.Net.Http;
using Recombee.ApiClient.Util;


namespace Recombee.ApiClient.ApiRequests
{
    /// <summary>Add cart addition</summary>
    /// <remarks>Adds a cart addition of a given item made by a given user.
    /// </remarks>
    public class AddCartAddition : Request
    {
        /// <summary>User who added the item to the cart</summary>
        public string UserId { get; }

        /// <summary>Item added to the cart</summary>
        public string ItemId { get; }

        /// <summary>UTC timestamp of the cart addition as ISO8601-1 pattern or UTC epoch time. The default value is the current time.</summary>
        public DateTime? Timestamp { get; }

        /// <summary>Sets whether the given user/item should be created if not present in the database.</summary>
        public bool? CascadeCreate { get; }

        /// <summary>Amount (number) added to cart. The default is 1. For example if `user-x` adds two `item-y` during a single order (session...), the `amount` should equal to 2.</summary>
        public double? Amount { get; }

        /// <summary>Price of the added item. If `amount` is greater than 1, sum of prices of all the items should be given.</summary>
        public double? Price { get; }

        /// <summary>If this cart addition is based on a recommendation request, `recommId` is the id of the clicked recommendation.</summary>
        public string RecommId { get; }

        /// <summary>Construct the request</summary>
        /// <param name="userId">User who added the item to the cart</param>
        /// <param name="itemId">Item added to the cart</param>
        /// <param name="timestamp">UTC timestamp of the cart addition as ISO8601-1 pattern or UTC epoch time. The default value is the current time.</param>
        /// <param name="cascadeCreate">Sets whether the given user/item should be created if not present in the database.</param>
        /// <param name="amount">Amount (number) added to cart. The default is 1. For example if `user-x` adds two `item-y` during a single order (session...), the `amount` should equal to 2.</param>
        /// <param name="price">Price of the added item. If `amount` is greater than 1, sum of prices of all the items should be given.</param>
        /// <param name="recommId">If this cart addition is based on a recommendation request, `recommId` is the id of the clicked recommendation.</param>
        public AddCartAddition (string userId, string itemId, DateTime? timestamp = null, bool? cascadeCreate = null, double? amount = null, double? price = null, string recommId = null): base(HttpMethod.Post, 10000)
        {
            this.UserId = userId;
            this.ItemId = itemId;
            this.Timestamp = timestamp;
            this.CascadeCreate = cascadeCreate;
            this.Amount = amount;
            this.Price = price;
            this.RecommId = recommId;
        }
    
        /// <returns>URI to the endpoint including path parameters</returns>
        public override string Path()
        {
            return "/cartadditions/";
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
                {"itemId", ItemId}
            };
            if (Timestamp.HasValue)
                parameters["timestamp"] = ConvertToUnixTimestamp(Timestamp.Value);
            if (CascadeCreate.HasValue)
                parameters["cascadeCreate"] = CascadeCreate.Value;
            if (Amount.HasValue)
                parameters["amount"] = Amount.Value;
            if (Price.HasValue)
                parameters["price"] = Price.Value;
            if (RecommId != null)
                parameters["recommId"] = RecommId;
            return parameters;
        }
    
    }
}
