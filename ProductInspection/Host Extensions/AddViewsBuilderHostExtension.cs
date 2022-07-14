using Microsoft.Extensions.DependencyInjection;
using ProductInspection.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInspection.Host_Extensions
{
    internal static class AddViewsBuilderHostExtension
    {
        /// <summary>
        /// Добавляет главное окно в контейнер и указывает ему контекст данных
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static ServiceCollection AddViews(this ServiceCollection services)
        {
            services.AddSingleton(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            return services;
        }
    }
}
