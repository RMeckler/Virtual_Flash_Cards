using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Flash_Cards.GUI.Utils;
using Virtual_Flash_Cards.GUI.ViewModels;

namespace Virtual_Flash_Cards.GUI.Commands
{
    internal class NavigateExamCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;


        public NavigateExamCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new ExamViewModel(_navigationStore);
        }
    }
}
