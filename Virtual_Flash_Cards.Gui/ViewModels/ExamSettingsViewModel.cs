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
    private readonly ExamSettings _examSettings;


    internal ExamSettingsViewModel(NavigationStore navigationStore, 
      INavigationService homeNavigationService,
      IParameterNavigationService<ExamSettings> examNavigationService)
    {
      
      _navigationStore = navigationStore;
      NavigateHomeCommand = new NavigationCommand(homeNavigationService);
      NavigateExamCommand = new ParameterNavigationCommand<ExamSettings>(examNavigationService, CreateExamSettings());
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
