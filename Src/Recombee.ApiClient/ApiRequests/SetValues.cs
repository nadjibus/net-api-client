using System;
using System.Collections.Generic;
using System.Net.Http;


namespace Recombee.ApiClient.ApiRequests
{
    /// <summary>Set/update (some) property values of an entity</summary>
    public abstract class SetValues : Request
    {
        /// <summary>Sets whether the entity should be created if not present in the database.</summary>
        public bool? CascadeCreate { get; }

        /// <summary>The values for the individual properties. </summary>
        public Dictionary<string, object> Values { get; }

        /// <summary>Construct the request</summary>
        /// <param name="values">The values for the individual properties. Key in the Dictionary is the name of the property and value is the value to be set.</param>
        /// <param name="cascadeCreate">Sets whether the entity should be created if not present in the database.</param>
        public SetValues (Dictionary<string, object> values, bool? cascadeCreate = null): base(HttpMethod.Post, 10000)
        {
            this.CascadeCreate = cascadeCreate;
            this.Values = values;
        }
    
        /// <summary>Get query parameters</summary>
        /// <returns>Dictionary containing values of query parameters (name of parameter: value of the parameter)</returns>
        public override Dictionary<string, object> QueryParameters()
        {
           return new Dictionary<string, object>();
        }
    
        /// <summary>Get body parameters</summary>
        /// <returns>Dictionary containing  values of body parameters (name of parameter: value of the parameter)</returns>
        public override Dictionary<string, object> BodyParameters()
        {
            if (CascadeCreate.HasValue)
            {
                Dictionary<string, object> vals = new Dictionary<string, object>(Values);
                vals["!cascadeCreate"] = CascadeCreate;
                return vals;
            } 
            return Values;
        }
    }
}