namespace wbbarr.CommandLineParserNetCore.Tests
{
    public static class NamedParameterTestConstants
    {
        public static readonly CommandLineArgument StringRequiredTestArgument = new CommandLineArgument<string>()
        {
            Name = "teststring",
            Description = "Does test things",
            IsRequired = true,
        };
        public static readonly CommandLineArgument StringRequiredSecondArgument = new CommandLineArgument<string>()
        {
            Name = "secondstring",
            Description = "Does some other things.",
            IsRequired = true,
        };
        public static readonly CommandLineArgument BoolRequiredTestArgument = new CommandLineArgument<bool>()
        {
            Name = "testbool",
            Description = "Does some boolean test things.",
            IsRequired = true,
        };
        public static readonly CommandLineArgument IntRequiredTestArgument = new CommandLineArgument<int>()
        {
            Name = "testint",
            Description = "Does some integer test things.",
            IsRequired = true,
        };

        public static string GetFullArgumentName(this CommandLineArgument argument)
        {
            return $"--{argument.Name}";
        }
    }
}