namespace wbbarr.CommandLineParserNetCore.ArgumentParsers
{
    public class StringArgumentParser : ArgumentParser
    {
        public static readonly StringArgumentParser Instance = new StringArgumentParser();

        public override object Parse(string argumentValue)
        {
            return argumentValue;
        }
    }
}