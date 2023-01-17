using ConfigurationImporter.Entities;
using ConfigurationImporter.Interfaces;
using ConfigurationImporter.Service;
using ConfigurationImporter.Service.Importers;
using ConfigurationImporter.View;
using ConfigurationImporter.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ConfigurationImporter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;
       

        public App()
        {
            host = Host.CreateDefaultBuilder()
            .ConfigureServices((services) =>
            {
                services.AddSingleton<ConfigImporterView>();
                services.AddSingleton<ConfigImporterViewModel>();
                services.AddTransient<IConfiguration, Configuration>();
                services.AddTransient<IConfigurationImporter, SimpleConfigurationImporter>();
                services.AddTransient<CsvConfigurationParser>();
                services.AddTransient<XmlConfigurationParser>();
                services.AddTransient<ParserResolverDelegate.ParserResolver>(factory => parserType =>
                {
                    using (ServiceProvider serviceProvider = services.BuildServiceProvider())
                    {
                        switch (parserType)
                        {
                            case ParserType.SimpleCsv:
                                return (IConfigurationParser)serviceProvider
                                .GetService(typeof(CsvConfigurationParser));
                            case ParserType.SimpleXml:
                                return (IConfigurationParser)serviceProvider
                                .GetService(typeof(XmlConfigurationParser));
                            default: throw new GetConfigParserException($"Cant resolve parser for type = {parserType}");         
                        }
                    }
                });
            })
            .Build();
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            host.Start();

            MainWindow = host.Services.GetRequiredService<ConfigImporterView>();
            MainWindow.Show();

            base.OnStartup(e);
        }


        protected override void OnExit(ExitEventArgs e)
        {
            host.StopAsync();
            host.Dispose();

            base.OnExit(e);
        }
    }
}

