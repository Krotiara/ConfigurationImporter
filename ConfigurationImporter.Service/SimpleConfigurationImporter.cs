using ConfigurationImporter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationImporter.Service
{
    public class SimpleConfigurationImporter : IConfigurationImporter
    {
        public SimpleConfigurationImporter()
        {
            //TODO DI parser resolver-a
        }


        public IConfiguration Import(string path)
        {
            throw new NotImplementedException();
        }
    }
}
