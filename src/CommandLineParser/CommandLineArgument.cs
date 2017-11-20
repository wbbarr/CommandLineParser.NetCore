using System;

namespace wbbarr.CommandLineParserNetCore
{
    public class CommandLineArgument<T> : CommandLineArgument
    {
        public override Type ArgumentType => typeof(T);
    }

    public class CommandLineArgument : ICommandLineArgument
    {
        public string Name { get; set; }
        public char Flag { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public object Value { get; set; }
        public virtual Type ArgumentType => typeof(object);
    }
}