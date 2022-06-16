using System;
using System.Windows;
using Virtual_Flash_Cards.GUI.Store;
using Virtual_Flash_Cards.GUI.ViewModels;

namespace Virtual_Flash_Cards.GUI.Services
{
  internal class ParameterNavigationService<TParameter, TViewModel> : IParameterNavigationService<TParameter> 
    where TViewModel : ViewModelBase

  {
    private readonly NavigationStore _navigationStore;
    private readonly Func<TParameter, TViewModel> _createViewModel;

    public ParameterNavigationService(NavigationStore navigationStore, Func<TParameter, TViewModel> createViewModel)
    {
      _navigationStore = navigationStore;
      _createViewModel = createViewModel;
    }

    public void Navigate(TParameter parameter)
    {
      var model = _createViewModel(parameter);
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
