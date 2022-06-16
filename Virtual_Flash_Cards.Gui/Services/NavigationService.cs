using System;
using System.Windows;
using Virtual_Flash_Cards.GUI.Store;
using Virtual_Flash_Cards.GUI.ViewModels;

namespace Virtual_Flash_Cards.GUI.Services
{
  internal class NavigationService<TViewModel> : INavigationService
        where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
    {
      var model = _createViewModel();

      if (IsProgressViewModel(model) && MessageBox.Show("You are currently in a process? Any progress will be lost. Do you want to continue?", "Progress will be lost!", MessageBoxButton.YesNo) == MessageBoxResult.No)
          return;

      _navigationStore.CurrentViewModel = model;
    }

    private bool IsProgressViewModel(ViewModelBase model)
    {
      return (_navigationStore.CurrentViewModel is ExamViewModel && model is not ExamResultViewModel) || _navigationStore.CurrentViewModel is EditViewModel;
    }
  }
}
