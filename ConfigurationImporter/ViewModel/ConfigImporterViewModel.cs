using NotifierAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConfigurationImporter.Entities.ParserResolverDelegate;

namespace ConfigurationImporter.ViewModel
{
    public class ConfigImporterViewModel: Notifier
    {
        private readonly ParserResolver parserResolver;

        public ConfigImporterViewModel(ParserResolver parserResolver)
        {
            this.parserResolver = parserResolver;
        }



    }
}
