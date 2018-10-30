using System;
using System.Collections.Generic;

namespace Recombee.ApiClient.Bindings
{
    /// <summary>Base class for the entities</summary>
    public abstract class Entity: RecombeeBinding
    {
        private readonly Dictionary<string, object> _values;
        
        /// <summary>Values of properties</summary>
        public Dictionary<string, object> Values
        {
            get
            {
                if(_values == null)
                    throw new InvalidOperationException("The request was not meant to return values (use returnProperties parameter)");
                return _values;
            }
        }

        public Entity(Dictionary<string, object> values)
        {
            this._values = values;
        }
    }
}