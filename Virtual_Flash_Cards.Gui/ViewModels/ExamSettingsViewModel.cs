using System;
using System.Windows.Input;
using Virtual_Flash_Cards.GUI.Commands;
using Virtual_Flash_Cards.GUI.Model;
using Virtual_Flash_Cards.GUI.Services;
using Virtual_Flash_Cards.GUI.Store;

namespace Virtual_Flash_Cards.GUI.ViewModels
{
  internal class ExamSettingsViewModel : ViewModelBase
  {
    #region Commands
    public ICommand NavigateHomeCommand { get; }
    public ICommand NavigateExamCommand { get; }
    #endregion

    private readonly NavigationStore _navigationStore;


    internal ExamSettingsViewModel(NavigationStore navigationStore)
    {
      
      _navigationStore = navigationStore;
      NavigateHomeCommand = new NavigateCommand(new NavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore)));

      ParameterNavigationService<ExamSettings, ExamViewModel> navigationService = new(navigationStore, CreateExamSettings(),
      (parameter) => new ExamViewModel(parameter, navigationStore));
      NavigateExamCommand = new NavigateCommand(navigationService);
    }

    private ExamSettings CreateExamSettings()
    {
      return new ExamSettings()
      {
        OrderOfCards = "ok",
        NumberOfCards = 1000
      };
    }
  }
}
