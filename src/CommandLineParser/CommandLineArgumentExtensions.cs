namespace wbbarr.CommandLineParserNetCore
{
    internal static class CommandLineArgumentExtensions
    {
        internal static CommandLineArgument ToCommandLineArgument(this ICommandLineArgument commandLineArgument)
        {
            return (CommandLineArgument)commandLineArgument;
        }
    }
}