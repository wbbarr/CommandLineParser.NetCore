using System;
using System.Collections.Generic;
using System.Linq;

namespace wbbarr.CommandLineParserNetCore
{
    public class ParserResult
    {
        private IDictionary<string, ICommandLineArgument> arguments;

        public ParserResult()
        {
            this.arguments = new Dictionary<string, ICommandLineArgument>();
            this.Errors = new List<ParserError>();
        }

        public bool HasError => this.Errors.Any();

        internal IDictionary<string, ICommandLineArgument> Arguments
        {
            set
            {
                arguments = value;
            }
        }

        public IList<ParserError> Errors { get; set; }

        public T GetArgument<T>(string name)
        {
            if (!arguments.ContainsKey(name))
            {
                throw new ArgumentException($"Invalid argument name {name} specified.", nameof(name));
            }

            ICommandLineArgument argument = arguments[name];
            if (typeof(T) != argument.ArgumentType)
            {
                throw new InvalidOperationException($"Invalid type requested for argument {name} which has type {argument.ArgumentType}");
            }

            return (T)argument.Value;
        }
    }
}