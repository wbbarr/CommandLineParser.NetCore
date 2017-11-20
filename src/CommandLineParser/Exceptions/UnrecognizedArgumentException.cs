namespace wbbarr.CommandLineParserNetCore
{
    [System.Serializable]
    public class UnrecognizedArgumentException : System.Exception
    {
        public UnrecognizedArgumentException() { }
        public UnrecognizedArgumentException(string message) : base(message) { }
        public UnrecognizedArgumentException(string message, System.Exception inner) : base(message, inner) { }
        protected UnrecognizedArgumentException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}