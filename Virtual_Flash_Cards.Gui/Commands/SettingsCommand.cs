using System.Globalization;
using System.Threading;
using System.Windows;
using Virtual_Flash_Cards.GUI.Model;
using Virtual_Flash_Cards.GUI.Services;
using Virtual_Flash_Cards.GUI.Store;
using Virtual_Flash_Cards.GUI.ViewModels;

namespace Virtual_Flash_Cards.GUI.Commands
{
  internal class SettingsCommand : CommandBase
  {
    private GlobalSettings _globalSettings;

    public SettingsCommand(GlobalSettings globalSettings)
    {
      _globalSettings = globalSettings;
    }

    public override void Execute(object parameter)
    {
      var CI = new CultureInfo(_globalSettings.Language);
      Thread.CurrentThread.CurrentCulture = CI;
      Thread.CurrentThread.CurrentUICulture = CI;
      CultureInfo.DefaultThreadCurrentCulture = CI;
      CultureInfo.DefaultThreadCurrentUICulture = CI;
    }
  }
}
