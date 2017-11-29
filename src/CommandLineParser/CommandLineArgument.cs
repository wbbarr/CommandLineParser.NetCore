using System;

namespace wbbarr.CommandLineParserNetCore
{
    public class CommandLineArgument<T> : CommandLineArgument
    {
        public override Type ArgumentType => typeof(T);
    }

    public class CommandLineArgument : ICommandLineArgument
    {
        private object value;
        
        public string Name { get; set; }
        public char Flag { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public object Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                this.IsParsed = true;
            }
        }
        public object DefaultValue { get; set; }
        public virtual bool IsSwitch => false;
        public virtual Type ArgumentType => typeof(object);
        public bool IsParsed { get; internal set; }
    }
}