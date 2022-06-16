using System;
using Virtual_Flash_Cards.GUI.Model;

namespace Virtual_Flash_Cards.GUI.Store
{
  internal class GlobalSettingsStore
  {
  
    private GlobalSettings globalSettings;

    public GlobalSettingsStore(GlobalSettings globalSettings)
    {
      this.globalSettings = globalSettings;
    }

    public GlobalSettings GlobalSettings
    {
      get { return globalSettings; }
      set { globalSettings = value;
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
