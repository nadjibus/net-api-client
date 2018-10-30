namespace Recombee.ApiClient.Bindings
{
    /// <summary>Binding for string response</summary>
    public class StringBinding: RecombeeBinding
    {
        /// <summary>String response</summary>
        public string StringValue { get; }

        public StringBinding(string str)
        {
            this.StringValue = str;
        }
    }
}