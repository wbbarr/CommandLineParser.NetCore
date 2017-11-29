using System;

namespace wbbarr.CommandLineParserNetCore
{
    public interface ICommandLineArgument
    {
        string Name { get; set; }
        char Flag { get; set; }
        string Description { get; set; }
        bool IsRequired { get; set; }
        object Value { get; }
        object DefaultValue { get; set; }
        bool IsSwitch { get; }
        Type ArgumentType { get; }
        bool IsParsed { get; }
    }
}