using System.Windows;
using Virtual_Flash_Cards.GUI.Services;
using Virtual_Flash_Cards.GUI.Store;
using Virtual_Flash_Cards.GUI.ViewModels;

namespace Virtual_Flash_Cards.GUI.Commands
{
  internal class NavigationCommand : CommandBase
  {
    private readonly INavigationService _navigationService;

    public NavigationCommand(INavigationService navigationService)
    {
      _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
       _navigationService.Navigate();

    }
  }

  internal class ParameterNavigationCommand<TParameter> : CommandBase
  {
    private readonly IParameterNavigationService<TParameter> _navigationService;
    private readonly TParameter _parameter;

    public ParameterNavigationCommand(IParameterNavigationService<TParameter> navigationService, TParameter parameter)
    {
      _navigationService = navigationService;
      _parameter = parameter;
    }

    public override void Execute(object parameter)
    {
      _navigationService.Navigate(_parameter);

    }
  }
}
