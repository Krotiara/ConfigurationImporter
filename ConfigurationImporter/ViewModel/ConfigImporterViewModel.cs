using BindingCommands;
using ConfigurationImporter.Interfaces;
using ConfigurationImporter.Model;
using Microsoft.Win32;
using NotifierAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationImporter.ViewModel
{
    public class ConfigImporterViewModel: Notifier
    {
        private readonly IConfigurationImporter configurationImporter;

        public ObservableCollection<IConfiguration> Configurations { get; set; }

        public ConfigImporterViewModel(IConfigurationImporter configurationImporter)
        {
            Configurations = new ObservableCollection<IConfiguration>();
            this.configurationImporter = configurationImporter;
        }


        public RelayCommand ImportConfigsCommand => new RelayCommand(_ =>
        {
            //TOODO обработка ошибок
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                //TODO валидацию пути
                IList<IConfiguration> configs = configurationImporter.Import(openFileDialog.FileName);
                Configurations.Clear();
                Configurations.AddRange(configs);
            }
        });
    }
}
