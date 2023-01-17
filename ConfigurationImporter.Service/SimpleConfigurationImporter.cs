using ConfigurationImporter.Entities;
using ConfigurationImporter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConfigurationImporter.Entities.ParserResolverDelegate;

namespace ConfigurationImporter.Service
{
    public class SimpleConfigurationImporter : IConfigurationImporter
    {
        private readonly ParserResolver parserResolver;


        public SimpleConfigurationImporter(ParserResolver parserResolver)
        {
            this.parserResolver = parserResolver;
        }


        public IList<IConfiguration> Import(string path)
        {
            try
            {
                ParserType parserType = GetParserType(path);
                IConfigurationParser parser = parserResolver.Invoke(parserType);
                return parser.Parse(path);
            }
            catch(GetConfigParserTypeException ex)
            {
                //TODO обработка
                throw new NotImplementedException();
            }
            catch(GetConfigParserException ex)
            {
                //TODO обработка
                throw new NotImplementedException();
            }
            catch(ParseConfigException ex)
            {
                //TODO обработка
                throw new NotImplementedException();
            }
        }


        private ParserType GetParserType(string path)
        {
            
#warning В рамках задания определение типа сделано по-простому через разрешение файла. В случае, если для одного разрешения файла предусматривается более одного парсера, следует изменить метод на анализ структуры файла.
            string extension = Path.GetExtension(path);
            return extension switch
            {
                ".csv" => ParserType.SimpleCsv,
                ".xml" => ParserType.SimpleXml,
                _ => throw new GetConfigParserTypeException($"Cant resolve parser type for path = {path}"),
            };
        }
    }
}
