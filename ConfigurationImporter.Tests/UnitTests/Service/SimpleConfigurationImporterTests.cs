using ConfigurationImporter.Entities;
using ConfigurationImporter.Interfaces;
using ConfigurationImporter.Service;
using ConfigurationImporter.Service.Importers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static ConfigurationImporter.Entities.ParserResolverDelegate;

namespace ConfigurationImporter.Tests.UnitTests.Service
{
    public class SimpleConfigurationImporterTests
    {
        readonly Mock<ParserResolver> parserResolverMock;
        private SimpleConfigurationImporter importer;

        private readonly string testFilesRoot =
           Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;


        public SimpleConfigurationImporterTests()
        {
            parserResolverMock = new Mock<ParserResolver>();
        }


        [Fact]
        public void DetermineParserTypeMustBeCalled()
        {
            string testFile = Path.Combine(testFilesRoot, "TestFiles/correct.csv");
            ParserResolver testDelegate = x => new CsvConfigurationParser();
            parserResolverMock.Setup(x => x.Invoke(It.IsAny<ParserType>())).Returns(testDelegate);
            importer = new SimpleConfigurationImporter(parserResolverMock.Object);
            importer.Import(testFile);
            parserResolverMock.Verify(x => x.Invoke(It.IsAny<ParserType>()), Times.Once);
        }
    }
}
