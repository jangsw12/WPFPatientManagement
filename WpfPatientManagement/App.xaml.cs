using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfPatientManagement.Repositories;
using WpfPatientManagement.Services;
using WpfPatientManagement.Stores;
using WpfPatientManagement.ViewModels;
using WpfPatientManagement.Views;

namespace WpfPatientManagement
{
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();

            Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            var mainView = Services.GetRequiredService<MainView>();
            mainView.Show();
        }

        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Repositories
            services.AddSingleton<IUserRepository>(sp => new UserRepository(WpfPatientManagement.Properties.Settings.Default.ConnectionStr));
            services.AddSingleton<IPatientRepository>(sp => new PatientRepository(WpfPatientManagement.Properties.Settings.Default.ConnectionStr));
            services.AddSingleton<IRecordRepository>(sp => new RecordRepository(WpfPatientManagement.Properties.Settings.Default.ConnectionStr));

            // Stores
            services.AddSingleton<MainNavigationStore>();

            // Services
            services.AddSingleton<INavigationService, NavigationService>();

            // ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<FrontViewModel>();
            services.AddSingleton<TreatmentViewModel>();

            services.AddSingleton<LoginControlViewModel>();
            services.AddSingleton<SignupControlViewModel>();

            services.AddSingleton<PatientListControlViewModel>();
            services.AddSingleton<PatientActionsControlViewModel>();
            services.AddSingleton<PatientRecordControlViewModel>();

            // Views
            services.AddSingleton(s => new MainView()
            {
                DataContext = s.GetRequiredService(typeof(MainViewModel))
            });

            return services.BuildServiceProvider();
        }
    }
}