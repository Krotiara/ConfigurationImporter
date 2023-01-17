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
            catch(Exception ex) when (
                ex is GetConfigParserTypeException ||
                ex is GetConfigParserException ||
                ex is ParseConfigException)
            {
                throw new ImportConfigurationsException(
                    $"Ошибка загрузки файла конфигурации {path}", ex);
            }
            catch(Exception ex)
            {
                throw new ImportConfigurationsException(
                    $"Непредвиденная ошибка загрузки файла конфигурации {path}", ex);
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
