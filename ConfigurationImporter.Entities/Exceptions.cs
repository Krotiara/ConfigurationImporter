using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationImporter.Entities
{
    public class GetConfigParserTypeException: Exception
    {
        public GetConfigParserTypeException(string message) : base(message) { }
    }


    public class GetConfigParserException : Exception
    {
        public GetConfigParserException(string message) : base(message) { }
    }


    public class ParseConfigException : Exception
    {
        public ParseConfigException(string message) : base(message) { }

        public ParseConfigException(string message, Exception innerException) : base(message, innerException) { }
    }


    public class ImportConfigurationsException: Exception
    {
        public ImportConfigurationsException(string message) : base(message) { }

        public ImportConfigurationsException(string message, Exception innerException) : base(message, innerException) { }
    }
}
