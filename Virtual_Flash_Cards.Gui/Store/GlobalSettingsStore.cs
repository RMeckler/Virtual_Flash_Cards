using System;
using Virtual_Flash_Cards.GUI.Model;

namespace Virtual_Flash_Cards.GUI.Store
{
  internal class GlobalSettingsStore
  {
  
    private GlobalSettings _globalSettings;

    public GlobalSettingsStore(GlobalSettings globalSettings)
    {
      this._globalSettings = globalSettings;
    }

    public GlobalSettings GlobalSettings
    {
      get { return _globalSettings; }
      set { _globalSettings = value;
        OnCurrentGlobalSettingsChanged();
      }
    }

    public event Action CurrentGlobalSettingsChanged;

    private void OnCurrentGlobalSettingsChanged()
    {
      CurrentGlobalSettingsChanged?.Invoke();
    }
  }
}
