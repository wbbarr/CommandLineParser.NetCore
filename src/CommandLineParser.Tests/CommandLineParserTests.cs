using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace wbbarr.CommandLineParserNetCore.Tests
{
    [TestClass]
    public class CommandLineParserTests
    {
        [TestMethod]
        public void NamedParameter_string()
        {
            var commandLineParser = new CommandLineParser();
            CommandLineArgument stringRequiredTestArgument = NamedParameterTestConstants.StringRequiredTestArgument;
            commandLineParser.AddArgument(stringRequiredTestArgument);

            string[] sampleArgs = new string[] { stringRequiredTestArgument.GetFullArgumentName(), "magic" };

            var results = commandLineParser.ParseArguments(sampleArgs);
            string test = results.GetArgument<string>(stringRequiredTestArgument.Name);

            Assert.AreEqual("magic", test);
        }

        [TestMethod]
        public void Multiple_NamedParameter_string()
        {
            var commandLineParser = new CommandLineParser();
            CommandLineArgument stringRequiredTestArgument = NamedParameterTestConstants.StringRequiredTestArgument;
            commandLineParser.AddArgument(stringRequiredTestArgument);
            CommandLineArgument stringRequiredSecondArgument = NamedParameterTestConstants.StringRequiredSecondArgument;
            commandLineParser.AddArgument(stringRequiredSecondArgument);
            string[] sampleArgs = new string[]
            {
                stringRequiredTestArgument.GetFullArgumentName(), "magic",
                stringRequiredSecondArgument.GetFullArgumentName(), "alsomagic"
            };

            var results = commandLineParser.ParseArguments(sampleArgs);
            string test = results.GetArgument<string>(stringRequiredTestArgument.Name);
            string second = results.GetArgument<string>(stringRequiredSecondArgument.Name);

            Assert.AreEqual("magic", test);
            Assert.AreEqual("alsomagic", second);
        }

        [TestMethod]
        public void NamedParameter_bool()
        {
            var commandLineParser = new CommandLineParser();
            CommandLineArgument boolRequiredTestArgument = NamedParameterTestConstants.BoolRequiredTestArgument;
            commandLineParser.AddArgument(boolRequiredTestArgument);
            string[] sampleArgs = new string[] { boolRequiredTestArgument.GetFullArgumentName(), "true" };

            var result = commandLineParser.ParseArguments(sampleArgs);

            Assert.IsTrue(result.GetArgument<bool>(boolRequiredTestArgument.Name));
        }

        [TestMethod]
        public void ParseArguments_Throws_When_UnexpectedArgument_And_Flag_Set()
        {
            var commandLineParser = new CommandLineParser();
            string[] sampleArgs = new string[] { "--notexpected", "value" };

            var result = commandLineParser.ParseArguments(sampleArgs, errorOnUnrecognizedArgument: true);

            Assert.IsTrue(result.HasError);
            Assert.AreEqual(1, result.Errors.Count);
            var error = result.Errors.First();
            Assert.AreEqual(ParserErrorType.UnrecognizedArgument, error.ErrorType);
        }

        [TestMethod]
        public void ParseArguments_Doesnt_Throw_When_UnexpectedArgument_And_Flag_Not_Set()
        {
            var commandLineParser = new CommandLineParser();
            string[] sampleArgs = new string[] { "--notexpected", "value" };

            commandLineParser.ParseArguments(sampleArgs, errorOnUnrecognizedArgument: false);
        }

        [TestMethod]
        public void ParseArguments_Throws_When_Missing_Required_Argument()
        {
            var commandLineParser = new CommandLineParser();
            commandLineParser.AddArgument(NamedParameterTestConstants.StringRequiredTestArgument);
            string[] sampleArgs = new string[] { "--notexpected", "value" };

            var result = commandLineParser.ParseArguments(sampleArgs);
            Assert.IsTrue(result.HasError);
            Assert.AreEqual(ParserErrorType.MissingRequiredParameter, result.Errors.First().ErrorType);
        }

        [TestMethod]
        public void ParseArguments_Doesnt_Throw_When_Missing_Optional_Argument()
        {
            var commandLineParser = new CommandLineParser();
            commandLineParser.AddArgument(NamedParameterTestConstants.StringOptionalTestArgument);
            string[] sampleArgs = new string[] { "--notexpected", "value" };

            var result = commandLineParser.ParseArguments(sampleArgs);
            Assert.IsNull(result.GetArgument<string>(NamedParameterTestConstants.StringOptionalTestArgument.Name));
        }
    }
}