using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using ProductInspection.Services.Models;

namespace ProductInspection.Services
{
    /// <summary>
    /// Загрузчик конфига, запускается при инициализации контейнера DI в App.xaml.cs
    /// </summary>
    public static class ConfigurationLoader
    {
        public static ServiceCollection UseDatabase(this ServiceCollection services)
        {
            // Получаем путь к билду и проверяем есть ли конфиг
            var pathToConfig =
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                                   ProgramContants.ConfigFilename);
            if(File.Exists(pathToConfig) == false)
            {
                throw new FileNotFoundException();
            }


            // Считываем все строки и превращаем их в словарь
            string[] lines = File.ReadAllLines(pathToConfig);
            Dictionary<string, string> configDictionary = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                var parts = line.Split('=');
                configDictionary.Add(parts[0], parts[1]);
            }

            // Заполняем конфиг и добавляем его в DI
            try
            {
                DatabaseConfigurationModel config = new DatabaseConfigurationModel
                {
                    InitialCatalog = configDictionary["InitialCatalog"],
                    DataSource = configDictionary["DataSource"],
                    IntegratedSecurity = Convert.ToBoolean(configDictionary["IntegratedSecurity"])
                };

                services.AddSingleton(config);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on getting values from config file " + ex.ToString());
            }
          
            
            return services;
        }
    }
}
