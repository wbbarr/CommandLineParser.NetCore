namespace wbbarr.CommandLineParserNetCore
{
    [System.Serializable]
    public class MissingRequiredArgumentException : System.Exception
    {
        public MissingRequiredArgumentException() { }
        public MissingRequiredArgumentException(string message) : base(message) { }
        public MissingRequiredArgumentException(string message, System.Exception inner) : base(message, inner) { }
        protected MissingRequiredArgumentException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}