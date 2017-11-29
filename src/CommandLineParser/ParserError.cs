using System;

namespace wbbarr.CommandLineParserNetCore
{
    public class ParserError
    {
        public ParserErrorType ErrorType { get; set; }
        public ICommandLineArgument Argument { get; set; }
        public string ErrorDetails { get; set; }
        public string ArgumentInput { get; set; }
        public Exception ParserException { get; set; }
    }
}