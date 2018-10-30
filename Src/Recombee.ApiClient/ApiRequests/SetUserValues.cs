using System;
using System.Collections.Generic;
using System.Net.Http;


namespace Recombee.ApiClient.ApiRequests
{
    /// <summary>Set/update (some) property values of a given user</summary>
    /// <remarks>The properties (columns) must be previously created by Add user property(https://docs.recombee.com/api.html#add-user-property).</remarks>
    public class SetUserValues : SetValues
    {
        /// <summary>ID of the user which will be modified.</summary> 
        public string UserId { get; }

        /// <summary>Construct the request</summary>
        /// <param name="userId">ID of the user which will be modified.</param>
        /// <param name="values">The values for the individual properties. Key in the Dictionary is the name of the property and value is the value to be set.</param>
        /// <param name="cascadeCreate">Sets whether the user should be created if not present in the database.</param>
        public SetUserValues (string userId, Dictionary<string, object>  values, bool? cascadeCreate = null): base(values, cascadeCreate)
        {
            this.UserId = userId;
        }
    
        /// <returns>URI to the endpoint including path parameters</returns>
        public override string Path()
        {
            return string.Format("/users/{0}", UserId);
        }
    }
}
