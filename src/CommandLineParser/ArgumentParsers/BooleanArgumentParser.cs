namespace wbbarr.CommandLineParserNetCore.ArgumentParsers
{
    public class BooleanArgumentParser : ArgumentParser
    {
        public static readonly BooleanArgumentParser Instance = new BooleanArgumentParser();
        
        public override object Parse(string argumentValue)
        {
            return bool.Parse(argumentValue);
        }
    }
}