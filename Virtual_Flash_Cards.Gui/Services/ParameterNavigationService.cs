using System;
using System.Windows;
using Virtual_Flash_Cards.GUI.Store;
using Virtual_Flash_Cards.GUI.ViewModels;

namespace Virtual_Flash_Cards.GUI.Services
{
  internal class ParameterNavigationService<TParameter, TViewModel> : INavigationService
        where TViewModel : ViewModelBase

  {
    private readonly NavigationStore _navigationStore;
    private readonly Func<TParameter, TViewModel> _createViewModel;
    private readonly TParameter _parameter;

    public ParameterNavigationService(NavigationStore navigationStore, TParameter parameter, Func<TParameter, TViewModel> createViewModel)
    {
      _navigationStore = navigationStore;
      _createViewModel = createViewModel;
      _parameter = parameter;
    }

    public void Navigate()
    {
      var model = _createViewModel(_parameter);
      if (IsProgressViewModel(model) && MessageBox.Show("You are currently in a process? Any progress will be lost. Do you want to continue?", "Progress will be lost!", MessageBoxButton.YesNo) == MessageBoxResult.No)
        return;
      _navigationStore.CurrentViewModel = model;
    }

    private bool IsProgressViewModel(ViewModelBase model) //TODO duplicated code
    {
      return (_navigationStore.CurrentViewModel is ExamViewModel && model is not ExamResultViewModel) || _navigationStore.CurrentViewModel is EditViewModel;
    }
  }
}
