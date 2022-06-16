using Virtual_Flash_Cards.GUI.Model;
using Virtual_Flash_Cards.GUI.Services;
using Virtual_Flash_Cards.GUI.Utils;
using Virtual_Flash_Cards.GUI.ViewModels;

namespace Virtual_Flash_Cards.GUI.Commands
{
  internal class StartExamCommand : CommandBase
  {
    private readonly ParameterNavigationService<ExamSettings, ExamViewModel> _navigationService;
    private readonly NavigationStore _navigationStore;

    public StartExamCommand(ExamSettings settings, ParameterNavigationService<ExamSettings, ExamViewModel> navigationService)
    {
      _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
      ExamSettings settings = new ExamSettings()
      {
        OrderOfCards = "Normal",
        NumberOfCards = 5
      };

      _navigationService.Navigate(settings);
    }
  }
}
