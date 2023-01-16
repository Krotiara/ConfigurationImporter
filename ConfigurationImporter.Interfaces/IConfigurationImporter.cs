using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationImporter.Interfaces
{
    public interface IConfigurationImporter
    {
        public IConfiguration Import(string path);
    }
}
