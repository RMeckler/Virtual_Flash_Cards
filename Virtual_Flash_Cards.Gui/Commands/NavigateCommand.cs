using System.Windows;
using Virtual_Flash_Cards.GUI.Services;
using Virtual_Flash_Cards.GUI.Store;
using Virtual_Flash_Cards.GUI.ViewModels;

namespace Virtual_Flash_Cards.GUI.Commands
{
  internal class NavigateCommand : CommandBase
  {
    private readonly INavigationService _navigationService;

    public NavigateCommand(INavigationService navigationService)
    {
      _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
       _navigationService.Navigate();

    }
  }
}
