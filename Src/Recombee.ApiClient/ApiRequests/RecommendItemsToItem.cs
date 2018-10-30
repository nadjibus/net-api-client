/*
 This file is auto-generated, do not edit
*/

using System;
using System.Collections.Generic;
using System.Net.Http;
using Recombee.ApiClient.Util;


namespace Recombee.ApiClient.ApiRequests
{
    /// <summary>Recommend items to item</summary>
    /// <remarks>Recommends set of items that are somehow related to one given item, *X*. Typical scenario  is when user *A* is viewing *X*. Then you may display items to the user that he might be also interested in. Recommend items to item request gives you Top-N such items, optionally taking the target user *A* into account.
    /// It is also possible to use POST HTTP method (for example in case of very long ReQL filter) - query parameters then become body parameters.
    /// </remarks>
    public class RecommendItemsToItem : Request
    {
        /// <summary>ID of the item for which the recommendations are to be generated.</summary>
        public string ItemId { get; }

        /// <summary>ID of the user who will see the recommendations.
        /// Specifying the *targetUserId* is beneficial because:
        /// * It makes the recommendations personalized
        /// * Allows the calculation of Actions and Conversions
        ///   in the graphical user interface,
        ///   as Recombee can pair the user who got recommendations
        ///   and who afterwards viewed/purchased an item.
        /// If you insist on not specifying the user, pass `null`
        /// (`None`, `nil`, `NULL` etc. depending on language) to *targetUserId*.
        /// Do not create some special dummy user for getting recommendations,
        /// as it could mislead the recommendation models,
        /// and result in wrong recommendations.
        /// For anonymous/unregistered users it is possible to use for example their session ID.
        /// </summary>
        public string TargetUserId { get; }

        /// <summary>Number of items to be recommended (N for the top-N recommendation).</summary>
        public long Count { get; }

        /// <summary>If *targetUserId* parameter is present, the recommendations are biased towards the user given. Using *userImpact*, you may control this bias. For an extreme case of `userImpact=0.0`, the interactions made by the user are not taken into account at all (with the exception of history-based blacklisting), for `userImpact=1.0`, you'll get user-based recommendation. The default value is `0`.
        /// </summary>
        public double? UserImpact { get; }

        /// <summary>Boolean-returning [ReQL](https://docs.recombee.com/reql.html) expression which allows you to filter recommended items based on the values of their attributes.</summary>
        public string Filter { get; }

        /// <summary>Number-returning [ReQL](https://docs.recombee.com/reql.html) expression which allows you to boost recommendation rate of some items based on the values of their attributes.</summary>
        public string Booster { get; }

        /// <summary>If item of given *itemId* or user of given *targetUserId* doesn't exist in the database, it creates the missing entity/entities and returns some (non-personalized) recommendations. This allows for example rotations in the following recommendations for the user of given *targetUserId*, as the user will be already known to the system.</summary>
        public bool? CascadeCreate { get; }

        /// <summary>Scenario defines a particular application of recommendations. It can be for example "homepage", "cart" or "emailing". You can see each scenario in the UI separately, so you can check how well each application performs. The AI which optimizes models in order to get the best results may optimize different scenarios separately, or even use different models in each of the scenarios.</summary>
        public string Scenario { get; }

        /// <summary>With `returnProperties=true`, property values of the recommended items are returned along with their IDs in a JSON dictionary. The acquired property values can be used for easy displaying of the recommended items to the user. 
        /// Example response:
        /// ```
        ///   {
        ///     "recommId": "0c6189e7-dc1a-429a-b613-192696309361",
        ///     "recomms":
        ///       [
        ///         {
        ///           "id": "tv-178",
        ///           "values": {
        ///             "description": "4K TV with 3D feature",
        ///             "categories":   ["Electronics", "Televisions"],
        ///             "price": 342,
        ///             "url": "myshop.com/tv-178"
        ///           }
        ///         },
        ///         {
        ///           "id": "mixer-42",
        ///           "values": {
        ///             "description": "Stainless Steel Mixer",
        ///             "categories":   ["Home & Kitchen"],
        ///             "price": 39,
        ///             "url": "myshop.com/mixer-42"
        ///           }
        ///         }
        ///       ]
        ///   }
        /// ```
        /// </summary>
        public bool? ReturnProperties { get; }

        /// <summary>Allows to specify, which properties should be returned when `returnProperties=true` is set. The properties are given as a comma-separated list. 
        /// Example response for `includedProperties=description,price`:
        /// ```
        ///   {
        ///     "recommId": "6842c725-a79f-4537-a02c-f34d668a3f80",
        ///     "recomms": 
        ///       [
        ///         {
        ///           "id": "tv-178",
        ///           "values": {
        ///             "description": "4K TV with 3D feature",
        ///             "price": 342
        ///           }
        ///         },
        ///         {
        ///           "id": "mixer-42",
        ///           "values": {
        ///             "description": "Stainless Steel Mixer",
        ///             "price": 39
        ///           }
        ///         }
        ///       ]
        ///   }
        /// ```
        /// </summary>
        public string[] IncludedProperties { get; }

