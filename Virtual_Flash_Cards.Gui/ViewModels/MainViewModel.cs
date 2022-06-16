using System.Windows.Input;
using Virtual_Flash_Cards.GUI.Commands;
using Virtual_Flash_Cards.GUI.Services;
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
        public ICommand NavigateExamSettingsCommand { get; }
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateSettingsCommand { get; }
        public ICommand QuitCommand { get; }
        #endregion

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore)));
            NavigateExamSettingsCommand = new NavigateCommand<ExamSettingsViewModel>(new NavigationService<ExamSettingsViewModel>(navigationStore, () => new ExamSettingsViewModel(navigationStore)));
            NavigateEditCommand = new NavigateCommand<EditViewModel>(new NavigationService<EditViewModel>(navigationStore, () => new EditViewModel(navigationStore))); 
            NavigateSettingsCommand = new NavigateCommand<SettingsViewModel>(new NavigationService<SettingsViewModel>(navigationStore, () => new SettingsViewModel(navigationStore)));
            QuitCommand = new QuitCommand();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
