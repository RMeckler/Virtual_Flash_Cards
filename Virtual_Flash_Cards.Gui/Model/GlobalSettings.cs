using System.Collections.Generic;
using System.Windows.Data;

namespace Virtual_Flash_Cards.GUI.Model
{
  internal class GlobalSettings
  {
    public bool NightMode = true;
    public string Language = "en-en";

    public List<string> LanguagesList { get; } = new List<string>()
    {
      "en-en",
      "de-de"
    };
  }
}
