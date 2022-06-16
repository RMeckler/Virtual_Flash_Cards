using System.Windows.Input;
using Virtual_Flash_Cards.GUI.Commands;
using Virtual_Flash_Cards.GUI.Model;
using Virtual_Flash_Cards.GUI.Services;
using Virtual_Flash_Cards.GUI.Store;

namespace Virtual_Flash_Cards.GUI.ViewModels
{
  internal class ExamResultViewModel : ViewModelBase
  {
    #region Commands
    public ICommand NavigateHomeCommand { get; }
    public ICommand NavigateExamSettingsCommand { get; }
    public ICommand NavigateExamCommand { get; }

    #endregion

    private readonly NavigationStore _navigationStore;
    private readonly ExamSettings _settings;

    internal ExamResultViewModel(ExamSettings settings, 
      NavigationStore navigationStore, 
      INavigationService homeNavigationService,
      IParameterNavigationService<ExamSettings> examNavigationService,
      INavigationService examSettingsNavigationService)
    {
      _navigationStore = navigationStore;
      _settings = settings;

      NavigateExamSettingsCommand = new NavigationCommand( examSettingsNavigationService);
      NavigateHomeCommand = new NavigationCommand(homeNavigationService);

      NavigateExamCommand = new ParameterNavigationCommand<ExamSettings>(examNavigationService, _settings);
    }

    ~ExamResultViewModel()
    {

    }
  }
}