        /// <summary>**Expert option** Real number from [0.0, 1.0] which determines how much mutually dissimilar should the recommended items be. The default value is 0.0, i.e., no diversification. Value 1.0 means maximal diversification.
        /// </summary>
        public double? Diversity { get; }

        /// <summary>**Expert option** If the *targetUserId* is provided:  Specifies the threshold of how much relevant must the recommended items be to the user. Possible values one of: "low", "medium", "high". The default value is "low", meaning that the system attempts to recommend number of items equal to *count* at any cost. If there are not enough data (such as interactions or item properties), this may even lead to bestseller-based recommendations to be appended to reach the full *count*. This behavior may be suppressed by using "medium" or "high" values. In such case, the system only recommends items of at least the requested relevancy, and may return less than *count* items when there is not enough data to fulfill it.
        /// </summary>
        public string MinRelevance { get; }

        /// <summary>**Expert option** If the *targetUserId* is provided: If your users browse the system in real-time, it may easily happen that you wish to offer them recommendations multiple times. Here comes the question: how much should the recommendations change? Should they remain the same, or should they rotate? Recombee API allows you to control this per-request in backward fashion. You may penalize an item for being recommended in the near past. For the specific user, `rotationRate=1` means maximal rotation, `rotationRate=0` means absolutely no rotation. You may also use, for example `rotationRate=0.2` for only slight rotation of recommended items.
        /// </summary>
        public double? RotationRate { get; }

        /// <summary>**Expert option** If the *targetUserId* is provided: Taking *rotationRate* into account, specifies how long time it takes to an item to recover from the penalization. For example, `rotationTime=7200.0` means that items recommended less than 2 hours ago are penalized.
        /// </summary>
        public double? RotationTime { get; }

        /// <summary>Dictionary of custom options.
        /// </summary>
        public Dictionary<string, object> ExpertSettings { get; }

