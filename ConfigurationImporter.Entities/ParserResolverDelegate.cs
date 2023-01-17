using ConfigurationImporter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationImporter.Entities
{
    public class ParserResolverDelegate
    {
        public delegate IConfigurationParser ParserResolver(ParserType parserType);
    }
}
