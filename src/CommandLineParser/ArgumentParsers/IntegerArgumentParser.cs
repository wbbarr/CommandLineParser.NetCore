namespace wbbarr.CommandLineParserNetCore.ArgumentParsers
{
    public class IntegerArgumentParser : ArgumentParser
    {
        public static readonly IntegerArgumentParser Instance = new IntegerArgumentParser();
        
        public override object Parse(string argumentValue)
        {
            return int.Parse(argumentValue);
        }
    }
}