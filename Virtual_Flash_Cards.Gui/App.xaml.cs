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
      services.AddSingleton<GlobalSettingsStore>();

      services.AddTransient<HomeViewModel>(s => new HomeViewModel(s.GetRequiredService<NavigationStore>()));
      //TODO NavigationMitParameterProblematik
      //services.AddTransient<ExamResultViewModel>(s => new NavigationService<ExamSettingsViewModel>(s.GetRequiredService<NavigationStore>(), () => new ExamSettingsViewModel(s.GetRequiredService<NavigationStore>(), homeNavigationService)));
      //services.AddTransient<ExamViewModel>(s => new NavigationService<ExamSettingsViewModel>(s.GetRequiredService<NavigationStore>(), () => new ExamSettingsViewModel(s.GetRequiredService<NavigationStore>(), homeNavigationService)));
      services.AddTransient<ExamSettingsViewModel>(s => new ExamSettingsViewModel(s.GetRequiredService<NavigationStore>(), homeNavigationService(s)));
      services.AddTransient<EditViewModel>(s => new EditViewModel(s.GetRequiredService<NavigationStore>()));
      services.AddTransient<SettingsViewModel>(s => new SettingsViewModel(s.GetRequiredService<GlobalSettingsStore>(), s.GetRequiredService<NavigationStore>()));

      services.AddSingleton<MainViewModel>(s =>
      {
        return new MainViewModel(
          s.GetRequiredService<GlobalSettingsStore>(),
          s.GetRequiredService<NavigationStore>(),
          homeNavigationService(s),
          examSettingsNavigationService(s),
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
    private static NavigationService<HomeViewModel> homeNavigationService(IServiceProvider serviceProvider)
    {
      return new NavigationService<HomeViewModel>(serviceProvider.GetRequiredService<NavigationStore>(), () => serviceProvider.GetRequiredService<HomeViewModel>());
    }

    private static NavigationService<ExamSettingsViewModel> examSettingsNavigationService(IServiceProvider serviceProvider)
    {
      return new NavigationService<ExamSettingsViewModel>(serviceProvider.GetRequiredService<NavigationStore>(), () => serviceProvider.GetRequiredService<ExamSettingsViewModel>());
    }

    //private static NavigationService<ExamViewModel> examNavigationService(IServiceProvider serviceProvider)
    //{
    //  return new ParameterNavigationService<ExamSettings, ExamViewModel>(serviceProvider.GetRequiredService<NavigationStore>(), serviceProvider.GetRequiredService<ExamViewModel>().Settings,
    //   (parameter) => new ExamViewModel(parameter, serviceProvider.GetRequiredService<NavigationStore>()));

    //  //new NavigationService<ExamViewModel>(serviceProvider.GetRequiredService<NavigationStore>(), () => serviceProvider.GetRequiredService<ExamViewModel>());
    //}

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
