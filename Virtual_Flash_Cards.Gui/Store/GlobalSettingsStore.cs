using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Flash_Cards.GUI.Model;

namespace Virtual_Flash_Cards.GUI.Store
{
  internal class GlobalSettingsStore
  {
    private GlobalSettings globalSettings;

    public GlobalSettings GlobalSettings
    {
      get { return globalSettings; }
      set { globalSettings = value; }
    }
  }
}
