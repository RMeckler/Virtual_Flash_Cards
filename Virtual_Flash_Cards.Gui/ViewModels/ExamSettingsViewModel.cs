using System.Windows.Input;
using Virtual_Flash_Cards.GUI.Commands;
using Virtual_Flash_Cards.GUI.Model;
using Virtual_Flash_Cards.GUI.Services;
using Virtual_Flash_Cards.GUI.Utils;

namespace Virtual_Flash_Cards.GUI.ViewModels
{
    internal class ExamSettingsViewModel : ViewModelBase
    {
      #region Commands
      public ICommand NavigateHomeCommand { get; }
      public ICommand NavigateExamCommand { get; }
      public ICommand StartExamCommand { get; }
    #endregion

    private readonly NavigationStore _navigationStore;


    internal ExamSettingsViewModel(NavigationStore navigationStore)
      {
     
        _navigationStore = navigationStore;
        //NavigateExamCommand = new NavigateCommand<ExamViewModel>(new NavigationService<ExamViewModel>(navigationStore, () => new ExamViewModel(navigationStore)));
        NavigateHomeCommand = new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore)));

        ParameterNavigationService<ExamSettings, ExamViewModel> navigationService = new(navigationStore,
        (parameter) => new ExamViewModel(parameter, navigationStore));
        StartExamCommand = new StartExamCommand(new ExamSettings() { NumberOfCards = 7}, navigationService);
      }
    }
}
