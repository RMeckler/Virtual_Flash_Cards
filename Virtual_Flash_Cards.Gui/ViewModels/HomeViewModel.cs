using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Flash_Cards.GUI.Store;

namespace Virtual_Flash_Cards.GUI.ViewModels
{
  internal class HomeViewModel : ViewModelBase
    {
    private NavigationStore navigationStore;

    public HomeViewModel(NavigationStore navigationStore)
    {
      this.navigationStore = navigationStore;
    }
  }
}
