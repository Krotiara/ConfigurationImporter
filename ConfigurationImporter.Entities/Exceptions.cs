﻿using System;
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
}
