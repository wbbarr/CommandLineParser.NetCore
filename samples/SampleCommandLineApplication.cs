using System;
using wbbarr.CommandLineParserNetCore;

namespace wbbarr.CommandLineParserNetCore.Samples
{
    class SampleCommandLineApplication
    {
        static void Main(string[] args)
        {
            var commandLineParser = new CommandLineParser();
            var foobarArgument = new CommandLineArgument<string>()
            {
                Name = "foobar",
                Description = "Does foobar things",
                IsRequired = true,
            };
            commandLineParser.AddArgument(foobarArgument);

            string[] sampleArgs = new string[] { "--foobar", "magic" };
            var result = commandLineParser.ParseArguments(sampleArgs);
            
            string foobar = result.GetArgument<string>("foobar");
            Console.WriteLine(foobar);
        }
    }
}