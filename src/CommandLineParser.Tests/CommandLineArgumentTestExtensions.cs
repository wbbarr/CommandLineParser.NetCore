namespace wbbarr.CommandLineParserNetCore.Tests
{
    public static class CommandLineArgumentTestExtensions
    {
        public static string GetFullArgumentName(this CommandLineArgument argument)
        {
            return $"--{argument.Name}";
        }
    }
}