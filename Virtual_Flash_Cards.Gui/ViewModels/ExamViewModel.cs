﻿using System.Windows.Input;
using Virtual_Flash_Cards.GUI.Commands;
using Virtual_Flash_Cards.GUI.Utils;

namespace Virtual_Flash_Cards.GUI.ViewModels
{
    internal class ExamViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }

        public ExamViewModel(NavigationStore navigationStore)
        {
            NavigateHomeCommand = new NavigateHomeCommand(navigationStore);
        }
    }
}
