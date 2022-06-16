using Virtual_Flash_Cards.GUI.Model;
using Virtual_Flash_Cards.GUI.Services;
using Virtual_Flash_Cards.GUI.Store;
using Virtual_Flash_Cards.GUI.ViewModels;

namespace Virtual_Flash_Cards.GUI.Commands
{
  internal class StartExamCommand : CommandBase
  {
    private readonly ParameterNavigationService<ExamSettings, ExamViewModel> _navigationService;
    private readonly ExamSettings _examSettings;


    public StartExamCommand(ExamSettings settings, ParameterNavigationService<ExamSettings, ExamViewModel> navigationService)
    {
      _navigationService = navigationService;
      _examSettings = settings;
    }

    public override void Execute(object parameter)
    {
      _navigationService.Navigate(_examSettings);
    }
  }
}
