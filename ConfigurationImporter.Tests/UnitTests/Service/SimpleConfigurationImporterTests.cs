using ConfigurationImporter.Entities;
using ConfigurationImporter.Interfaces;
using ConfigurationImporter.Service;
using ConfigurationImporter.Service.Importers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConfigurationImporter.Entities.ParserResolverDelegate;

namespace ConfigurationImporter.Tests.UnitTests.Service
{
    public class SimpleConfigurationImporterTests
    {
        readonly Mock<ParserResolver> parserResolverMock;
        readonly SimpleConfigurationImporter importer;


        public SimpleConfigurationImporterTests()
        {
            //parserResolverMock = new Mock<ParserResolver>();
            //parserResolverMock.Setup(x => x.Invoke(ParserType.SimpleXml)).Returns(GetTestParserType(ParserType.SimpleXml));
            //parserResolverMock.Setup(x => x.Invoke(ParserType.SimpleCsv)).Returns(GetTestParserType(ParserType.SimpleCsv));

            ////importer = new SimpleConfigurationImporter(parserResolverMock.Object);
            //importer = new SimpleConfigurationImporter(parserResolverMock.Object);
        }


        [Fact]
        public void DetermineParserTypeMustBeCalled()
        {
            throw new NotImplementedException();
            //parserResolverMock.Verify(x => x.Invoke(It.IsAny<ParserType>()), Times.Once);
        }
    }
}
