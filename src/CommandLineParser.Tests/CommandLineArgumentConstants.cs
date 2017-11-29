namespace wbbarr.CommandLineParserNetCore.Tests
{
    public static class SwitchTestConstants
    {
        public static readonly CommandLineSwitch ValidSwitch = new CommandLineSwitch()
        {
            Name = "switch",
            Description = "A valid command line switch",
        };

        public static readonly CommandLineSwitch ValidSwitchWithChar = new CommandLineSwitch()
        {
            Name = "flagswitch",
            Description = "A valid command line switch with a single char flag",
            Flag = 'f'
        };
    }

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
        public static readonly CommandLineArgument StringOptionalTestArgument = new CommandLineArgument<string>()
        {
            Name = "teststring",
            Description = "Does optional test things",
            IsRequired = false,
        };
        public static readonly CommandLineArgument StringOptionalTestArgumentWithDefault = new CommandLineArgument<string>()
        {
            Name = "defaultteststring",
            Description = "Does optional test things",
            IsRequired = false,
            DefaultValue = "TestDefaultValue",
        };
    }
}