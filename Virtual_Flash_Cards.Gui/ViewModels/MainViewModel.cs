using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Virtual_Flash_Cards.GUI.Commands;
using Virtual_Flash_Cards.GUI.Utils;

namespace Virtual_Flash_Cards.GUI.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        #region Commands
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateExamCommand { get; }
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateSettingsCommand { get; }
        public ICommand QuitCommand { get; }
        #endregion

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            NavigateHomeCommand = new NavigateHomeCommand(navigationStore);
            NavigateExamCommand = new NavigateExamCommand(navigationStore);
            NavigateEditCommand = new NavigateEditCommand(navigationStore);
            NavigateSettingsCommand = new NavigateSettingsCommand(navigationStore);
            QuitCommand = new QuitCommand();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
