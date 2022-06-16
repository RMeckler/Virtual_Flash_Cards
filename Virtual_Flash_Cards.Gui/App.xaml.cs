using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Virtual_Flash_Cards.GUI.Model;
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
    protected override void OnStartup(StartupEventArgs e)
    {
      NavigationStore navigationStore = new NavigationStore();
      GlobalSettingsStore globalSettingsStore = new GlobalSettingsStore(new GlobalSettings());


      navigationStore.CurrentViewModel = new HomeViewModel(navigationStore);

      MainWindow = new MainWindow()
      {
        DataContext = new MainViewModel(globalSettingsStore, navigationStore)
      };
      MainWindow.Show();


      base.OnStartup(e);
    }
  }
}