        /// <summary>Construct the request</summary>
        /// <param name="itemId">ID of the item for which the recommendations are to be generated.</param>
        /// <param name="targetUserId">ID of the user who will see the recommendations.
        /// Specifying the *targetUserId* is beneficial because:
        /// * It makes the recommendations personalized
        /// * Allows the calculation of Actions and Conversions
        ///   in the graphical user interface,
        ///   as Recombee can pair the user who got recommendations
        ///   and who afterwards viewed/purchased an item.
        /// If you insist on not specifying the user, pass `null`
        /// (`None`, `nil`, `NULL` etc. depending on language) to *targetUserId*.
        /// Do not create some special dummy user for getting recommendations,
        /// as it could mislead the recommendation models,
        /// and result in wrong recommendations.
        /// For anonymous/unregistered users it is possible to use for example their session ID.
        /// </param>
        /// <param name="count">Number of items to be recommended (N for the top-N recommendation).</param>
        /// <param name="userImpact">If *targetUserId* parameter is present, the recommendations are biased towards the user given. Using *userImpact*, you may control this bias. For an extreme case of `userImpact=0.0`, the interactions made by the user are not taken into account at all (with the exception of history-based blacklisting), for `userImpact=1.0`, you'll get user-based recommendation. The default value is `0`.
        /// </param>
        /// <param name="filter">Boolean-returning [ReQL](https://docs.recombee.com/reql.html) expression which allows you to filter recommended items based on the values of their attributes.</param>
        /// <param name="booster">Number-returning [ReQL](https://docs.recombee.com/reql.html) expression which allows you to boost recommendation rate of some items based on the values of their attributes.</param>
        /// <param name="cascadeCreate">If item of given *itemId* or user of given *targetUserId* doesn't exist in the database, it creates the missing entity/entities and returns some (non-personalized) recommendations. This allows for example rotations in the following recommendations for the user of given *targetUserId*, as the user will be already known to the system.</param>
        /// <param name="scenario">Scenario defines a particular application of recommendations. It can be for example "homepage", "cart" or "emailing". You can see each scenario in the UI separately, so you can check how well each application performs. The AI which optimizes models in order to get the best results may optimize different scenarios separately, or even use different models in each of the scenarios.</param>
        /// <param name="returnProperties">With `returnProperties=true`, property values of the recommended items are returned along with their IDs in a JSON dictionary. The acquired property values can be used for easy displaying of the recommended items to the user. 
        /// Example response:
        /// ```
        ///   {
        ///     "recommId": "0c6189e7-dc1a-429a-b613-192696309361",
        ///     "recomms":
        ///       [
        ///         {
        ///           "id": "tv-178",
        ///           "values": {
        ///             "description": "4K TV with 3D feature",
        ///             "categories":   ["Electronics", "Televisions"],
        ///             "price": 342,
        ///             "url": "myshop.com/tv-178"
        ///           }
        ///         },
        ///         {
        ///           "id": "mixer-42",
        ///           "values": {
        ///             "description": "Stainless Steel Mixer",
        ///             "categories":   ["Home & Kitchen"],
        ///             "price": 39,
        ///             "url": "myshop.com/mixer-42"
        ///           }
        ///         }
        ///       ]
        ///   }
        /// ```
        /// </param>
        /// <param name="includedProperties">Allows to specify, which properties should be returned when `returnProperties=true` is set. The properties are given as a comma-separated list. 
        /// Example response for `includedProperties=description,price`:
        /// ```
        ///   {
        ///     "recommId": "6842c725-a79f-4537-a02c-f34d668a3f80",
        ///     "recomms": 
        ///       [
        ///         {
        ///           "id": "tv-178",
        ///           "values": {
        ///             "description": "4K TV with 3D feature",
        ///             "price": 342
        ///           }
        ///         },
        ///         {
        ///           "id": "mixer-42",
        ///           "values": {
        ///             "description": "Stainless Steel Mixer",
        ///             "price": 39
        ///           }
        ///         }
        ///       ]
        ///   }
        /// ```
        /// </param>
        /// <param name="diversity">**Expert option** Real number from [0.0, 1.0] which determines how much mutually dissimilar should the recommended items be. The default value is 0.0, i.e., no diversification. Value 1.0 means maximal diversification.
        /// </param>
        /// <param name="minRelevance">**Expert option** If the *targetUserId* is provided:  Specifies the threshold of how much relevant must the recommended items be to the user. Possible values one of: "low", "medium", "high". The default value is "low", meaning that the system attempts to recommend number of items equal to *count* at any cost. If there are not enough data (such as interactions or item properties), this may even lead to bestseller-based recommendations to be appended to reach the full *count*. This behavior may be suppressed by using "medium" or "high" values. In such case, the system only recommends items of at least the requested relevancy, and may return less than *count* items when there is not enough data to fulfill it.
        /// </param>
        /// <param name="rotationRate">**Expert option** If the *targetUserId* is provided: If your users browse the system in real-time, it may easily happen that you wish to offer them recommendations multiple times. Here comes the question: how much should the recommendations change? Should they remain the same, or should they rotate? Recombee API allows you to control this per-request in backward fashion. You may penalize an item for being recommended in the near past. For the specific user, `rotationRate=1` means maximal rotation, `rotationRate=0` means absolutely no rotation. You may also use, for example `rotationRate=0.2` for only slight rotation of recommended items.
        /// </param>
        /// <param name="rotationTime">**Expert option** If the *targetUserId* is provided: Taking *rotationRate* into account, specifies how long time it takes to an item to recover from the penalization. For example, `rotationTime=7200.0` means that items recommended less than 2 hours ago are penalized.
        /// </param>
        /// <param name="expertSettings">Dictionary of custom options.
        /// </param>
        public RecommendItemsToItem (string itemId, string targetUserId, long count, double? userImpact = null, string filter = null, string booster = null, bool? cascadeCreate = null, string scenario = null, bool? returnProperties = null, string[] includedProperties = null, double? diversity = null, string minRelevance = null, double? rotationRate = null, double? rotationTime = null, Dictionary<string, object> expertSettings = null): base(HttpMethod.Post, 10000)
        {
            this.ItemId = itemId;
            this.TargetUserId = targetUserId;
            this.Count = count;
            this.UserImpact = userImpact;
            this.Filter = filter;
            this.Booster = booster;
            this.CascadeCreate = cascadeCreate;
            this.Scenario = scenario;
            this.ReturnProperties = returnProperties;
            this.IncludedProperties = includedProperties;
            this.Diversity = diversity;
            this.MinRelevance = minRelevance;
            this.RotationRate = rotationRate;
            this.RotationTime = rotationTime;
            this.ExpertSettings = expertSettings;
        }
    
        /// <returns>URI to the endpoint including path parameters</returns>
        public override string Path()
        {
            return string.Format("/recomms/items/{0}/items/", ItemId);
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
                {"targetUserId", TargetUserId},
                {"count", Count}
            };
            if (UserImpact.HasValue)
                parameters["userImpact"] = UserImpact.Value;
            if (Filter != null)
                parameters["filter"] = Filter;
            if (Booster != null)
                parameters["booster"] = Booster;
            if (CascadeCreate.HasValue)
                parameters["cascadeCreate"] = CascadeCreate.Value;
            if (Scenario != null)
                parameters["scenario"] = Scenario;
            if (ReturnProperties.HasValue)
                parameters["returnProperties"] = ReturnProperties.Value;
            if (IncludedProperties != null)
                parameters["includedProperties"] = string.Join(",", IncludedProperties);
            if (Diversity.HasValue)
                parameters["diversity"] = Diversity.Value;
            if (MinRelevance != null)
                parameters["minRelevance"] = MinRelevance;
            if (RotationRate.HasValue)
                parameters["rotationRate"] = RotationRate.Value;
            if (RotationTime.HasValue)
                parameters["rotationTime"] = RotationTime.Value;
            if (ExpertSettings != null)
                parameters["expertSettings"] = ExpertSettings;
            return parameters;
        }
    
    }
}
