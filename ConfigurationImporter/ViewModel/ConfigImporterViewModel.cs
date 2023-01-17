using BindingCommands;
using ConfigurationImporter.Entities;
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
using System.Windows;

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
            try
            {  
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    //TODO валидацию пути
                    IList<IConfiguration> configs = configurationImporter.Import(openFileDialog.FileName);
                    Configurations.Clear();
                    Configurations.AddRange(configs);
                }
            }
            catch(ImportConfigurationsException ex)
            {
                string message = ex.InnerException != null ? 
                    $"{ex.Message}: {ex.InnerException.Message}." : 
                    $"{ex.Message}";
                MessageBox.Show(message, 
                    "Ошибка загрузки файла конфигураций", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Непредвиденная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        });
    }
}
