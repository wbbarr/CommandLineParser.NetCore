using System;
using System.Collections.Generic;
using System.Linq;
using wbbarr.CommandLineParserNetCore.ArgumentParsers;

namespace wbbarr.CommandLineParserNetCore
{
    public class CommandLineParser
    {
        private const string DefaultSwitchPrefix = "-";
        private const string DefaultFullArgumentNamePrefix = "--";

        private Dictionary<Type, ArgumentParser> argumentTypeParsers;
        private Dictionary<string, ICommandLineArgument> arguments;
        private HashSet<string> requiredArguments;

        public CommandLineParser()
        {
            arguments = new Dictionary<string, ICommandLineArgument>();
            argumentTypeParsers = new Dictionary<Type, ArgumentParser>();
            requiredArguments = new HashSet<string>();
            this.RegisterArgumentParser<string>(StringArgumentParser.Instance);
            this.RegisterArgumentParser<bool>(BooleanArgumentParser.Instance);
            this.RegisterArgumentParser<int>(IntegerArgumentParser.Instance);
        }

        public void ParseArguments(string[] args, bool throwOnUnrecognizedArgument = false)
        {
            for (int i = 0; i < args.Length; i++)
            {
                string argumentName = args[i];

                if (argumentName.StartsWith(DefaultFullArgumentNamePrefix))
                {
                    string shortenedArgumentName = argumentName.Substring(DefaultFullArgumentNamePrefix.Length);

                    ICommandLineArgument argument;
                    if (!arguments.TryGetValue(shortenedArgumentName, out argument) && throwOnUnrecognizedArgument)
                    {
                        throw new UnrecognizedArgumentException($"An unrecognized argument '{argumentName}' was provided.");
                    }
                    else if (argument == null)
                    {
                        continue;
                    }

                    ArgumentParser parser = argumentTypeParsers[argument.ArgumentType];
                    argument.Value = parser.Parse(args[++i]);
                    if (requiredArguments.Contains(shortenedArgumentName))
                    {
                        requiredArguments.Remove(shortenedArgumentName);
                    }
                }
            }

            if (requiredArguments.Any())
            {
                throw new MissingRequiredArgumentException();
            }
        }

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

        public void AddArgument(ICommandLineArgument argument)
        {
            // Ensure the argument already has a parser registered.
            if (!argumentTypeParsers.ContainsKey(argument.ArgumentType))
            {
                throw new ArgumentException($"ArgumentParser for type {argument.ArgumentType} is not registered.", nameof(argument));
            }

            // Ensure the argument isn't already registered.
            if (arguments.ContainsKey(argument.Name))
            {
                throw new ArgumentException($"Argument {argument.Name} is already registered.", nameof(argument));
            }

            arguments[argument.Name] = argument;
            if (argument.IsRequired)
            {
                requiredArguments.Add(argument.Name);
            }
        }

        public void RegisterArgumentParser<T>(ArgumentParser parser)
        {
            Type parserType = typeof(T);
            if (argumentTypeParsers.ContainsKey(parserType))
            {
                throw new ArgumentException($"Parser for type {parserType} is already registered.", nameof(parser));
            }

            argumentTypeParsers[parserType] = parser;
        }
    }
}