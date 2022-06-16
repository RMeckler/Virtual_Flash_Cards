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
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore));
            NavigateExamCommand = new NavigateCommand<ExamViewModel>(navigationStore, () => new ExamViewModel(navigationStore));
            NavigateEditCommand = new NavigateCommand<EditViewModel>(navigationStore, () => new EditViewModel(navigationStore)); 
            NavigateSettingsCommand = new NavigateCommand<SettingsViewModel>(navigationStore, () => new SettingsViewModel(navigationStore));
            QuitCommand = new QuitCommand();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
