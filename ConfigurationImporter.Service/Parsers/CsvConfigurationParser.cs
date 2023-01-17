using ConfigurationImporter.Entities;
using ConfigurationImporter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationImporter.Service.Importers
{
    public class CsvConfigurationParser : IConfigurationParser
    {
        public IList<IConfiguration> Parse(string filePath)
        {
#warning В рамках задания формат csv соответсвует просто записям без заголовков, где 0 - имя, 1 - описание конфигурации. При расширении форматов csv необходим более умный парсер. В рамках задания сделан простой парсер для определенного формата.
            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
            {
                List<IConfiguration> configurations = new List<IConfiguration>();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');
                    configurations.Add(new Configuration() { Name = values[0], Description = values[1]});
                }
                return configurations;
            }
        }
    }
}
