using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Input;
using Virtual_Flash_Cards.GUI.Commands;
using Virtual_Flash_Cards.GUI.Model;
using Virtual_Flash_Cards.GUI.Store;

namespace Virtual_Flash_Cards.GUI.ViewModels
{
  internal class SettingsViewModel : ViewModelBase
  {

    #region Commands

    public ICommand SettingsCommand { get; }

    #endregion

    private GlobalSettingsStore _globalSettingsStore;


    public string Language
    {
      get { return _globalSettingsStore.GlobalSettings.Language; }
      set { _globalSettingsStore.GlobalSettings.Language = value; }
    }

    public bool NightMode
    {
      get { return _globalSettingsStore.GlobalSettings.NightMode; }
      set { _globalSettingsStore.GlobalSettings.NightMode = value; }
    }

    public List<string> LanguagesList
    {
      get { return _globalSettingsStore.GlobalSettings.LanguagesList; }
    }

    public SettingsViewModel(GlobalSettingsStore globalSettingsStore, NavigationStore navigationStore)
    {
      _globalSettingsStore = globalSettingsStore;
      SettingsCommand = new SettingsCommand(globalSettingsStore.GlobalSettings);
    }
  }
}
