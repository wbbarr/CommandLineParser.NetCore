using System;

namespace wbbarr.CommandLineParserNetCore
{
    public class PositionalCommandLineArgument<T> : PositionalCommandLineArgument
    {
        public override Type ArgumentType => typeof(T);
    }

    public class PositionalCommandLineArgument : CommandLineArgument
    {
        public int Position { get; set; }
    }
}