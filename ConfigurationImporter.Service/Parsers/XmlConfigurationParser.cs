using ConfigurationImporter.Entities;
using ConfigurationImporter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConfigurationImporter.Service.Importers
{
    public class XmlConfigurationParser : IConfigurationParser
    {
        public IList<IConfiguration> Parse(string filePath)
        {
            List<IConfiguration> result = new List<IConfiguration>();
            string content = File.ReadAllText(filePath);
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.LoadXml(content);
            }
            catch(XmlException ex)
            {
                throw new ParseConfigException($"Не удалость загрузить xml отчет по пути {filePath}.", ex);
            }
            XmlNodeList nodes = xDoc.GetElementsByTagName("config");
            if (nodes.Count == 0)
                throw new ParseConfigException($"Не найдены конфигурации в файле по пути {filePath}.");

            foreach (XmlNode node in nodes)
            {
                XmlNode? nameNode = node["name"];
                XmlNode? descriptionNode = node["description"];
                if (nameNode == null || descriptionNode == null)
                    throw new ParseConfigException($"В одной из конфигураций в файле " +
                        $"{filePath} не найдено имя или описание.");
                result.Add(new Configuration()
                {
                    Name = nameNode.InnerText,
                    Description = descriptionNode.InnerText
                });
            }

            return result;
        }
    }
}
