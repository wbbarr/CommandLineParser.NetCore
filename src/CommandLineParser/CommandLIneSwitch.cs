using System;

namespace wbbarr.CommandLineParserNetCore
{

    public class CommandLineSwitch : CommandLineArgument
    {
        public CommandLineSwitch() : base()
        {
            this.DefaultValue = false;
        }

        public override bool IsSwitch => true;
        public override Type ArgumentType => typeof(bool);
    }
}