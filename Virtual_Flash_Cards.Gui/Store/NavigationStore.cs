using System;
using Virtual_Flash_Cards.GUI.ViewModels;

namespace Virtual_Flash_Cards.GUI.Store
{
  internal class NavigationStore
  {
    public event Action CurrentViewModelChanged;

    private ViewModelBase _currentViewModel;
    public ViewModelBase CurrentViewModel
    {
      get => _currentViewModel;
      set
      {
        _currentViewModel?.Dispose();
        _currentViewModel = value;
        OnCurrentViewModelChanged();
      }
    }

    private void OnCurrentViewModelChanged()
    {
      CurrentViewModelChanged?.Invoke();
    }
  }
}