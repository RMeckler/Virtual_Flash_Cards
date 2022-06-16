using System.Windows.Input;
using Virtual_Flash_Cards.GUI.Commands;
using Virtual_Flash_Cards.GUI.Model;
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
    private readonly ExamSettings _settings;

    public string OrderOfCards => _settings.OrderOfCards;
    public int NumberOfCards => _settings.NumberOfCards;

    internal ExamViewModel(ExamSettings settings,NavigationStore navigationStore)
    {
      _navigationStore = navigationStore;
      _settings = settings;
      NavigateExamResultCommand = new NavigateCommand<ExamResultViewModel>(new NavigationService<ExamResultViewModel>(navigationStore, () => new ExamResultViewModel(navigationStore)));
      NavigateHomeCommand = new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore)));

    }
  }
}
