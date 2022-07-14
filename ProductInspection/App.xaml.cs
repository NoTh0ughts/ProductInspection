using Microsoft.Extensions.DependencyInjection;
using ProductInspection.Host_Extensions;
using ProductInspection.Services;
using System.Windows;

namespace ProductInspection
{
    /// <summary>
    /// Здесь инициализируется контейнер DI
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);

            serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainWindow>();

            services.AddServices()
                    .AddViewModels()
                    .AddViews()
                    .UseDatabase();
        }
    }
}
