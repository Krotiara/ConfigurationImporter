﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationImporter.Interfaces
{
    public interface IConfigurationParser
    {
        public IList<IConfiguration> Parse(string filePath);
    }
}
