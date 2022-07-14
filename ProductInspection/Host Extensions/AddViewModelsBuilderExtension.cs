using Microsoft.Extensions.DependencyInjection;
using ProductInspection.MVVM.ViewModel;
using ProductInspection.MVVM.ViewModel.Factory;
using ProductInspection.Services;
using System;

namespace ProductInspection.Host_Extensions
{
    internal static class AddViewModelsBuilderExtension
    {
        /// <summary>
        /// Добавляет ViewModel и их фабричные методы получения 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static ServiceCollection AddViewModels(this ServiceCollection services)
        {
            _ = services.AddTransient(CreateHomeViewModel)
                        .AddTransient<MainViewModel>();


            _ = services.AddSingleton<CreateViewModel<HomeViewModel>>
                (s => () => s.GetRequiredService<HomeViewModel>());

            services.AddSingleton<IViewModelFactory, ViewModelFactory>();
            
            return services;
        }

        /// <summary>
        /// Разрешает создание новой главной модели представления
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private static HomeViewModel CreateHomeViewModel(IServiceProvider services)
        {
            return new HomeViewModel(services.GetRequiredService<DatabaseProductsService>());
        }
    }
}
