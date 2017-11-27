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

        public ParserResult ParseArguments(string[] args, bool errorOnUnrecognizedArgument = false)
        {
            ParserResult result = new ParserResult();

            for (int i = 0; i < args.Length; i++)
            {
                string argumentName = args[i];

                if (argumentName.StartsWith(DefaultFullArgumentNamePrefix))
                {
                    string shortenedArgumentName = argumentName.Substring(DefaultFullArgumentNamePrefix.Length);

                    ICommandLineArgument argument;
                    if (!arguments.TryGetValue(shortenedArgumentName, out argument) && errorOnUnrecognizedArgument)
                    {
                        result.Errors.Add(new ParserError
                        {
                            ErrorType = ParserErrorType.UnrecognizedArgument,
                            ErrorDetails = $"An unrecognized argument '{argumentName}' was provided."
                        });
                    }
                    
                    if (argument == null)
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

            foreach (var missingRequiredArgument in requiredArguments)
            {
                result.Errors.Add(new ParserError{
                    ErrorType = ParserErrorType.MissingRequiredParameter,
                    Argument = arguments[missingRequiredArgument]
                    });
            }

            result.Arguments = arguments;
            return result;
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