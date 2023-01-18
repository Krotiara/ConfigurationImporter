using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationImporter.Tests.UnitTests.Service.Parsers
{
    public class XmlConfigurationParserUnitTests
    {
        private readonly string testFilesRoot =
          Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;


        public XmlConfigurationParserUnitTests()
        {

        }


        [Fact]
        public void ParseCorrectFileMustReturnConfigs()
        {
            throw new NotImplementedException();
        }


        [Fact]
        public void ParseFormatBrokenFileMustThrow()
        {
            throw new NotImplementedException();
        }


        [Fact]
        public void ParseEmptyFileMustThrow()
        {
            throw new NotImplementedException();
        }
    }
}
