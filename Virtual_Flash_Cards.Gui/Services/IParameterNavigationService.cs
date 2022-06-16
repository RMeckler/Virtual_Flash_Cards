namespace Virtual_Flash_Cards.GUI.Services
{
  internal interface IParameterNavigationService<TParameter>
  {
    void Navigate(TParameter parameter);
  }
}