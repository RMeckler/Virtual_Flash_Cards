using System.Windows;
using Virtual_Flash_Cards.GUI.Services;
using Virtual_Flash_Cards.GUI.Store;
using Virtual_Flash_Cards.GUI.ViewModels;

namespace Virtual_Flash_Cards.GUI.Commands
{
  internal class NavigateCommand<TParameter, TViewModel> : CommandBase
        where TViewModel : ViewModelBase
  {
    private readonly ParameterNavigationService<TParameter, TViewModel> _navigationService;
    private readonly TParameter _parameter;
  
    public NavigateCommand(TParameter parameter, ParameterNavigationService<TParameter, TViewModel> navigationService)
    {
      _parameter = parameter;
      _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {

      _navigationService.Navigate(_parameter);
    }
  }
}
