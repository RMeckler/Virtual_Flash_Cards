using System.Windows;
using Virtual_Flash_Cards.GUI.Services;
using Virtual_Flash_Cards.GUI.Store;
using Virtual_Flash_Cards.GUI.ViewModels;

namespace Virtual_Flash_Cards.GUI.Commands
{
  internal class NavigateCommand<TViewModel> : CommandBase
        where TViewModel : ViewModelBase
  {
    private readonly NavigationService<TViewModel> _navigationService;

    public NavigateCommand(NavigationService<TViewModel> navigationService)
    {
      _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
       _navigationService.Navigate();

    }
  }
}
