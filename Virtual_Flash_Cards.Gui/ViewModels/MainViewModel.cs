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

    public MainViewModel(GlobalSettingsStore globalSettingsStore, NavigationStore navigationStore,
            INavigationService homeNavigationService,
            INavigationService ExamSettingsNavigationService,
            INavigationService EditNavigationService,
            INavigationService SettingsNavigationService)
    {
      _globalSettingsStore = globalSettingsStore;
      _navigationStore = navigationStore;
      _globalSettingsStore.CurrentGlobalSettingsChanged += OnGlobalSettingsChanged;
      _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
      NavigateHomeCommand = new NavigationCommand(homeNavigationService);
      NavigateExamSettingsCommand = new NavigationCommand(ExamSettingsNavigationService);
      NavigateEditCommand = new NavigationCommand(EditNavigationService);
      NavigateSettingsCommand = new NavigationCommand(SettingsNavigationService);
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
