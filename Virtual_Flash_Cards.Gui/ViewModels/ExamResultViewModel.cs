using System.Windows.Input;
using Virtual_Flash_Cards.GUI.Commands;
using Virtual_Flash_Cards.GUI.Services;
using Virtual_Flash_Cards.GUI.Utils;

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

    internal ExamResultViewModel(NavigationStore navigationStore)
    {

      _navigationStore = navigationStore;
      NavigateExamSettingsCommand = new NavigateCommand<ExamSettingsViewModel>(new NavigationService<ExamSettingsViewModel>(navigationStore, () => new ExamSettingsViewModel(navigationStore)));
      NavigateExamCommand = new NavigateCommand<ExamViewModel>(new NavigationService<ExamViewModel>(navigationStore, () => new ExamViewModel(navigationStore)));
      NavigateHomeCommand = new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore)));
    }
  }
}
