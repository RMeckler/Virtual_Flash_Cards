﻿using System.Windows.Input;
using Virtual_Flash_Cards.GUI.Commands;
using Virtual_Flash_Cards.GUI.Model;
using Virtual_Flash_Cards.GUI.Services;
using Virtual_Flash_Cards.GUI.Store;

namespace Virtual_Flash_Cards.GUI.ViewModels
{
  internal class ExamResultViewModel : ViewModelBase
  {
    #region Commands
    public ICommand NavigateHomeCommand { get; }
    public ICommand NavigateExamSettingsCommand { get; }
    public ICommand NavigateExamCommand { get; }

    #endregion

    private readonly NavigationStore _navigationStore;
    private readonly ExamSettings _settings;

    internal ExamResultViewModel(ExamSettings settings, 
      NavigationStore navigationStore, 
      INavigationService homeNavigationService)
    {
      _navigationStore = navigationStore;
      _settings = settings;

      NavigateExamSettingsCommand = new NavigateCommand(new NavigationService<ExamSettingsViewModel>(navigationStore, () => new ExamSettingsViewModel(navigationStore, homeNavigationService)));
      NavigateHomeCommand = new NavigateCommand(homeNavigationService);

      ParameterNavigationService<ExamSettings, ExamViewModel> examNavigationService = new(navigationStore, _settings,
        (parameter) => new ExamViewModel(parameter, navigationStore, homeNavigationService));
      NavigateExamCommand = new NavigateCommand(examNavigationService);
    }

    ~ExamResultViewModel()
    {

    }
  }
}
