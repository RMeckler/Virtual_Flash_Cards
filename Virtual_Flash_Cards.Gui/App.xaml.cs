using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Virtual_Flash_Cards.GUI.Model;
using Virtual_Flash_Cards.GUI.Services;
using Virtual_Flash_Cards.GUI.Store;
using Virtual_Flash_Cards.GUI.View;
using Virtual_Flash_Cards.GUI.ViewModels;

namespace Virtual_Flash_Cards.GUI
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private readonly IServiceProvider _serviceProvider;

    public App()
    {
      IServiceCollection services = new ServiceCollection();

      services.AddSingleton<NavigationStore>();
      services.AddSingleton<GlobalSettings>();
      services.AddTransient<ExamSettings>();
      services.AddSingleton<GlobalSettingsStore>();

      services.AddTransient<HomeViewModel>(s => new HomeViewModel(s.GetRequiredService<NavigationStore>()));
    services.AddTransient<ExamResultViewModel>(s => new ExamResultViewModel(s.GetRequiredService<ExamSettings>(),s.GetRequiredService<NavigationStore>(), CreateHomeNavigationService(s),
        CreateExamNavigationService(s), CreateExamSettingsNavigationService(s)));
      services.AddTransient<ExamViewModel>(s => new ExamViewModel(s.GetRequiredService<ExamSettings>(), s.GetRequiredService<NavigationStore>(), CreateHomeNavigationService(s), CreateExamResultNavigationService(s)));
      services.AddTransient<ExamSettingsViewModel>(s => new ExamSettingsViewModel(s.GetRequiredService<NavigationStore>(), CreateHomeNavigationService(s), CreateExamNavigationService(s)));
      services.AddTransient<EditViewModel>(s => new EditViewModel(s.GetRequiredService<NavigationStore>()));
      services.AddTransient<SettingsViewModel>(s => new SettingsViewModel(s.GetRequiredService<GlobalSettingsStore>(), s.GetRequiredService<NavigationStore>()));

      services.AddSingleton<MainViewModel>(s =>
      {
        return new MainViewModel(
          s.GetRequiredService<GlobalSettingsStore>(),
          s.GetRequiredService<NavigationStore>(),
          CreateHomeNavigationService(s),
          CreateExamSettingsNavigationService(s),
          editNavigationService(s),
          settingsNavigationService(s)
          );
      });


      services.AddSingleton<INavigationService>(s => 
      {
        return new NavigationService<HomeViewModel>(
          s.GetRequiredService<NavigationStore>(), () => new HomeViewModel(s.GetRequiredService<NavigationStore>()));
      });
      services.AddSingleton<MainWindow>( s => new MainWindow()
      {
        DataContext = s.GetRequiredService<MainViewModel>()
      });
      _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
      INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
      initialNavigationService.Navigate();

      MainWindow = _serviceProvider.GetService<MainWindow>(); 
      MainWindow.Show();


      base.OnStartup(e);
    }

    #region Helper methods
    private static NavigationService<HomeViewModel> CreateHomeNavigationService(IServiceProvider serviceProvider)
    {
      return new NavigationService<HomeViewModel>(serviceProvider.GetRequiredService<NavigationStore>(), () => serviceProvider.GetRequiredService<HomeViewModel>());
    }

    private static NavigationService<ExamSettingsViewModel> CreateExamSettingsNavigationService(IServiceProvider serviceProvider)
    {
      return new NavigationService<ExamSettingsViewModel>(serviceProvider.GetRequiredService<NavigationStore>(), () => serviceProvider.GetRequiredService<ExamSettingsViewModel>());
    }

    private static ParameterNavigationService<ExamSettings, ExamViewModel> CreateExamNavigationService(IServiceProvider serviceProvider)
    {
      return new ParameterNavigationService<ExamSettings, ExamViewModel>(serviceProvider.GetRequiredService<NavigationStore>(), 
       (parameter) => new ExamViewModel(parameter, serviceProvider.GetRequiredService<NavigationStore>(), CreateHomeNavigationService(serviceProvider), CreateExamResultNavigationService(serviceProvider)));
    }

    private static ParameterNavigationService<ExamSettings, ExamResultViewModel> CreateExamResultNavigationService(IServiceProvider serviceProvider)
    {
      return new ParameterNavigationService<ExamSettings, ExamResultViewModel>(serviceProvider.GetRequiredService<NavigationStore>(),
              (parameter) => new ExamResultViewModel(parameter, serviceProvider.GetRequiredService<NavigationStore>(), 
              CreateHomeNavigationService(serviceProvider),
              CreateExamNavigationService(serviceProvider),
              CreateExamSettingsNavigationService(serviceProvider)
              ));
    }

    private static NavigationService<EditViewModel> editNavigationService(IServiceProvider serviceProvider)
    {
      return new NavigationService<EditViewModel>(serviceProvider.GetRequiredService<NavigationStore>(), () => serviceProvider.GetRequiredService<EditViewModel>());
    }

    private static NavigationService<SettingsViewModel> settingsNavigationService(IServiceProvider serviceProvider)
    {
      return new NavigationService<SettingsViewModel>(serviceProvider.GetRequiredService<NavigationStore>(), () => serviceProvider.GetRequiredService<SettingsViewModel>());
    }
    #endregion
  }
}
