using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Flash_Cards.GUI.Utils;
using Virtual_Flash_Cards.GUI.ViewModels;

namespace Virtual_Flash_Cards.GUI.Commands
{
    internal class NavigateSettingsCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;


        public NavigateSettingsCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new SettingsViewModel(_navigationStore);
        }
    }
}
