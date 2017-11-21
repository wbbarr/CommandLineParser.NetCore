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

            commandLineParser.ParseArguments(sampleArgs);
            string test = commandLineParser.GetArgument<string>(stringRequiredTestArgument.Name);

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

            commandLineParser.ParseArguments(sampleArgs);
            string test = commandLineParser.GetArgument<string>(stringRequiredTestArgument.Name);
            string second = commandLineParser.GetArgument<string>(stringRequiredSecondArgument.Name);

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

            commandLineParser.ParseArguments(sampleArgs);

            Assert.IsTrue(commandLineParser.GetArgument<bool>(boolRequiredTestArgument.Name));
        }

        [TestMethod]
        [ExpectedException(typeof(UnrecognizedArgumentException))]
        public void ParseArguments_Throws_When_UnexpectedArgument_And_Flag_Set()
        {
            var commandLineParser = new CommandLineParser();
            string[] sampleArgs = new string[] { "--notexpected", "value" };

            commandLineParser.ParseArguments(sampleArgs, throwOnUnrecognizedArgument: true);
        }

        [TestMethod]
        public void ParseArguments_Doesnt_Throw_When_UnexpectedArgument_And_Flag_Not_Set()
        {
            var commandLineParser = new CommandLineParser();
            string[] sampleArgs = new string[] { "--notexpected", "value" };

            commandLineParser.ParseArguments(sampleArgs, throwOnUnrecognizedArgument: false);
        }
    }
}