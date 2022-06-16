using System.Windows.Input;
using Virtual_Flash_Cards.GUI.Commands;
using Virtual_Flash_Cards.GUI.Model;
using Virtual_Flash_Cards.GUI.Services;
using Virtual_Flash_Cards.GUI.Store;

namespace Virtual_Flash_Cards.GUI.ViewModels
{
  internal class MainViewModel : ViewModelBase
  {
    private readonly NavigationStore _navigationStore;
    private readonly GlobalSettingsStore _globalSettingsStore;

    public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
    public GlobalSettings GlobalSettings => _globalSettingsStore.GlobalSettings;

    #region Commands
    public ICommand NavigateHomeCommand { get; }
    public ICommand NavigateExamCommand { get; }
    public ICommand NavigateExamSettingsCommand { get; }
    public ICommand NavigateEditCommand { get; }
    public ICommand NavigateSettingsCommand { get; }
    public ICommand QuitCommand { get; }
    #endregion

    public MainViewModel(GlobalSettingsStore globalSettingsStore, NavigationStore navigationStore)
    {
      _globalSettingsStore = globalSettingsStore;
      _navigationStore = navigationStore;
      _globalSettingsStore.CurrentGlobalSettingsChanged += OnGlobalSettingsChanged;  
      _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
      NavigateHomeCommand = new NavigateCommand(new NavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel( navigationStore )));
      NavigateExamSettingsCommand = new NavigateCommand(new NavigationService<ExamSettingsViewModel>(navigationStore, () => new ExamSettingsViewModel(navigationStore)));
      NavigateEditCommand = new NavigateCommand(new NavigationService<EditViewModel>(navigationStore, () => new EditViewModel(navigationStore)));
      NavigateSettingsCommand = new NavigateCommand(new NavigationService<SettingsViewModel>(navigationStore, () => new SettingsViewModel(globalSettingsStore, navigationStore)));
      QuitCommand = new QuitCommand();
    }

    private void OnCurrentViewModelChanged()
    {
      OnPropertyChanged(nameof(CurrentViewModel));
    }

    private void OnGlobalSettingsChanged()
    {
      OnPropertyChanged(nameof(CurrentViewModel));
    }

    internal override void Dispose()
    {
      _globalSettingsStore.CurrentGlobalSettingsChanged -= OnGlobalSettingsChanged;
      _navigationStore.CurrentViewModelChanged -= OnCurrentViewModelChanged;
      base.Dispose();
    }
  }
}
