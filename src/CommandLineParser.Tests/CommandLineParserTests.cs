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
            var testArgument = new CommandLineArgument<string>()
            {
                Name = "test",
                Description = "Does foobar things",
                IsRequired = true,
            };
            commandLineParser.AddArgument(testArgument);

            string[] sampleArgs = new string[] { "--test", "magic" };

            commandLineParser.ParseArguments(sampleArgs);
            string test = commandLineParser.GetArgument<string>("test");

            Assert.AreEqual("magic", test);
        }
    }
}
