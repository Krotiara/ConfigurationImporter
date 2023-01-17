using ConfigurationImporter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConfigurationImporter.Entities.ParserResolverDelegate;

namespace ConfigurationImporter.Service
{
    public class SimpleConfigurationImporter : IConfigurationImporter
    {
        private readonly ParserResolver parserResolver;


        public SimpleConfigurationImporter(ParserResolver parserResolver)
        {
            this.parserResolver = parserResolver;
        }


        public IList<IConfiguration> Import(string path)
        {
            throw new NotImplementedException();
        }
    }
}
