using System;

namespace wbbarr.CommandLineParserNetCore
{    
    public abstract class ArgumentParser
    {
        public abstract object Parse(string argumentValue);
    }
}