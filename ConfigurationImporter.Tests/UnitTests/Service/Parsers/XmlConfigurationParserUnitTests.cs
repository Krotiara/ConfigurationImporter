using ConfigurationImporter.Entities;
using ConfigurationImporter.Interfaces;
using ConfigurationImporter.Service.Importers;
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

        private XmlConfigurationParser parser;


        public XmlConfigurationParserUnitTests()
        {
            parser = new XmlConfigurationParser();
        }


        [Fact]
        public void ParseCorrectFileMustReturnConfigs()
        {
            string testFile = Path.Combine(testFilesRoot, "TestFiles/correct.xml");
            IList<IConfiguration> result = parser.Parse(testFile);
            Assert.NotEmpty(result);
        }


        [Fact]
        public void ParseFormatBrokenFileMustThrow()
        {
            string testFile = Path.Combine(testFilesRoot, "TestFiles/breakFormat.xml");
            Assert.Throws<ParseConfigException>(() => parser.Parse(testFile));
        }


        [Fact]
        public void ParseEmptyFileMustThrow()
        {
            string testFile = Path.Combine(testFilesRoot, "TestFiles/empty.xml");
            Assert.Throws<ParseConfigException>(() => parser.Parse(testFile));
        }
    }
}
