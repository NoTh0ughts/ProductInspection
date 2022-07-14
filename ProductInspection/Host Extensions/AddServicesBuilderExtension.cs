using Microsoft.Extensions.DependencyInjection;
using ProductInspection.Controls;
using ProductInspection.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInspection.Host_Extensions
{
    
    internal static class AddServicesBuilderExtension
    {
        /// <summary>
        /// Добавляет сервисы программы к контейнеру инъекции зависимостей
        /// </summary>
        public static ServiceCollection AddServices(this ServiceCollection services)
        {
            services.AddSingleton<INavigationStore, NavigationStore>();
            services.AddSingleton<IProductsService, DatabaseProductsService>();
            return services;
        }
    }
}
