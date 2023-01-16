using ConfigurationImporter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationImporter.Entities
{
    public class Configuration : IConfiguration
    {
        public string Name { get; set ; }
        public string Description { get; set ; }
    }
}
