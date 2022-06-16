using System.Windows.Input;
using Virtual_Flash_Cards.GUI.Commands;
using Virtual_Flash_Cards.GUI.Services;
using Virtual_Flash_Cards.GUI.Utils;

namespace Virtual_Flash_Cards.GUI.ViewModels
{
    internal class ExamViewModel : ViewModelBase
    {
    #region Commands
    public ICommand NavigateHomeCommand { get; }
    public ICommand NavigateExamResultCommand { get; }
    #endregion

    private readonly NavigationStore _navigationStore;

    internal ExamViewModel(NavigationStore navigationStore)
    {
      _navigationStore = navigationStore;
      NavigateExamResultCommand = new NavigateCommand<ExamResultViewModel>(new NavigationService<ExamResultViewModel>(navigationStore, () => new ExamResultViewModel(navigationStore)));
      NavigateHomeCommand = new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore)));
    }
  }
}
